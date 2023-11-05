$('#frm').validate({
	rules:{
		name:"required",
		email:{
			required:true,
			email:true
		},
		password:{
			required:true,
			minlength:5
		},
		number: {
			required: true,
			number: true,
			// Custom rule to allow up to two decimal places
			maxTwoDecimalPlaces: true,
		  },
	},messages:{
		name:"Please enter your name",
		email:{
			required:"Please enter email",
			email:"Please enter valid email",
		},
		password:{
			required:"Please enter your password",
			minlength:"Password must be 5 char long"
		},
		number: {
			required: "Please enter a number.",
			number: "Please enter a valid number.",
			maxTwoDecimalPlaces: "Please enter a number with up to two decimal places.",
		  },
	},
	submitHandler:function(form){
		form.submit();
	}
});
$.validator.addMethod(
    "maxTwoDecimalPlaces",
    function(value) {
      return /^\d+(\.\d{1,2})?$/.test(value);
    },
    "Please enter a valid number with up to two decimal places."
  );