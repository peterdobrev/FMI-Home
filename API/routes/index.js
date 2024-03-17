const router = require("express").Router();

const { getPlayers, getPlayerByID, createPlayer, updatePlayer, deletePlayer } = require("./controllers/playersController.js");

router.get("/players", getPlayers);
router.get("/players/:playerName/:facultyNumber", getPlayerByID);
router.post("/players", createPlayer);
router.put("/players/:playerID", updatePlayer);
router.delete("/players/:playerID", deletePlayer);

module.exports = router;