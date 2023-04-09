$(document).ready(function(){

    var lsTokenExpiredMinute=localStorage.getItem('tokenExpiredTime');
    if(!lsTokenExpiredMinute ||
        new Date(lsTokenExpiredMinute)<new Date()){
            window.location.href = "404.html";  
            return;          
        }        
});

function logout(){
    localStorage.clear();
    window.location.href = "login.html";
}
