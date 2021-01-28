window.onload = (function () {

    function ajax(endpoint, method, params, callback, errorCallback) {
        var link = `api/${endpoint}`;
        var xmlHttp = new XMLHttpRequest();
        xmlHttp.onreadystatechange = function () {
            if (xmlHttp.readyState === 4 && xmlHttp.status === 200) {
                if (callback) {
                    var data = JSON.parse(xmlHttp.responseText);
                    callback(data);
                }
            }
            else {
                if (xmlHttp.readyState === 4 && errorCallback) {
                    errorCallback();
                }
            }

        }

        xmlHttp.open(method, link);
        xmlHttp.setRequestHeader('Content-Type', 'application/json');
        
        if(params){
            xmlHttp.send(JSON.stringify(params));
        } else {
            xmlHttp.send();
        }
        
    }

    const API = {
        login: function (e) {
            const username = layout.login.usernameField.value;
            const password = layout.login.passwordField.value;

            ajax(
                "login",
                "POST",
                {username, password},
                ()=> { alert("login sucess"); },
                ()=> { alert("login FAILED"); },
            );
        },
        personas: {
            create: function(e){
                // GET DATA FROM FORM
                const persona = {
                    Nombre: "CARLOS",
                    Apellido: "ALVAREZ",
                    Direccion: "1 MORTAGE RD, MONTE CRISTI",
                    FechaNacimiento: "2020-01-28",
                    Pasaporte: "¨SC12345678",
                    Sexo: "M",
                    // FOTO
                };

                ajax(
                    "personas", // API ENDPOINT
                    "POST",     // METHOD
                    persona,
                    () => {
                        // IF CALL SUCCEDES
                        alert("CREATED SUCCESSFULLY");
                    },
                    () => {
                        // IF CALL FAILS
                        alert("CREATION FAILED");
                    },
                );
            },
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
            loginBtn: document.getElementById("loginBtn"),
            usernameField: document.getElementById("loginUsername"),
            passwordField: document.getElementById("loginPassword"),
        },
        personas: {
            createBtn: document.getElementById("personasCreateBtn"),
            getBtn: document.getElementById("personasGetBtn"),
            updateBtn: document.getElementById("personasUpdateBtn"),
            deleteBtn: document.getElementById("personasDeleteBtn"),
        },
        solicitudes: {
            createBtn: document.getElementById("solicitudesCreateBtn"),
            getBtn: document.getElementById("solicitudesGetBtn"),
            getByEstadoBtn: document.getElementById("solicitudesGetByEstadoBtn"),
            updateBtn: document.getElementById("solicitudesUpdateBtn"),
            deleteBtn: document.getElementById("solicitudesDeleteBtn"),
        },
    };

    // Add event listeners to the Btns
    layout.login.loginBtn.addEventListener('click', API.login, false);

    layout.personas.createBtn.addEventListener('click', API.personas.create, false);

});

