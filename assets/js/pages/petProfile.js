import { redirectIfRoleIsNot } from '../helpers/redirect.js';
import { petAges } from '../helpers/petAge.js';
import { mergeDeep } from '../utils.js';
import { api } from '../api/client.js';

document.addEventListener('DOMContentLoaded', async () => {
    const user = await redirectIfRoleIsNot('protector');

    const urlParams = new URLSearchParams(window.location.search);
    const petId = urlParams.get('id');

    const pet = await api.petInfo(petId);
    M.FormSelect.init(document.querySelectorAll('select'));
    console.log(pet);

    // const petEditForm = document.querySelector('[data-profilePet]');
    // petEditForm.querySelector('[name="pet.name"]').value = pet.name;
    // petEditForm.querySelector('[name="pet.description"]').value = pet.description;
    // petEditForm.querySelector('[name="pet.birthdate"]').value = pet.birthDate;
    // petEditForm.querySelector('[name="pet.gender"]').value = pet.gender;
    // petEditForm.querySelector('[name="pet.size"]').value = pet.size;
    // petEditForm.querySelector('[name="pet.needs"]').value = pet.needs;
    // M.updateTextFields();

    if (pet.gender = 0) {
        pet.gender = "Macho"
    } else {
        pet.gender = "Fêmea"
    };

    if (pet.size = 0) {
        pet.size = "Pequeno"
    } else if (pet.size = 1) {
        pet.size = "Médio"
    } else {
        pet.size = "Grande"
    };

    switch (pet.needs) {
        case [0]:
            text= "Deficiência Visual";
            break;
        case [1]:
            text= "Deficiência Auditiva";
            break;
        case [2]:
            text= "Deficiência Motora";
            break;
        case [3]:
            text= "Deficiência Transmisível";
            break;
    
            
    }


    document.getElementById('name-pet').textContent = pet.name;
    document.getElementById('birthDate-pet').textContent = pet.birthDate;
    document.getElementById('gender-pet').textContent = pet.gender;
    document.getElementById('size-pet').textContent = pet.size;
    document.getElementById('description-pet').textContent = pet.description;
    document.getElementById('needs-pet').textContent = pet.needs;
})


// const buttonSalvarPet = document.getElementById('btn-salvar-pet');

//     buttonSalvarPet.onclick = function(){
//          alert("Salvo");

//     };  
