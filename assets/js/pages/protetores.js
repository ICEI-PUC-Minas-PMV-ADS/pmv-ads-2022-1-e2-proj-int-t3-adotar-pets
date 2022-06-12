import {redirectIfNotLogged} from '../helpers/redirect.js';

document.addEventListener('DOMContentLoaded', async () => {
    const user = await redirectIfNotLogged('index.html');

    const buttonGerenciarPet = document.getElementById('btn-perfil');

    buttonGerenciarPet.onclick = function(){
        window.location.href = "infoOng.html?id=1"
    };


});
