import {redirectIfNotLogged} from '../helpers/redirect.js';

redirectIfNotLogged().then((user) => {
   const profileForm = document.querySelector('[data-profile]');
   profileForm.querySelector('[name="user.name"]').value = user.name;
   profileForm.querySelector('[name="user.email"]').value = user.email;
   M.updateTextFields();
   
   // @TODO: profileSchema
});