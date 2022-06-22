import {redirectIfRoleIsNot} from '../helpers/redirect.js';
import {petAges} from '../helpers/pet.js';
import {mergeDeep} from '../utils.js';
import {api} from '../api/client.js';
import {Validate} from '../forms/validation.js';

document.addEventListener('DOMContentLoaded', async () => {
    const user = await redirectIfRoleIsNot('protector', 'index.html');
    const ageSelect = document.getElementById('idade-pet');
    petAges.forEach(petAge => {
        const option = document.createElement('option');
        option.value = petAge.value;
        option.text = petAge.label;
        ageSelect.insertAdjacentElement('beforeend', option);
    });


    M.FormSelect.init(document.querySelectorAll('select'));

    const urlParams = new URLSearchParams(window.location.search);
    const petId= urlParams.get('id');
    
    const pet = await api.petInfo(petId);

    
    console.log(pet);

    
    const petEditForm = document.querySelector('[data-edit-pet]');
    
//    document.getElementById("quarenta").setAttribute("selected", "selected");

    petEditForm.querySelector('[name="pet.name"]').value = pet.name;
    petEditForm.querySelector('[name="pet.birthdate"]').value = pet.birthDate;
    petEditForm.querySelector('[name="pet.needs"]').value = pet.needs;
    petEditForm.querySelector('[name="pet.score"]').value = pet.minScore;
    petEditForm.querySelector('[name="pet.description"]').value = pet.description;

    M.updateTextFields();

    const editPetSchema = (field) => {
        switch (field.getAttribute('name').toLowerCase()) {
            case 'pet.name':
                return new Validate(field).required().min(2).max(50);
            case 'pet.birthdate':
                return new Validate(field).requiredSelect().transform((value) => new Date(Date.now() - (value * 1000)).toISOString().split('T')[0]);
            case 'pet.score':
                return new Validate(field).requiredSelect();
                case 'pet.needs':
                return new Validate(field).requiredSelect();
            case 'pet.description':
                return new Validate(field).required().min(1).max(400);
            default:
                return;
        }
    }

   petEditForm.addEventListener('submit', async (e) => {
        e.preventDefault();
        let inputs = petEditForm.querySelectorAll('input[name], select[name], textarea[name]');
        let errors = false;
        let body = {};
        inputs.forEach((input) => {
            try {
                let validatedInput = editPetSchema(input).getField();
                mergeDeep(body, validatedInput);
            } catch (e) {
                errors = true;
            }
        });
      
        if (!errors) {
            console.log(body);
        }
    });
    

})

