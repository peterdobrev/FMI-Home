const router = require("express").Router();

const { getPlayers, getPlayerByID, createPlayer } = require("./controllers/playersController.js");

router.get("/players", getPlayers);
router.get("/players/:playerID", getPlayerByID);
router.post("/players", createPlayer);

module.exports = router;