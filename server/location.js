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

module.exports = Location;