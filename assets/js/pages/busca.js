import {redirectIfNotLogged} from '../helpers/redirect.js';

document.addEventListener('DOMContentLoaded', async () => {
    const user = await redirectIfNotLogged('index.html');

    document.addEventListener('DOMContentLoaded', function(){
        let petCard = document.getElementById('petCards');
        let pets = await api.searchPet();
        console.log(pets);
        pets.map(pet => {
            let card = `
            <div class="card-pet">
                <div class="col s6 flex-col center-start info"> 
                    <div id="iconePet">
                        <img src="/materialize/img/dog-2.svg" id="foto-dog" alt="">
                        <img src="/materialize/img/cat-1.svg" id="foto-cat" alt="">
                    </div>
                    <div>
                        <span class="fs-20-b textcolor-secondary" id="nome-pet">${pet.name}</span>
                    </div>
                    <div class="textcolor-secondary mb-8">
                        <span id="birthDate-pet" class="fs-14">${pet.birthDate}</span>
                        <span class="fs-14">|</span>
                        <span id="gender-pet" class="fs-14">${pet.gender}</span>
                    </div>
                    <div>
                        <button  id="btn-perfil" class="waves-effect amber darken-0 0 btn-small fs-btn btn-borda fs-14 ">Ver Perfil</button>
                    </div>
                </div>
                <div class="col s6 m6 l6 resizeImg ">
                    <img id="output_image1" width="100%" height="100%">
                </div>
            </div>
        `
        petCard.insertAdjacentHTML('beforeend',card);
        })

        
    })
 
    document.addEventListener('DOMContentLoaded', function() {
        var elems = document.querySelectorAll('select');
        var instances = M.FormSelect.init(elems,);
      });
      
   

    const buttonVerPerfil = document.getElementById('btn-perfil');

    buttonVerPerfil.onclick = function(){
        window.location.href = "perfil-pet.html?id=1"
    };
});


