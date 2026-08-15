const { connectDatabase } = require("./database/database.js");
const Blog=require("./model/blogModel");
const express = require("express");
const app = express();

app.use(express.json());
app.use(express.urlencoded({extended:true}));
//DATABASE CONNECTION
connectDatabase()


//GET API
app.get('/',(req,res)=>{
    res.send("You are in the home page")})
    app.get('/about',(req,res)=>{
        res.json({
            message:"about page",
            status:8888
        })
    })
    app.get('/contact',(req,res)=>{
        res.send("contact information!")
    })
    app.get('/index',(req,res)=>{
        res.send("you are in index page!")
    })
    //Create a blog api
    app.post('/blog',async(req,res)=>{
        const {title,subTitle,description}=req.body;
//insert into database logic
await Blog.create({
   title: title,
    subTitle: subTitle,
    description: description
})





        res.json({
         message:"blog created successfully",
           status:200
        });
    });



app.listen(4444,(req,res)=>{
    console.log('server is running on port 4444')})