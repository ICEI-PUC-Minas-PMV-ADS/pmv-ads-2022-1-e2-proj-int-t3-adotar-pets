import {redirectIfNotLogged} from '../helpers/redirect.js';

document.addEventListener('DOMContentLoaded', async () => {
    const user = await redirectIfNotLogged('index.html');

 
    document.addEventListener('DOMContentLoaded', function() {
        var elems = document.querySelectorAll('select');
        var instances = M.FormSelect.init(elems,);
      });
      
   

    const buttonVerPerfil = document.getElementById('btn-perfil');

    buttonVerPerfil.onclick = function(){
        window.location.href = "perfil-pet.html?id=1"
    };
});


