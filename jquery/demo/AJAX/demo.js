//async function always return a promise

//function to fetch 100 users
async function FetchUsers() {
    let users;
    let response = await fetch("https://jsonplaceholder.typicode.com/posts")
    
    try{
        console.log("Fetching Users..");
        users = await response.json();
        // console.log(users);
    }
    catch(error){
        console.log(error); //handling error thrown by fetch
    }

    return users;
}

//Function to fetch 10 posts
async function FetchPosts() {

    let posts;
    let response = await fetch("https://jsonplaceholder.typicode.com/users")

    try{
        console.log("Fetching Posts..");
        posts = await response.json();
        // console.log(posts);
    }
    catch(error){
        console.log(error); //handling error thrown by fetch
    }

    return posts;
}

//Driver code

async function myMain(){
    console.log("Starting Services..")
    
    let res = await FetchUsers();
    console.log("res",res);
    
    let posts = await FetchPosts();
    console.log("posts: ", posts);
}


myMain()