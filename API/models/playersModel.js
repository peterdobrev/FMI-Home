const mongoose = require("mongoose");
const Joi = require("joi");
const Joigoose = require("joigoose")(mongoose);

const joiPlayerSchema = Joi.object({
    playerName: Joi.string().required(),
    facultyNumber: Joi.string().required(),
    points: Joi.number().integer()
});

const mongoosePlayerSchema = new mongoose.Schema(Joigoose.convert(joiPlayerSchema));
const Player = mongoose.model("players", mongoosePlayerSchema, "players");
module.exports = Player;