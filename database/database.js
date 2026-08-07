const mongoose = require("mongoose");

exports.connectDatabase = async () => {
    try {
        await mongoose.connect(
            "mongodb://nirmaldahal19_db_user:nirmal7@ac-vuufxqb-shard-00-00.3we19lg.mongodb.net:27017,ac-vuufxqb-shard-00-01.3we19lg.mongodb.net:27017,ac-vuufxqb-shard-00-02.3we19lg.mongodb.net:27017/?ssl=true&replicaSet=atlas-dpq844-shard-0&authSource=admin&appName=Cluster0"
        );

        console.log("✅ Database connected successfully!");
    } catch (error) {
        console.log("❌ Database connection failed!");
        console.error(error);
    }
};