import {redirectIfRoleIsNot} from '../helpers/redirect.js';
import {petAges} from '../helpers/petAge.js';
import {mergeDeep} from '../utils.js';
import {api} from '../api/client.js';

document.addEventListener('DOMContentLoaded', async () => {
    const user = await redirectIfNotLogged('index.html');

    const urlParams = new URLSearchParams(window.location.search);
    const petId= urlParams.get('id');
    
    const pet = await api.petInfo(petId);
    M.FormSelect.init(document.querySelectorAll('select'));
    console.log(pet);

    const petEditForm = document.querySelector('[data-edit-pet]');
    petEditForm.querySelector('[name="pet.name"]').value = pet.name;
    petEditForm.querySelector('[name="pet.description"]').value = pet.description;
    petEditForm.querySelector('[name="pet.birthdate"]').value = pet.birthDate;
    petEditForm.querySelector('[name="pet.minscore"]').value = pet.minScore;
    petEditForm.querySelector('[name="pet.needs"]').value = pet.needs;
    M.updateTextFields();

    
})
const buttonSalvarPet = document.getElementById('btn-salvar-pet');

    buttonSalvarPet.onclick = function(){
         alert("Salvo");

    };  


// import { setFieldError, Validate } from '../../assets/js/forms/validation.js';
// import {api} from '../../assets/js/api/client.js';



// init();

// document.addEventListener("DOMContentLoaded", function () {
//     var elems = document.querySelectorAll("select");
//     var instances = M.FormSelect.init(elems);
//   });
// function init()
// {
//     const urlParams = new URLSearchParams(window.location.search);

//     const parametroId= urlParams.get('id');

//     var pet = await api.petInfo();

//     console.log(pet);

//     const petEditForm = document.querySelector('[data-edit-pet]');
//     petEditForm.querySelector('[name="pet.name"]').value = pet.name;
//     petEditForm.querySelector('[name="pet.description"]').value = pet.description;
//     console.log(pet);
   
//      M.updateTextFields();
   

    

// };

