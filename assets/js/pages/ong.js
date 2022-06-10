import {redirectIfNotLogged} from '../helpers/redirect.js';
import {api} from '../api/client.js';

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

   M.updateTextFields();
   
   // @TODO: profileSchema
});