import {redirectIfNotLogged} from '../helpers/redirect.js';

redirectIfNotLogged().then(() => {
   console.log('Tamo logado.'); 
});