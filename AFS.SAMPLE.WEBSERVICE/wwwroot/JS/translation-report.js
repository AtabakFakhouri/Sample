$(document).ready(function(){
        translationgrid();
        loadDatePickers();
});


function translationgrid(){    
    var data={};
    $('.searchfield').each(function(i, obj) {
        if(obj.classList.contains('datepicker')){
            if(obj.value)
            data[obj.name]=obj.value;
        }
        else
        data[obj.name]=obj.value;
    });

// var data={
//     UserName:"",
//     FromDate:null,
//     ToDate:null,
//     InputText:"",
//     Translation:""
// };
    $('#translation-table').DataTable().destroy();
    $.ajax({
        url : 'https://localhost:7101/Request/GridList',
        type : 'POST',
        data :JSON.stringify(data),
        dataType:'json',
        contentType: "application/json;charset=utf-8",
        success : function(data) {              
           
    $('#translation-table').DataTable({
        "data":data,   
        "searching":false,     
        "columns": [
            { "data": "userName","name":"userName" },
			{ "data": "text" ,"name":"text"},
            { "data": "translation" ,"name":"translation"},
            { "data": "createDate" ,"name":"date"},
        ],
        
    } );            
        },
        error : function(request,error)
        {
            alert("Request: "+JSON.stringify(request));
        }
    });


}

function clearFilter(){
    $('.searchfield').each(function(i, obj) {
       obj.value="";
    });
    translationgrid();    
}

function loadDatePickers(){
    $('.datepicker').datepicker({
        dateFormat: 'yy-mm-dd',
        startDate: '+1d'
    });
}