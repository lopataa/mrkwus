const Location = require("./location.js");

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

module.exports = Player;
