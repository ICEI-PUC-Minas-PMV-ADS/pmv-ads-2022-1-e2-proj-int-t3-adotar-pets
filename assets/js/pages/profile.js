import { redirectIfNotLogged } from '../helpers/redirect.js';
import { api } from '../api/client.js';
import { setFieldError, Validate } from '../forms/validation.js';


document.addEventListener('DOMContentLoaded', async () => {
   const user = await redirectIfNotLogged('index.html');

   const file = document.getElementById("image-input");

   function addImage() {

      file.click();

      file.addEventListener("change", async (e) => {

         const formData = new FormData();
         formData.append('picture', e.target.files[0], e.target.files[0].name);

         try {
            const { picture } = await api.addProfileImage(formData);
            if (picture?.url) {
               document.getElementById('output_image').style.backgroundImage = `url(${picture.url})`;
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
      const profileForm = document.querySelector('[data-profile]');
      if (user.picture?.url) {
         document.getElementById('output_image').style.backgroundImage = `url(${user.picture.url})`;
      }
      profileForm.querySelector('[name="user.name"]').value = user.name;
      profileForm.querySelector('[name="user.email"]').value = user.email;

      M.updateTextFields();


      //teste

      const buttonSalvarPerfil = document.getElementById('btn-salvar-perfil');
      buttonSalvarPerfil.addEventListener('click', async event => {

         event.preventDefault();

         var erros = false;

         var inputNome = document.getElementById("nome");
         var inputEmail = document.getElementById("email");
         var inputCidade = "Teste cidade";
         var inputRua = "Teste rua";
         var inputCep = "32050080";
         var inputNumero = "123";
         var inputComplemento ="Teste complemento";

         let inputs = profileForm.querySelectorAll('input[name]');

         inputs.forEach((input) => {
            try {

               if (input.id == "nome") {
                  let inputNome = new Validate(input).required();
               }

               if (input.id == "email") {
                  let inputEmail = new Validate(input).required().email();
               }

            } catch (e) {
               erros = true;

            }
         });

         if (!erros) {
            var body = {
               User: {
                  name: inputNome.value,
                  email: inputEmail.value
               },
               Address: {
                  city: inputCidade,
                  name: inputRua,
                  zipCode: inputCep,
                  complement: inputComplemento,
                  number: inputNumero
               }
            }
         };
         
         salvar(body);

      });


   });

   async function salvar(body) {

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

   const passwordForm = document.querySelector('[data-senha]');

   const buttonSalvarSenha = document.getElementById('btn-salvar-senha');

   buttonSalvarSenha.addEventListener('click', async event => {

      event.preventDefault();

      var errorsPasswords = false;

      var currentPassword = document.getElementById("current-password");
      var newPassword = document.getElementById("new-password");
      var confirmPassword = document.getElementById("confirm-password");

      let inputs = passwordForm.querySelectorAll('input[name]');

      inputs.forEach((input) => {
         try {

            if (input.id == "current-password") {
               let currentPassword = new Validate(input).required().min(8);
            }

            if (input.id == "new-password") {
               let newPassword = new Validate(input).required().min(8);
            }

            if (input.id == "confirm-password") {
               let confirmPassword = new Validate(input).required().min(8).equals(newPassword.value);
            }

         } catch (e) {
            errorsPasswords = true;
         }
      });

      if (!errorsPasswords) {

         var bodySenha = {
            currentPassword: currentPassword.value,
            newPassword: newPassword.value,
            confirmPassword: confirmPassword.value
         };

         console.log(bodySenha);
         salvar(bodySenha);
      };

      async function salvar(bodySenha) {

         const apiUrl = 'user/password';

         try {

            const response = await api.atualizarSenha('user/password', bodySenha, true);

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