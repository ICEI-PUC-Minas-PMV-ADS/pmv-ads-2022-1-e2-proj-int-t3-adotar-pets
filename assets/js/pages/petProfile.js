import {redirectIfRoleIsNot, redirectTo} from '../helpers/redirect.js';
import {getPetAge, getPetGender, getPetSize} from '../helpers/pet.js';
import { mergeDeep } from '../utils.js';
import { api } from '../api/client.js';

document.addEventListener('DOMContentLoaded', async () => {
    await redirectIfRoleIsNot('adopter', 'index.html');
    const urlParams = new URLSearchParams(window.location.search);
    const petId = urlParams.get('id');
    const cardContainer = document.getElementById('profile-pet');
    try {
        const pet = await api.petInfo(petId);
        console.log(pet);
        const card = document.createElement('div');
        card.classList.add('col', 's12', 'cardPerfil');
        card.innerHTML = `
        <div class="slider col s4">
            <ul class="slides">
                ${pet.pictures.map(picture => `
                <li>
                    <img src="${picture.url}" > <!-- random image -->
                </li>
                `).join('')}
            </ul>
        </div>
        <div class="col s8">
            <span id="name-pet" class="fs-40 textcolor-secondary">${pet.name}</span>
        </div>
        <div class="col s8 textcolor-secondary">
            <div>
                <span class="fs-16-b">${getPetAge(pet.birthDate)}</span>
                <span class="fs-20-b">|</span>
                <span class="fs-16-b">${getPetGender(pet.gender)}</span>
                <span class="fs-20-b">|</span>
                <span class="fs-16-b">${getPetSize(pet.size)}</span>
                <span class="fs-20-b">|</span>
                <span class="fs-16-b">Condições: ${pet.needs.map(need => need.name).join(', ')}</span>
            </div>
                
        </div>

        <div class="col s8 mb-24">
            <span class="fs-16 ">${pet.description}</span>
        </div>
         <div class="col s8 pd-none">
            <div class="col s6">
                <a class="col s12 waves-effect amber darken-0 0 btn-perfil btn-large fs-btn" href="questionario.html?id=${pet.id}">Quero adotar</a>
            </div>
            
            <div class="col s6">
                <a class="col s12 waves-effect white btn-perfilpet btn-large fs-btn" href="infoOng.html?id=${pet.userId}">Quero ajudar</a>
            </div>
         </div>
        `;

        cardContainer.insertAdjacentElement('beforeend', card);
        M.Slider.init(document.querySelectorAll('.slider'));
    } catch (e) {
        redirectTo('index.html');
    }
});



