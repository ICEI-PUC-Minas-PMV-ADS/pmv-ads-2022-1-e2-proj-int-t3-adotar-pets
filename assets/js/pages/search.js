import {redirectIfRoleIsNot} from '../helpers/redirect.js';
import {api} from '../api/client.js';
import {getPetAge, getPetIcon, getPetSize} from '../helpers/pet.js';

function selectItem(elem,value)
{
    for(let i = 0; i < elem.options.length; i++)
    {
        elem.options[i].selected = elem.options[i].value === value;
    }
}

document.addEventListener('DOMContentLoaded', async () => {
    await redirectIfRoleIsNot('adopter', 'index.html');
    const cardContainer = document.getElementById('petCards');
    const selectElems = document.querySelectorAll('select');

    const urlParams = new URLSearchParams(window.location.search);
    const petType = urlParams.get('type') ?? null;
    const petSize = urlParams.get('size') ?? null;
    const petAge = urlParams.get('age') ?? null;
    const petGender = urlParams.get('gender') ?? null;
    let pets = await api.searchPet(urlParams.toString());

    selectElems.forEach(elem => {
        switch (elem.name)
        {
            case "type":  
                selectItem(elem, petType);  
                break
            case "size":
                selectItem(elem, petSize); 
                break
            case "age":
                selectItem(elem, petAge); 
                break
            case "gender":
                selectItem(elem, petGender); 
                break
            default:
                break
        }
    });

    M.FormSelect.init(document.querySelectorAll('select'));

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
                    <a href="perfil-pet.html?id=${pet.id}" class="waves-effect amber darken-0 0 btn-small fs-btn btn-borda fs-14 ">Ver perfil</a>
                </div>
            </div>
            <div class="col s6 foto-card" style="background-image: url(${pet.pictures?.[0]?.url ?? ''})"></div>
        </div>
        `;
        cardContainer.insertAdjacentElement('afterbegin', card);
    });
});




