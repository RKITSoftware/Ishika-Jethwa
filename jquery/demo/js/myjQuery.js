$(document).ready(function () {
  console.log("jquery");
  // -------------selector------------

  //element selector
  // $("button").click(function(){
  //   $("p").hide();
  // });
  // //id selector
  // $("button").click(function(){
  //     $("#test").hide();
  // });
  // //class selector
  // $("button").click(function(){
  //     $(".test").hide();
  //   });
  //  this selector
  // $("button").click(function(){
  //     $(this).hide();
  //   });
  //universal selector
  // $("button").click(function(){
  //     $("*").hide();
  //   });

  // ------------events-------------

  $("p").click(function () {
    console.log("You clicked");
  });

  $("p").dblclick(function () {
    console.log("You double clicked");
  });

  $("#p1").mouseenter(function () {
    console.log("You entered p1!");
  });

  $("#p1").mouseleave(function () {
    console.log("Bye! You now leave p1!");
  });

  $("#p1").mousedown(function () {
    console.log("Mouse down over p1!");
  });
  $("#p1").mouseup(function () {
    console.log("Mouse up over p1!");
  });

  $("#p1").hover(
    function () {
      console.log("You entered p1!");
    },
    function () {
      console.log("Bye! You now leave p1!");
    }
  );

  $("input").focus(function () {
    $(this).css("background-color", "red");
    console.log(this);
  });

  $("input").blur(function () {
    $(this).css("background-color", "blue");
  });


  $("p").on({
    mouseenter: function () {
      $(this).css("background-color", "lightgray");
    },
    mouseleave: function () {
      $(this).css("background-color", "lightblue");
    },
    click: function () {
      $(this).css("background-color", "yellow");
    },
  });
  // --------keyboard events-------
  i = 0;

  $("input").keypress(function () {
    $("span").text((i += 1));
  });
  $("input").keydown(function (event) {
    var a = event.key;
    console.log("You've pressed the key: " + a);
  });

  // -------hide show toggle------
  $("#hide").click(function () {
    $("p").hide(2000);
  });

  $("#show").click(function () {
    $("p").show();
  });
  $("#toggleButton").click(function () {
    $("p").toggle();
  });

  // --------fade----------
  //fade in - fade in hidden element
  //fade out - fade out visible element
  //fadeToggle - toggles between fadein fadeout
  //fadeto - fading to given opacity(0-1)

  $("#fadeButton").click(function () {
    $("#div1").fadeIn();
    $("#div2").fadeIn("slow");
    $("#div3").fadeIn(3000);
  });

  // -------sliding method-------
  // The jQuery slideDown() method is used to slide down an element.
  // The jQuery slideUp() method is used to slide up an element.
  // The jQuery slideToggle() method toggles between the slideDown() and slideUp() methods.

  $("#flip").click(function () {
    $("#panel").slideToggle(5000);
  });
  $("#stop").click(function () {
    $("#panel").stop();
  });
  // ------animation---------
  //   $('#wiki').animate({
  //     opacity:0.3,
  //     height: '150px',
  //     width:'350px'

  // }, "fast")
  // $('#wiki').animate({ opacity: 0.3 }, 4000);
  // $('#wiki').animate({ opacity: 0.9 }, 1000);
  $("#wiki").animate({ width: "350px" }, 12000);

  //-----------text / html / val------------
  // text() - Sets or returns the text content of selected elements
  // html() - Sets or returns the content of selected elements (including HTML markup)
  // val() - Sets or returns the value of form fields

  $("#btn1").click(function(){
    alert("Text: " + $("#para").text());
  });
  $("#btn2").click(function(){
    alert("HTML: " + $("#para").html());
  });
  $("#btn3").click(function(){
    alert("Value: " + $("#Mickey").val());
  });
  // $('#para').empty()
  // $('#para').remove()
  $('a').attr('href', 'https://www.youtube.com');

    $('#para').addClass('myclass');
    if($('#para').hasClass('myclass')){
      console.log("already declared class")
    }

    $('#para').addClass('myclass2');
    $('#para').removeClass('myclass2');
    $('#para').css('background-color', 'red');
  
  // ----------
  var numbers = [1, 2, 3];
    var doubled = $.map(numbers, function(value) {
  return value * 2;
});
console.log(doubled)
// doubled is now [2, 4, 6]

var numbers = [1, 2, 3, 4, 5, 6];

// Filter even numbers from the array
// parameter = array , callback, invert(true, false)
var evenNumbers = $.grep(numbers, function(element) {
    return element % 2 === 0;
},true);

console.log(evenNumbers); // Outputs: [2, 4, 6]

// evens is now [2, 4]

var obj1 = { a: 1, b: 2 };
var obj2 = { b: 3, c: 4 };
var obj3 = { d: 3, c: 4 };


$.extend(obj1, obj2 ,obj3);
console.log(obj1)
// Merge Object_1 and Object_2, without modifying Object_1 
var Object_3 = $.extend( {}, obj1, obj2 ); 
console.log(Object_3)
// obj1 is now { a: 1, b: 3, c: 4 }

var colors = ["red", "green", "blue"];
$.each(colors, function(index, value) {
  console.log("Color at index " + index + " is " + value);
});

// The merge() method accepts only two parameter that is mentioned
var arr1 = [{a: 1, b: 2} , {e: 3, f: 4}];
var arr2 = [{c: 6, d: 7}];


// var arr3 = [{a: 1, b: 3}];

var mergedArray =$.merge(arr1,arr2);
console.log(mergedArray);


// arr1 is now [1, 2, 3, 4, 5]

// -----------RegExp----------
 // i  Perform case-insensitive matching 
    // g  Perform a global match (find all matches rather than stopping after the first match)  
    // m  Perform multiline matching

    // [abc]  Find any of the characters between the brackets 
    // [0-9]  Find any of the digits between the brackets 
    // (x|y)  Find any of the alternatives separated with |

    // \d Find a digit  
    // \s Find a whitespace character 
    // \b Find a match at the beginning of a word like this: \bWORD, or at the end of a word like this: WORD\b  
    // \uxxxx Find the Unicode character specified by the hexadecimal number xxxx

    // n+ Matches any string that contains at least one n
    // n* Matches any string that contains zero or more occurrences of n
    // n? Matches any string that contains zero or one occurrences of n

// Sample string
var text = "Hello, world! This is a sample text.";

// Define a regular expression pattern
var pattern = /sample/;

// Use the regular expression test() method to check for a match
if (pattern.test(text)) {
  console.log("Pattern found in the text.");
} else {
  console.log("Pattern not found in the text.");
}
// ------------
var emailPattern = /^[a-zA-Z0-9._-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,4}$/;

// Test the pattern with an email
var email = "example@email.com";
if (emailPattern.test(email)) {
  console.log("Valid email address.");
} else {
  console.log("Invalid email address.");
}




    // --------------------
    var obj1 = [{ no : 1, "city": "dwarka" }, { no : 2, "city": "Rajkot" }];

    var filteredObj1 = $.grep(obj1, function(item) {
      
        return item.no === 2;
      });
    
    console.log(filteredObj1);
    console.log(filteredObj1[0].city);

});

