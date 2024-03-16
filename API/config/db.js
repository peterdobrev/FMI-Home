const mongoose = require("mongoose");
const URI = process.env.MONGO_URI;

mongoose.connect(URI, { useNewUrlParser: true, useUnifiedTopology: true })
.then(() => {
    console.log("Connection with MongoDB established!");
})
.catch(err => {
    console.log(err);
    process.exit(1);
});