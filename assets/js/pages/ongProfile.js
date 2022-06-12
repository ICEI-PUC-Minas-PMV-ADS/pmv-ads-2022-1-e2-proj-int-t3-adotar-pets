import {redirectIfNotLogged} from '../helpers/redirect.js';
import {api} from '../api/client.js';
import {Validate} from '../forms/validation.js';
import {mergeDeep} from '../utils.js';

document.addEventListener('DOMContentLoaded', async () => {
   const user = await redirectIfNotLogged('index.html');
   
   const file = document.getElementById("image-input");

   function addImage() {

      file.click();

      file.addEventListener("change", async (e) => {

         const formData = new FormData();
         formData.append('picture', e.target.files[0], e.target.files[0].name);
         
         try {
            const {picture} = await api.addProfileImage(formData);
            if (picture?.url) {
               document.getElementById('output_image').style.backgroundImage =  `url(${picture.url})`;
            }
         } catch (e) {
            try {
               const error = JSON.parse(e.message);
               if (!error.hasOwnProperty('errors')) {
                  throw e;
               }
               if (error.errors?.Picture) {
                  alert(error.errors.Picture[0]);
               }
            } catch (e) {
               alert('Um erro ocorreu ao mudar a foto de perfil.');
            }
         }

      });
   }

   redirectIfNotLogged().then((user) => {
      const profilePictureInput = document.querySelector('.imghover');
      profilePictureInput.addEventListener('click', addImage);
      const profileForm = document.querySelector('[data-ong]');
      if (user.picture?.url) {
         document.getElementById('output_image').style.backgroundImage =  `url(${user.picture.url})`;
      }


      profileForm.querySelector('[name="user.name"]').value = user.name;
      profileForm.querySelector('[name="user.email"]').value = user.email;
      profileForm.querySelector('[name="address.zipcode"]').value = user.address.zipCode;
      profileForm.querySelector('[name="address.number"]').value = user.address.number;
      profileForm.querySelector('[name="address.complement"]').value = user.address.complement;


      M.updateTextFields();


   // teste 
   const registerOngSchema = (field) => {
      switch (field.getAttribute('name').toLowerCase()) {
         case 'user.name':
            return new Validate(field).required();
         case 'user.email':
            return new Validate(field).required().email();
         case 'address.zipcode':
            return new Validate(field).required();   
         case 'address.number':
            return new Validate(field).required();  
         case 'address.complement':
            return new Validate(field).required();
         default:
            return;
      }
   }

  

   const buttonSalvarPerfil = document.getElementById('btn-salvar-perfil');
   buttonSalvarPerfil.addEventListener('click', async event => {
   
      event.preventDefault();


      let inputs = profileForm.querySelectorAll('input[name]');
      var errors = false;
      var body ={};
   
      inputs.forEach((input)=>{
         try {
            let validatedInput = registerOngSchema(input).getField();
            mergeDeep(body, validatedInput);
          
         } catch (e) {
            errors = true;
            
            
         }
         });
         if (!errors){
            salvar(body)
         };  

   });


   
      async function salvar(body){
      
            const apiUrl = 'user/profile';
      
            try {
      
               const response = await api.atualizarPerfil('user/profile', body, true);
               
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

   });
   const passwordForm = document.querySelector('[data-senha]');

   const buttonSalvarSenha = document.getElementById('btn-salvar-senha');
buttonSalvarSenha.addEventListener('click', async event => {
  
    event.preventDefault();
    
    var errorsPasswords = false;

    var currentPassword = document.getElementById("current-password");
    var newPassword = document.getElementById("new-password");
    var confirmPassword = document.getElementById("confirm-password");

    let inputs = passwordForm.querySelectorAll('input[name]');
 
    inputs.forEach((input)=>{
        try {

          if(input.id == "current-password"){
                let currentPassword = new Validate(input).required().min(8); 
          }

          if(input.id == "new-password"){
              let newPassword = new Validate(input).required().min(8);
          }
          
           if(input.id == "confirm-password"){
              let confirmPassword = new Validate(input).required().min(8).equals(newPassword.value);
          }
          
        } catch (e) {
          errorsPasswords = true;
        }
      });

      if (!errorsPasswords){
     
         var bodySenha = {
            currentPassword: currentPassword.value,
            newPassword: newPassword.value,
            confirmPassword:  confirmPassword.value     
         };

         console.log(bodySenha);
         salvar(bodySenha);
      };

      async function salvar(bodySenha){
      
         const apiUrl = 'user/profile/password';
   
         try {
   
            const response = await api.atualizarSenha('user/profile/password', bodySenha, true);
            
            if (!response) {
               throw response;
            }
   
            alert("Sua senha foi alterada com sucesso!")
   
         } catch (err) {
            //caso falhe, execute isso
            const error = err;
            alert("Ocorreu um erro ao alterar sua senha!");
         }
   
   };

});

});