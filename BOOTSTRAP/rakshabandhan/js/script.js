// ====Login validation======


 validate = () => {
 
    let email = document.getElementById("exampleInputEmail1").value;
    let password = document.getElementById("exampleInputPassword1").value;
  
    
   
 
    if (email == "" && password == "" ) {
       alert('Please Fill the Whole Form')
       return false;
    }
    else {
      
 
       if (email == "") {
          alert("Please provide your Email Address!");
          document.myForm.exampleInputEmail1.focus();
          return false;
       }
 
      
 
       if (password == "") {
          alert("Please provide your Password!");
          document.myForm.exampleInputPassword1.focus();
          return false;
       }
 
     
    }
    return true;
 }
 
 nameValidation = () => {
    let userName = document.getElementById("exampleInputName").value
    if (userName.length < 8 || userName.length == "") {
       document.getElementById("nameHelp").style.display = "block";
       document.getElementById("nameHelp").style.color = "red";
    }
    else {
       document.getElementById("nameHelp").style.display = "none";
    }
 }
 
 emailValidation = () => {
    var mailformat = /^\w+([\.-]?\w+)*@\w+([\.-]?\w+)*(\.\w{2,3})+$/;
    let email = document.getElementById("exampleInputEmail1").value;
    if (!email.match(mailformat)) {
       document.getElementById("emailHelp").style.display = "block";
       document.getElementById("emailHelp").style.color = "red";
    }
    else {
       document.getElementById("emailHelp").style.display = "none";
    }
 }
 
 passwordValidation = () => {
    let password = document.getElementById("exampleInputPassword1").value;
    console.log(password.length);
    if (password.length < 8 || password.length > 20) {
       document.getElementById("passwordHelpInline").style.display = "block";
       document.getElementById("passwordHelpInline").style.color = "red";
    }
    else {
       document.getElementById("passwordHelpInline").style.display = "none";
    }
 }
 


//  sign in validation



 svalidate = () => {
 
    let email = document.getElementById("exampleInputEmail2").value;
    let password = document.getElementById("exampleInputPassword2").value;
    let cpassword = document.getElementById("cexampleInputPassword2").value;

  
    
   
 
    if (email == "" && password == "" && cpassword =="" ) {
       alert('Please Fill the Whole Form')
       return false;
    }
    else {
      
 
       if (email == "") {
          alert("Please provide your Email Address!");
          document.signupForm.exampleInputEmail2.focus();
          return false;
       }
 
      
 
       if (password == "") {
          alert("Please provide your Password!");
          document.signupForm.exampleInputPassword2.focus();
          return false;
       }
       if(cpassword == ""){
         alert("Please provide your confirm password");
         document.signupForm.cexampleInputPassword2.focus();
         return false;
       }
 
     
    }
    return true;
 }
 

 
 semailValidation = () => {
    var mailformat = /^\w+([\.-]?\w+)*@\w+([\.-]?\w+)*(\.\w{2,3})+$/;
    let email = document.getElementById("exampleInputEmail2").value;
    if (!email.match(mailformat)) {
       document.getElementById("emailHelp2").style.display = "block";
       document.getElementById("emailHelp2").style.color = "red";
    }
    else {
       document.getElementById("emailHelp2").style.display = "none";
    }
 }
 
 spasswordValidation = () => {
    let password = document.getElementById("exampleInputPassword2").value;
    console.log(password.length);
    if (password.length < 8 || password.length > 20) {
       document.getElementById("passwordHelpInline2").style.display = "block";
       document.getElementById("passwordHelpInline2").style.color = "red";
    }
    else {
       document.getElementById("passwordHelpInline2").style.display = "none";
    }
 }
 
 sconfirmPasswordValidation = () => {
    let password = document.getElementById("exampleInputPassword2").value;
    let confirmPassword = document.getElementById("cexampleInputPassword2").value;
    if (password != confirmPassword) {
       document.getElementById("confirmPasswordHelpInline2").style.display = "block";
       document.getElementById("confirmPasswordHelpInline2").style.color = "red";
    }
    else {
       document.getElementById("confirmPasswordHelpInline2").style.display = "none";
    }
 }
// ==================


 
 // Function to set a cookie
 function setCookie(cname, cvalue, exdays) {
   console.log("setCookie");
   const d = new Date();
   d.setTime(d.getTime() + exdays * 24 * 60 * 60 * 1000);
   const expires = "expires=" + d.toUTCString();
   document.cookie = cname + "=" + cvalue + "; " + expires;
 }
 
 // Function to get a cookie by name
 function getCookie(cname) {
   const name = cname + "=";
   
   const ca = document.cookie.split(";");
   // console.log(document.cookie);
   // console.log(name);
  
   for (let i = 0; i < ca.length; i++) {
     let c = ca[i];
     while (c.charAt(0) === " ") {
      c = c.substring(1);
    }
     if (c.indexOf(name) === 0) {
       return c.substring(name.length, c.length);
     }
   }
   return "";
 }
 
 // Function to check if a session cookie exists
 function checkCookie(cookieName) {
   const sessionCookie = getCookie(cookieName);
   console.log(sessionCookie);
   return sessionCookie !== "";
 }
 
 // Handle form submission
 document.getElementById("login-form").addEventListener("submit", function (e) {
   e.preventDefault();
   const username = document.getElementById("exampleInputEmail1").value;
   // const password = document.getElementById("exampleInputPassword1").value;
 
  
   
   var a = checkCookie(username);
   console.log(a);
   if(a){
      window.location.href = "../dashboard.html";
   }
   else{
      alert("Invalid username and password");
   }

 
 
 });


 document.getElementById("signup").addEventListener("submit", function (e) {
   e.preventDefault();
   const username = document.getElementById("exampleInputEmail2").value;
   const password = document.getElementById("exampleInputPassword2").value;
 
   // set cookie
   setCookie(username, password, 1); // 1 day expiration
   
   window.location.href = "../dashboard.html";
   
 
 
 });
 