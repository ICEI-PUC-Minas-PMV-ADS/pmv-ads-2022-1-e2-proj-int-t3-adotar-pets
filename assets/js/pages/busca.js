import {redirectIfNotLogged, redirectTo} from '../helpers/redirect.js';
import {api} from '../api/client.js';

document.addEventListener('DOMContentLoaded', async () => {
    
    const user = await redirectIfNotLogged('index.html');
    let bodyCard = document.getElementById('petCards');
    let elems = document.querySelectorAll('select');
    const searchForm = document.querySelector("form[data-search]");



    const urlParams = new URLSearchParams(window.location.search);
    const petType = urlParams.get('type') === null ? '' : urlParams.get('type');
    const petSize = urlParams.get('size') === null ? '' : urlParams.get('size');
    const petAge = urlParams.get('age') === null ? '' : urlParams.get('age');
    const petGender = urlParams.get('gender') === null ? '' : urlParams.get('gender');
    let pets = await api.searchPet(petType,petGender,petSize,petAge); 

    //falta mudar a porra dos combobox, quem teve essa idéia?
    
    searchForm.addEventListener('submit', () => {
        //event.preventDefault();
        elems.forEach(elem => {
           //elem.selectedIndex = petType
           //elem.querySelector('size') = petSize;
           //elem.querySelector('age') = petAge;
           //elem.querySelector('gender') = petGender;
        })
    }); 

    pets.forEach(pet => {
        
        let petName = pet.name
        let image = pet.type === 0 ? '/materialize/img/dog-2.svg' : '/materialize/img/cat-1.svg';
        let gender = pet.gender === 0 ? "Feminino" : "Masculino";
        let ageStatus = ((new Date()-new Date(pet.birthDate))/(1000*60*60*24*365)) <= 1 ? "Filhote" : ((new Date()-new Date(pet['birthDate']))/(1000*60*60*24*365)) > 7 ? "Idoso" : "Adulto"
        let petCard = `
        <div class="col l4 m6 s12">          
            <div class="card-pet">
                <div class="col s6 flex-col center-start info"> 
                    <div id="iconePet">
                        <img src=${image} id="foto-dog" alt="">
                    </div>
                    <div>
                        <span class="fs-20-b textcolor-secondary" id="nome-pet">${petName}</span>
                    </div>
                    <div class="textcolor-secondary mb-8">
                        <span id="birthDate-pet" class="fs-14">${ageStatus}</span>
                        <span class="fs-14">|</span>
                        <span id="gender-pet" class="fs-14">${gender}</span>
                    </div>
                    <div>
                        <button id="btn-perfil" name=${pet.id} class="waves-effect amber darken-0 0 btn-small fs-btn btn-borda fs-14 ">Ver Perfil</button>
                    </div>
                </div>
                <div class="col s6 flex-col center-start info">
                <img src="./materialize/img/petTeste.png" alt="" class="responsive-img">
                </div>
            </div>
        </div>
        `
        bodyCard.insertAdjacentHTML('beforeend',petCard);
        /*
        const buttonVerPerfil = document.getElementById('btn-perfil');
        buttonVerPerfil.onclick = function() {
            window.location.href = `perfil-pet.html?id=${pet["id"]}`
        }
        */
    });

    let buttons = document.querySelectorAll('button[id="btn-perfil"]');
    buttons.forEach(button => {
        button.onclick = function() {
            window.location.href = `perfil-pet.html?id=${button.name}`
        }
    })
});




