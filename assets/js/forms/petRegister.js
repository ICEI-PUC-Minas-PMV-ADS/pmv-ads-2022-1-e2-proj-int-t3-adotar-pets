import {redirectIfRoleIsNot} from '../helpers/redirect.js';
import {petAges} from '../helpers/petAge.js';
import {setFieldError, Validate} from './validation.js';
import {api} from '../api/client.js';

const addImage = (e) => {
    const container = e.target.closest('.resizeImg');
    const placeholder = container.querySelector('[data-output]');
    const input = container.querySelector('input[type=file]');
    input.click();
    input.addEventListener("change", (e) => {
        placeholder.style.backgroundImage = `url(${URL.createObjectURL(e.target.files[0])})`;
    });
}

document.addEventListener('DOMContentLoaded', async () => {
    await redirectIfRoleIsNot('protector', 'index.html');
    const profileInputs = document.querySelectorAll('.imghover');
    profileInputs.forEach(profileInput => profileInput.addEventListener('click', addImage));
    const ageSelect = document.getElementById('idade-pet');
    petAges.forEach(petAge => {
        const option = document.createElement('option');
        option.value = petAge.value;
        option.text = petAge.label;
        ageSelect.insertAdjacentElement('beforeend', option);
    });
    const needsSelect = document.querySelector('select[name=needs]');
    const needs = await api.listNeeds();
    needs.forEach(need => {
        const option = document.createElement('option');
        option.value = need.id;
        option.innerText = need.name;
        needsSelect.insertAdjacentElement('beforeend', option);
    });
    M.FormSelect.init(document.querySelectorAll('select'));
    const registerPetSchema = (field) => {
        switch (field.getAttribute('name').toLowerCase()) {
            case 'name':
                return new Validate(field).required().min(2).max(50);
            case 'birthdate':
                return new Validate(field).requiredSelect().transform((value) => new Date(Date.now() - (value * 1000)).toISOString().split('T')[0]);
            case 'type':
                return new Validate(field).requiredSelect();
            case 'gender':
                return new Validate(field).requiredSelect();
            case 'size':
                return new Validate(field).requiredSelect();
            case 'minscore':
                return new Validate(field).requiredSelect();
            case 'description':
                return new Validate(field).required().min(40).max(400);
            default:
                return;
        }
    }
    const registerPetForm = document.querySelector('[data-register-pet]');
    registerPetForm.addEventListener('submit', async (e) => {
        e.preventDefault();
        let inputs = registerPetForm.querySelectorAll('input[name]:not([type=file]), select[name]:not([name=needs]), textarea[name]');
        let errors = false;
        const validatedInputs = new FormData();
        const files = [];
        profileInputs.forEach(profileInput => {
            const file = profileInput.parentElement.querySelector('input[type=file]').files[0];
            if (file) {
                files.push(file);
            }
        });
        if (!files.length || files.length > 3) {
            alert('O pet deve possuir de 1 a 3 fotos.');
            errors = true;
        }
        inputs.forEach((input) => {
            try {
                let [name, value] = Object.entries(registerPetSchema(input).getField())[0];
                validatedInputs.append(name, value);
            } catch (e) {
                console.log(e);
                errors = true;
            }
        });
        if (!errors) {
            const selectedNeeds = M.FormSelect.getInstance(needsSelect).getSelectedValues();
            selectedNeeds.forEach(need => {
                validatedInputs.append('needs[]', need);
            });
            files.forEach(file => {
                validatedInputs.append('pictures', file);
            })
            try {
                await api.registerPet(validatedInputs);
                location.href = 'gerenciar-pets.html';
            } catch (e) {
                try {
                    const error = JSON.parse(e.message);
                    if (!error.hasOwnProperty('errors')) {
                        throw e;
                    }
                    Object.entries(error.errors).forEach(([key, value]) => {
                        setFieldError(registerPetForm.querySelector(`input[name="${key.toLowerCase()}"]`), value.join(' / '));
                    });
                } catch (e) {
                    return setFieldError(registerPetForm.querySelector('input[name="name"]'), 'Um erro ocorreu ao cadastrar o pet.');
                }
            }
        }
    });
});