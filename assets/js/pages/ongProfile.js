import {redirectIfNotLogged} from '../helpers/redirect.js';
import {api} from '../api/client.js';
import {Validate} from '../forms/validation.js';
import {mergeDeep} from '../utils.js';

document.addEventListener('DOMContentLoaded', async () => {
   const user = await redirectIfNotLogged('index.html');
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
      profileForm.querySelector('[name="user.address.zipcode"]').value = user.address.zipCode;
      profileForm.querySelector('[name="user.address.number"]').value = user.address.number;
      profileForm.querySelector('[name="user.address.complement"]').value = user.address.complement;


      M.updateTextFields();


   // teste 
   const registerOngSchema = (field) => {
      switch (field.getAttribute('name').toLowerCase()) {
         case 'user.name':
            return new Validate(field).required();
         case 'user.email':
            return new Validate(field).required().email();
         case 'user.zipcode':
            return new Validate(field).required();   
         case 'user.address.number':
            return new Validate(field).required();  
         case 'user.address.complement':
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
      var validatedInputs ={};
   
      inputs.forEach((input)=>{
         try {
            let validatedInput = registerOngSchema(input).getField();
            mergeDeep(validatedInputs, validatedInput);
         } catch (e) {
            errors = true;
            
         }
         });
         if (!errors){
            alert("receba!")
            console.log(validatedInputs);
         };  
         
      

   });

   
      async function salvar(validatedInputs){
      
            const apiUrl = 'user/profile';
      
            try {
      
               const response = await api.atualizar('user/profile', validatedInputs, true);
               
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
});