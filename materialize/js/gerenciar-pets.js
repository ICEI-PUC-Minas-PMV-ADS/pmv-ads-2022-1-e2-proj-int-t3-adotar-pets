import {redirectIfRoleIsNot} from '../helpers/redirect.js';

document.addEventListener('DOMContentLoaded', async () => {
    const user = await redirectIfNotLogged('index.html');

const buttonGerenciarPet = document.getElementById('btn-gerenciar');

buttonGerenciarPet.onclick = function(){
    window.location.href = "edicaopet.html?id=1"
};



// buttonGerenciarPet.addEventListener('click', function(){

       


// });

});
