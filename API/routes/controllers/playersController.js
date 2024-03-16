const Player = require("../../models/playersModel.js");

const getPlayers = async (req, res) => {
    try {
        const products = await Player.find({}).sort({ _id: 1 });
        res.status(200).send(products);
    } catch (err) {
        res.status(500).send({ message: err.message });
    }
};



module.exports = { getPlayers };