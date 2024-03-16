const Player = require("../../models/playersModel.js");

const getPlayers = async (req, res) => {
    try {
        const products = await Player.find({}).sort({ _id: 1 });
        res.status(200).send(products);
    } catch (err) {
        res.status(500).send({ message: err.message });
    };
};

const getPlayerByID = async (req, res) => {
    try {
        const player = await Player.findById(req.params.playerID);

        player ? 
            res.status(200).json(player) :
            res.status(400).json({ message: `Player with id: ${req.params.playerID} not found!` });
    } catch (err) {
        res.status(500).json({ message: err.message });
    };
};

const createPlayer = async (req, res) => {
    const player = new Player(req.body);

    try {
        const newPlayer = await player.save();
        res.status(201).json(newPlayer);
    } catch (err) {
        res.status(500).json({ message: err.message });
    };
};

module.exports = { getPlayers, getPlayerByID, createPlayer };