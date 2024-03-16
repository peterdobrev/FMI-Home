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

const updatePlayer = async (req, res) => {
    try {
        const player = await Player.findOneAndUpdate({ _id: req.params.playerID }, req.body);
        res.status(200).json(player);
    } catch (err) {
        res.status(500).json({ message: err.message });
    }
};

const deletePlayer = async (req, res) => {
    try {
        await Player.findOneAndDelete({ _id: req.params.playerID });
        res.status(200).json({ message: `Player with id: ${req.params.playerID} has been successfully deleted!` });
    } catch (err) {
        res.status(400).json({ message: err.message });
    };
};

module.exports = { getPlayers, getPlayerByID, createPlayer, updatePlayer, deletePlayer };