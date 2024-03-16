const express = require("express");
const cors = require("cors");
const helmet = require("helmet");
const morgan = require("morgan");
const compression = require("compression");

require("dotenv").config();
require("./config/db.js");

const app = express();
app.use(express.json());
app.set("json spaces", 4);
app.use(cors());
app.use(compression());
app.use(helmet());
app.use(morgan('dev'));

// app.use("/api", routes);

const port = process.env.PORT || 7000;
app.listen(port, () => console.log(`Listening on port: ${port}!`));