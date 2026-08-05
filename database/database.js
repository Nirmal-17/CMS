exports.connectDatabase = async()=>{

    //connecting to database
    await mongoose.connect("mongodb://nirmaldahal19_db_user:nirmal7@ac-vuufxqb-shard-00-00.3we19lg.mongodb.net:27017,ac-vuufxqb-shard-00-01.3we19lg.mongodb.net:27017,ac-vuufxqb-shard-00-02.3we19lg.mongodb.net:27017/?ssl=true&replicaSet=atlas-dpq844-shard-0&authSource=admin&appName=Cluster0&retryWrites=true&w=majority")
    console.log("Database connected successfully")
}