$("#login-btn").click(function(){
      var data={
        userName: $(".userName").val(),
        password: $(".password").val()
      };

    if(!data.userName){
        alert('please fill userName');
        return;
    }
    if(!data.password){
        alert('please fill password');
        return;
    }
    $.ajax({
        url : 'https://localhost:7101/User/SignIn',
        type : 'POST',
        data :JSON.stringify(data),
        dataType:'json',
        contentType: "application/json;charset=utf-8",
        success : function(data) {              

            if(data.status){

                var tokenExpireDateTime=new Date(new Date().getTime() + data.data.tokenExpiredMinute * 60000);
                localStorage.setItem('token',data.data.result);
                localStorage.setItem('tokenExpiredTime',  tokenExpireDateTime);  
                window.location.href = "translation-report.html";

            }
            alert(data.message);
        },
        error : function(request,error)
        {
            alert("Request: "+JSON.stringify(request));
        }
    });

});