
const API = {
        login: null,
        personas: {
            create: null,
            get: null,
            update: null,
            delete: null,
        },
        solicitudes: {
            create: null,
            get: null,
            listByEstado: null,
            update: null,
            delete: null,
        },
        estados: {
            get: null,
        }
};

const layout = {
    login: {
        loginBtn: null,
    },
    personas: {
        create: null,
        get: null,
        update: null,
        delete: null,
    },
    solicitudes: {
        create: null,
        get: null,
        listByEstado: null,
        update: null,
        delete: null,
    },
};

function init(){

}


function ajaxRequest()
{
    var link = "https://en.wikipedia.org/w/api.php?action=query&prop=info&pageids="+ page +"&format=json&callback=?";
    var xmlHttp = new XMLHttpRequest(); // creates 'ajax' object
        xmlHttp.onreadystatechange = function() //monitors and waits for response from the server
        {
           if(xmlHttp.readyState === 4 && xmlHttp.status === 200) //checks if response was with status -> "OK"
           {
               var re = JSON.parse(xmlHttp.responseText); //gets data and parses it, in this case we know that data type is JSON. 
               if(re["Status"] === "Success")
               {//doSomething}
               else 
               {
                   //doSomething
               }
           }

        }
        xmlHttp.open("GET", link); //set method and address
        xmlHttp.send(); //send data

}