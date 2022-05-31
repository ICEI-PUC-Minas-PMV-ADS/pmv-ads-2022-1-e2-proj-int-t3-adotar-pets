import { setFieldError, Validate } from '../../assets/js/forms/validation.js';
import {api} from '../../assets/js/api/client.js';

const profileForm = document.querySelector('[data-profile]');

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

// function carregarPerfilAdotante(){


//   var usuarioResponse = {
//     "id": 10,
//     "name": "Testevaldo",
//     "email": "testevaldo@teste.com",
//     "birthDate": "01-01-2000",
//     "document": {
//         "type": 0,
//         "number": "31765554667"
//     },
//     "phone": "33912345678",
//     "address": {
//         "city": "Contagem",
//         "name": "Rua VP-2",
//         "zipCode": "32050080"
//     }
//     }

//     this.usuario = usuarioResponse;


//     var inputNome = document.getElementById("nome");
//     inputNome.value = usuarioResponse.name;

//     var inputDocument = document.getElementById("document");
//     inputDocument.value = usuarioResponse.document.number;
    
//     var inputBirthDate = document.getElementById("birth-date");
//     inputBirthDate.value = usuarioResponse.birthDate;

//     var inputEmail = document.getElementById("email");
//     inputEmail.value = usuarioResponse.email;

//     var inputPhone = document.getElementById("phone");
//     inputPhone.value = usuarioResponse.phone;

//     var inputCep = document.getElementById("cep");
//     inputCep.value = usuarioResponse.address.zipCode;
// }



  
// profileForm.addEventListener("submit", async (event) => {
const buttonSalvarPerfil = document.getElementById('btn-salvar-perfil');
buttonSalvarPerfil.addEventListener('click', async event => {
  
    event.preventDefault();
    
    var erros = false;

    var inputNome = document.getElementById("nome");
    var inputEmail = document.getElementById("email");

    let inputs = profileForm.querySelectorAll('input[name]');
 
    inputs.forEach((input)=>{
        try {

          if(input.id == "nome"){
                let inputNome = new Validate(input).required(); 
          }

          if(input.id == "email"){
              let inputEmail = new Validate(input).required().email();
          }
          
        } catch (e) {
          erros = true;
        }
      });

      if (!erros){
        var body = {
            User: {
                Name: inputNome.value,
                Email: inputEmail.value      
            }
         };

         salvar(body);

      };
    

});

async function salvar(body){

    const apiUrl = 'user/profile';

    try {

        const response = await api.put('user/profile', body, true);
        
        if (!response) {
            throw response;
        }

        alert("Seus dados foram alterados com sucesso!")

    } catch (err) {
        //caso falhe, execute isso
        const error = err;
        alert("Ocorreu um erro ao salvar.");
    }

};
