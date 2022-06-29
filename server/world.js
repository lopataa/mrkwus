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

  getPlayerById(id) {
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
  
  getPlayerByUsername(username) {
    try {
      this._players.forEach(function (player, index, object) {
        if (player.username == username) {
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

module.exports = World;