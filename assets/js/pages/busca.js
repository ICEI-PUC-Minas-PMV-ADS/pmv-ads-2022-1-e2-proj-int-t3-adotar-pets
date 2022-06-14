import {redirectIfNotLogged} from '../helpers/redirect.js';
import {api} from '../api/client.js';

let pets = await api.searchPet(); 
let bodyCard = document.getElementById('petCards');
pets.map(pet => {

    let image = pet['type'] === 0 ? '/materialize/img/dog-2.svg' : '/materialize/img/cat-1.svg';
    let gender = pet['gender'] === 0 ? "Feminino" : "Masculino";
    let ageStatus = ((new Date()-new Date(pet['birthDate']))/(1000*60*60*24*365)) <= 1 ? "Filhote" : ((new Date()-new Date(pet['birthDate']))/(1000*60*60*24*365)) > 7 ? "Senior" : "Adulto"

    let petCard = `
    <div class="col l4 m6 s12">          
        <div class="card-pet">
            <div class="col s6 flex-col center-start info"> 
                <div id="iconePet">
                    <img src=${image} id="foto-dog" alt="">
                </div>
                <div>
                    <span class="fs-20-b textcolor-secondary" id="nome-pet">${pet['name']}</span>
                </div>
                <div class="textcolor-secondary mb-8">
                    <span id="birthDate-pet" class="fs-14">${ageStatus}</span>
                    <span class="fs-14">|</span>
                    <span id="gender-pet" class="fs-14">${gender}</span>
                </div>
                <div>
                    <button  id="btn-perfil" class="waves-effect amber darken-0 0 btn-small fs-btn btn-borda fs-14 ">Ver Perfil</button>
                </div>
            </div>
        </div>
    </div>
    `
    bodyCard.insertAdjacentHTML('afterbegin',petCard);
    });

    /*
 
    document.addEventListener('DOMContentLoaded', function() {
        var elems = document.querySelectorAll('select');
        var instances = M.FormSelect.init(elems,);
      });
      
   

    const buttonVerPerfil = document.getElementById('btn-perfil');

//    buttonVerPerfil.onclick = function(){
//        window.location.href = "perfil-pet.html?id=1"
//    };
});
*/

