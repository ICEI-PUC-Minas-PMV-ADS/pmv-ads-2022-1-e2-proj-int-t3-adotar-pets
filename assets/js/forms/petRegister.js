import {redirectIfRoleIsNot} from '../helpers/redirect.js';
import {petAges} from '../helpers/petAge.js';
import {Validate} from './validation.js';
import {mergeDeep} from '../utils.js';

document.addEventListener('DOMContentLoaded', async () => {
    const user = await redirectIfNotLogged('index.html');
    const ageSelect = document.getElementById('idade-pet');
    petAges.forEach(petAge => {
        const option = document.createElement('option');
        option.value = petAge.value;
        option.text = petAge.label;
        ageSelect.insertAdjacentElement('beforeend', option);
    });
    M.FormSelect.init(document.querySelectorAll('select'));
    const registerPetSchema = (field) => {
        switch (field.getAttribute('name').toLowerCase()) {
            case 'pet.name':
                return new Validate(field).required().min(2).max(50);
            case 'pet.birthdate':
                return new Validate(field).requiredSelect();
            case 'pet.type':
                return new Validate(field).requiredSelect();
            case 'pet.gender':
                return new Validate(field).requiredSelect();
            case 'pet.size':
                return new Validate(field).requiredSelect();
            case 'pet.score':
                return new Validate(field).requiredSelect();
            case 'pet.description':
                return new Validate(field).required().min(40).max(400);
            default:
                return;
        }
    }
    const registerPetForm = document.querySelector('[data-register-pet]');
    registerPetForm.addEventListener('submit', async (e) => {
        e.preventDefault();
        let inputs = registerPetForm.querySelectorAll('input[name], select[name], textarea[name]');
        let errors = false;
        let validatedInputs = {};
        inputs.forEach((input) => {
            try {
                let validatedInput = registerPetSchema(input).getField();
                mergeDeep(validatedInputs, validatedInput);
            } catch (e) {
                errors = true;
            }
        });
        if (!errors) {
            console.log(validatedInputs);
        }
    });
});