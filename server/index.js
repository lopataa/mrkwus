const { readFileSync, readdir } = require("fs");
const { createServer } = require("http");
const { Server } = require("socket.io");
require('better-logging')(console);
require('mathjs');

class World {
  constructor(height = 8192, width = 8192) {
    if (height <= 0 || width <= 0) {
      throw ("Invalid map size");
    }
    this.height = height;
    this.width = width;
    this._players = [];
  }

  addPlayer(player) {
    this._players.push(player);
  }

  removePlayer(id) {
    this._players.forEach(function (player, index, object) {
      if (player.id == id) {
        object.splice(index, 1);
        return;
      }
    });
  }

  broadcast(type, message, excluded_players = []) {
    this._players.forEach(function (player) {
      //if player is not in excluded_players, emit message to player
      if (excluded_players.length == 0) {
        player.socket.emit(type, ...message);
      } else {
        if (!excluded_players.some(excluded_player => excluded_player.id == player.id)) {
          player.socket.emit(type, ...message);
        }
      }
    });
  }

  getPlayer(id) {
    try {
      this._players.forEach(function (player, index, object) {
        if (player.id == id) {
          throw player;
        }
      });
    } catch (error) {
      return error;
    }

  }

  get players() {
    return this._players;
  }
}

class Location {
  constructor(x = 0, y = 0, rotation = 0) {
    this.x = x;
    this.y = y;
    this.rotation = rotation;
  }

  toString() {
    return "x:" + this.x + " y:" + this.y + " rot:" + this.rotation;
  }
}

class Obstacle { }

class Player {
  constructor(socket_object, username, location = new Location()) {
    this.socket_object = socket_object;
    this.username = username;
    this.location = location;
  }

  updateLocation(location) {
    this.location = location;
  }

  get id() {
    return this.socket_object.id;
  }

  get socket() {
    return this.socket_object;
  }

  toString() {
    return this.username;
  }
}

const httpServer = createServer((req, res) => {

  if (req.url == "/players") {
    res.writeHead(200, {
      "Content-Type": "text/html",
    });
    res.write("Players online (" + Object.keys(players).length + "): ")
    for (const [key, value] of Object.entries(players)) {

    }
    res.end()
    return
  }
  else if (req.url == "/mrkvicka") {
    res.writeHead(200, {
      "Content-Type": "image/png",
    });
    readdir(__dirname + "/carrots", function (err, files) {
      //handling error
      if (err) {
          return console.log('Unable to scan directory: ' + err);
      } 
      res.end(readFileSync(__dirname + "/carrots/" + files[Math.floor(Math.random() * files.length)]));
  });
  } else {
    res.writeHead(200, {
      "Content-Type": "text/html",
    });
    // reload the file every time
    const content = "<h3 style=\"color: green;\">server thing is operational</h3>" +
      readFileSync(__dirname + "/index.html");
    const length = Buffer.byteLength(content);
    res.end(content);
  }
});

const io = new Server(httpServer, {
  // Socket.IO options
});

let world = new World();

io.on("connection", (socket) => {

  socket.on("login", (username) => {
    if (username == "") {
      socket.emit("error", "empty username");
      socket.disconnect();
      console.error(socket.id + " > Tried to login with empty username")
      return;
    } else if (username.length > 16) {
      socket.emit("error", "long username");
      socket.disconnect();
      console.error(socket.id + " > Tried to login with too long username")
      return;
    }
    // check if username is already in use or id already logged in 
    if (world.players.hasOwnProperty(username)) {
      socket.emit("error", "username in use");
      socket.disconnect();
      console.error(socket.id + " > Tried to login with username already in use")
      return;
    }
    else if (world.players.hasOwnProperty(socket.id)) {
      socket.emit("error", "id in use");
      socket.disconnect();
      console.error(socket.id + " > Tried to login with id already in use")
      return;
    }
    let player = new Player(socket, username);
    world.addPlayer(player);
    world.broadcast("join",
      [player.id,
      player.username,
      player.location.x,
      player.location.y,
      player.location.rotation], [player]);
    socket.emit("login",
      player.id,
      player.location.x,
      player.location.y,
      player.location.rotation);
    console.info(player.toString() + " > Logged in as " + username);

    for (let i = 0; i < world._players.length; i++) {
      if (world._players[i] === player) continue;
      socket.emit("join",
        world._players[i].id,
        world._players[i].username,
        world._players[i].location.x,
        world._players[i].location.y,
        world._players[i].location.rotation);
    }
  });

  socket.on("location", (x, y, rotation) => {
    let player = world.getPlayer(socket.id);
    player.updateLocation(new Location(x, y, rotation))
    console.log(player.toString() + " > Location changed to: " + player.location.toString());

    world.broadcast("move", [player.id, player.location.x, player.location.y, player.location.rotation], [player]);
  });

  console.info(socket.id + " has joined, awaiting login!");
  socket.on("disconnect", (reason) => {
    console.info(socket.id + ' has left because \'' + reason + '\'');
    delete world.removePlayer(socket.id);
    world.broadcast("leave", [socket.id]);
    socket.emit("leave", socket.id);
  });
});

httpServer.listen(80);