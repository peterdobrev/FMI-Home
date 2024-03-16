const mongoose = require("mongoose");
const URI = process.env.MONGO_URI;

mongoose.connect(URI)
.then(() => {
    console.log("Connection with MongoDB established!");
})
.catch(err => {
    console.log(err);
    process.exit(1);
});