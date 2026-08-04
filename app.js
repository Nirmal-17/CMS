const app = require("express")();
const mongoose = require("mongoose");

//connecting database
mongoose.connect("mongodb://nirmaldahal19_db_user:nirmal7@ac-vuufxqb-shard-00-00.3we19lg.mongodb.net:27017,ac-vuufxqb-shard-00-01.3we19lg.mongodb.net:27017,ac-vuufxqb-shard-00-02.3we19lg.mongodb.net:27017/?ssl=true&replicaSet=atlas-dpq844-shard-0&authSource=admin&appName=Cluster0&retryWrites=true&w=majority")
.then(()=>{
    console.log("Database connected successfully")
})
.catch((err)=>{
    console.log("Database connection failed",err)
})

//GET API
app.get('/',(req,res)=>{
    res.send("You are in the home page")})
    app.get('/about',(req,res)=>{
        res.json({
            message:"This is the about page",
            status:8888
        })
    })
    app.get('/contact',(req,res)=>{
        res.send("contact information!")
    })






app.listen(3000,(req,res)=>{
    console.log('server is running on port 3000')}) 