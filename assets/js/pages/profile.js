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

});