const router = require("express").Router();

const { getPlayers } = require("./controllers/playersController.js");

router.get("/players", getPlayers);

module.exports = router;