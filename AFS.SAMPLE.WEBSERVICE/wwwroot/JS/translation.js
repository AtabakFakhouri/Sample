function leetSpeakTranslate(){
    $.ajax({
        url : 'https://localhost:7101/Request/LeetSpeakTranslate',
        type : 'GET',
        data :{text:$("#InputText").val()},
        headers: {"Authorization": 'Bearer '+ localStorage.getItem('token')},
        dataType:'json',
        contentType: "application/json;charset=utf-8",
        success : function(data) {                         
            if(data.status && data.data.contents && data.data.contents.translation){
                $("#TranslationResult").val(data.data.contents.translated);
                return;
            }
            alert(data.message);
        },
        error : function(request,error)
        {
            alert("Request: "+JSON.stringify(request));
        }
    });


}