import {redirectIfRoleIsNot} from '../helpers/redirect.js';
import {api} from '../api/client.js';
import {getPetAge, getPetIcon, getPetSize} from '../helpers/pet.js';

document.addEventListener('DOMContentLoaded', async () => {
    await redirectIfRoleIsNot('protector', 'index.html');
    const cardContainer = document.getElementById('pets');
    const pets = await api.listPets();
    pets.forEach(pet => {
        const card = document.createElement('div');
        card.classList.add('col', 's12', 'm6', 'l4');
        card.innerHTML = `<div class="card-pet">
            <div class="col s6 flex-col center-start info"> 
                <div id="iconePet">
                    ${getPetIcon(pet.type)}
                </div>
                <div>
                    <span class="fs-20-b textcolor-secondary">${pet.name}</span>
                </div>
                <div class="textcolor-secondary mb-8">
                   <span class="fs-14">${getPetAge(pet.birthDate)}</span> |
                   <span class="fs-14">${getPetSize(pet.size)}</span>
                </div>
                <div>
                    <a href="edicaopet.html?id=${pet.id}" id="btn-gerenciar" class="waves-effect amber darken-0 0 btn-small fs-btn btn-borda fs-14 ">Gerenciar</a>
                </div>
            </div>
            <div class="col s6 foto-card" style="background-image: url(${pet.pictures?.[0]?.url ?? ''})"></div>
        </div>
        `;
        cardContainer.insertAdjacentElement('beforeend', card);
    });
});