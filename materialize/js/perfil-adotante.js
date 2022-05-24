
var file = document.getElementById("image-input");
var imgUsuario ="";

var usuario; 

function inserirImagem(){

    file.click();

    file.addEventListener("change", function(){

    


        const reader = new FileReader();

        reader.addEventListener("load", () => {

            this.imgUsuario = reader.result;
            document.getElementById("output_image").style.backgroundImage = `url(${this.imgUsuario})`;
        });

        reader.readAsDataURL(this.files[0]);

    });
}

function carregarPerfilAdotante(){


  var usuarioResponse = {
    "id": 10,
    "name": "Testevaldo",
    "email": "testevaldo@teste.com",
    "birthDate": "01-01-2000",
    "document": {
        "type": 0,
        "number": "31765554667"
    },
    "phone": "33912345678",
    "address": {
        "city": "Contagem",
        "name": "Rua VP-2",
        "zipCode": "32050080"
    }
    }

    this.usuario = usuarioResponse;


    var inputNome = document.getElementById("nome");
    inputNome.value = usuarioResponse.name;

    var inputDocument = document.getElementById("document");
    inputDocument.value = usuarioResponse.document.number;
    
    var inputBirthDate = document.getElementById("birth-date");
    inputBirthDate.value = usuarioResponse.birthDate;

    var inputEmail = document.getElementById("email");
    inputEmail.value = usuarioResponse.email;

    var inputPhone = document.getElementById("phone");
    inputPhone.value = usuarioResponse.phone;

    var inputCep = document.getElementById("cep");
    inputCep.value = usuarioResponse.address.zipCode;
}



const buttonSalvarPerfil = document.getElementById('btn-salvar-perfil');
buttonSalvarPerfil.addEventListener('click', async event => {
    
    event.preventDefault();

    var inputNome = document.getElementById("nome");
    var inputEmail = document.getElementById("email");
    var erros = 0;

    if (!validationEmpty(inputEmail)){
        erros++
    }
    if (!validationEmpty(inputNome)){
        erros++
    }
    
    if (erros === 0){

        var body = {
            user: {
                name: document.getElementById("nome"),
                email: document.getElementById("email"),
                birthDate: this.usuario.birthDate,
                phone: this.usuario.phone,
                imagem: this.imgUsuario === "" ? this.usuario.imagem : this.imgUsuario 
            },
            document: {
                type: this.usuario.document.type,
                number: this.usuario.document.number,
            },
            address: {
                zipCode: this.usuario.zipCode,
            },

            
        }
    }   
});


async function salvar(body){

    const apiUrl = 'https://adoptapi.azurewebsites.net/api/user';
    const settings = {
        method: 'PUT',
        headers: {
            'Content-type': 'application/json; charset=UTF-8'
        },
        body: JSON.stringify(body),
    };
    try {
        //tente isso

        const response = await fetch(apiUrl, settings);
        
        if (!response.ok) {
            throw response;
        }

        const data = await response.json();

    } catch (err) {
        //caso falhe, execute isso
        const error = await err.json();
        alert("Ocorreu um erro ao salvar.");
    }

}




   
