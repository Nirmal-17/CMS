const { connectDatabase } = require("./database/database.js");
const Blog=require("./model/blogModel");
const express = require("express");
const app = express();


app.set('view engine','ejs')
//nodejs lai form bata arko data parse gar vaneko ho
app.use(express.json());
app.use(express.urlencoded({extended:true}))

//DATABASE CONNECTION
connectDatabase()


//GET API
app.get('/',(req,res)=>{
    res.render('home.ejs')})
    
    
    app.get('/about',(req,res)=>{
        res.json({
            message:"about page",
            status:8888
        })
    })
    //GET API -> /blogs (all blogs)
    app.get('/blogs',async(req,res)=>{
        //fetch all blogs from blog model
        const blogs=await Blog.find();
//check if blogs contains data or not
if(blogs.length==0){
    res.json({
        status:200,
        message:"empty blogs",
        
    })}
else{
            res.status(200).json({
            message:"Blogs fetched successfully",
            data:blogs
        })
    }
    })
//GET API -> /blogs/:id (single blog)
app.get('/blogs/:id',async(req,res)=>{
    //const {id} = req.params
    //const blog = await Blog.find({_id:id})
    const blog=await Blog.findById(id=req.params.id)
    if(blog){
        res.json({
            message:"single blog fetched successfully",
            data:blog
        })
    }else
    {
    res.status(404).json({
        message:"Blog not found",
        data:null
    })

}})


    app.get('/contact',(req,res)=>{
        res.send("contact information!")
    })
    app.get('/index',(req,res)=>{
        res.send("you are in index page!")
    })
    //Create a blog api
    app.post('/createBlog',async(req,res)=>{
        const title=req.body.title;
        const subTitle=req.body.subTitle
        const description=req.body.description;


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