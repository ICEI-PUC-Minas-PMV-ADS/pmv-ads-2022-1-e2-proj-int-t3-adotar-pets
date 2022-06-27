import {redirectIfRoleIsNot, redirectTo} from '../helpers/redirect.js';
import {petAges, getPetAgeInSeconds} from '../helpers/pet.js';
import {selectItem} from '../helpers/input.js';
import { api } from '../api/client.js';

document.addEventListener('DOMContentLoaded', async () => {
    await redirectIfRoleIsNot('protector', 'index.html');
    const urlParams = new URLSearchParams(window.location.search);
    const petId = urlParams.get('id');
    const ageSelect = document.getElementById('idade-pet');
    petAges.forEach(petAge => {
        const option = document.createElement('option');
        option.value = petAge.value;
        option.text = petAge.label;
        ageSelect.insertAdjacentElement('beforeend', option);
    });
    try {
        const pet = await api.petInfo(petId);
        document.querySelector('input[name=name]').value = pet.name;
        selectItem(document.querySelector('select[name=birthdate]'), String(getPetAgeInSeconds(pet.birthDate)));
        selectItem(document.querySelector('select[name=type]'), String(pet.type));
        selectItem(document.querySelector('select[name=gender]'), String(pet.gender));
        selectItem(document.querySelector('select[name=size]'), String(pet.size));
        selectItem(document.querySelector('select[name=minScore]'), String(pet.minScore));
        selectItem(document.querySelector('select[name=isActive]'), pet.isActive ? '1' : '0');
        document.querySelector('textarea[name=description]').value = pet.description;
        M.updateTextFields();
        M.FormSelect.init(document.querySelectorAll('select'));
        const requests = await api.listAdoptionRequests(petId);
        const requestsTable = document.getElementById('requests');
        requests.forEach(request => {
           const row = document.createElement('div');
           row.innerHTML = `
           <div class="row tableBody">
                <div class="col s1 ">
                    <img src="${request.user.picture?.url ?? ''}" width="40" height="40">
                </div>
                <div class="col s4">${request.user.name}</div>
                <div class="col s3">${new Date(request.createdOn).toLocaleDateString('pt-br')}</div>
                <div class="col s2">${request.totalScore}</div>
                <div class="col s2"><a href="resposta-formulario.html?id=${request.id}" class="waves-effect amber darken-0 0 btn fs-btn right btn-save">Visualizar</a></div>
                <div class="divider"></div>
           </div>
           `;
           requestsTable.insertAdjacentElement('beforeend', row);
        });
    } catch (e) {
        redirectTo('index.html');
    }
});