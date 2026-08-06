const { connectDatabase } = require("./database/database.js");

const app = require("express")();


//DATABASE CONNECTION
connectDatabase()


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