const { readFileSync, readdir } = require("fs");
const { createServer } = require("http");
const { Server } = require("socket.io");
const World = require("./world.js");
const Player = require("./player.js");
const Location = require("./location.js");
require('better-logging')(console);
require('mathjs');



class Obstacle { }


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
    readdir(__dirname + "/carrots", function(err, files) {
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
    else if (world.getPlayerByUsername(username)) {
      socket.emit("error", "username in use");
      socket.disconnect();
      console.error(socket.id + " > Tried to login with username already in use")
      return;
    }
    else if (world.getPlayerById(socket.id)) {
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
    let player = world.getPlayerById(socket.id);
    player.updateLocation(new Location(x, y, rotation))
    console.log(player.toString() + " > Location changed to: " + player.location.toString());

    world.broadcast("move", [player.id, player.location.x, player.location.y, player.location.rotation], [player]);
  });

  socket.on("chat", (message) => {
    let player = world.getPlayerById(socket.id);
    world.broadcast("chat", [message], [player]);
    console.log(player.toString() + " > chat: " + message);
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