import {redirectIfRoleIsNot} from '../helpers/redirect.js';

document.addEventListener('DOMContentLoaded', async () => {
    const user = await redirectIfNotLogged('index.html');

const buttonSalvarPerfil = document.getElementById('btn-enviar');
buttonSalvarPerfil.addEventListener('click', async event => {
    alert("Enviado com sucesso!");
});
});