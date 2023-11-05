var userName = document.getElementById("userName")
var submitButton = document.getElementById("submitButton")


function Abc(name){
    return `Hello, ${name}!`;
}
function Xyz(name){
    const abc = Abc(name);
    return `${abc} , you are beautiful!`;
}
function Greeting(name){
    const result = Xyz(name);
    console.log(result)
}
submitButton.addEventListener('click', function handleClick() {
    Greeting(userName.value)
   
  });

