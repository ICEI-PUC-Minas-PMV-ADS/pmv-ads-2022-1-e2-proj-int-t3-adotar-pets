import {redirectIfNotLogged} from '../helpers/redirect.js';
import { petAges } from '../helpers/petAge.js';
import { mergeDeep } from '../utils.js';
import { api } from '../api/client.js';

document.addEventListener('DOMContentLoaded', async () => {
    const user = await redirectIfNotLogged('index.html');

    const urlParams = new URLSearchParams(window.location.search);
    const petId = urlParams.get('id');

    const pet = await api.petInfo(petId);
    M.FormSelect.init(document.querySelectorAll('select'));
    console.log(pet);


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

    var condicoes = "";
    pet.needs.forEach(need => {
        switch (need.id) {
            case 1:
                if(condicoes== ""){
                    condicoes+= "Deficiência Visual"
                }else{
                    condicoes+= ", Deficiência Visual"
                };
                break;
            case 2:
                if(condicoes== ""){
                    condicoes+= "Deficiência Auditiva"
                }else{
                    condicoes+= ", Deficiência Auditiva "
                };
                break;
            case 3:
                 if(condicoes== ""){
                    condicoes+= "Deficiência Motora"
                }else{
                    condicoes+= ", Deficiência Motora "
                };
                break;
            case 4:
                if(condicoes== ""){
                    condicoes+= "Deficiência Transmissível"
                }else{
                    condicoes+= ", Deficiência Transmissível "
                };
                break;          
        }
        
    });
    


    document.getElementById('name-pet').textContent = pet.name;
    document.getElementById('birthDate-pet').textContent = pet.birthDate;
    document.getElementById('gender-pet').textContent = pet.gender;
    document.getElementById('size-pet').textContent = pet.size;
    document.getElementById('description-pet').textContent = pet.description;
    document.getElementById('needs-pet').textContent = condicoes;
    document.getElementById('output_image1').style.backgroundImage =  `url(${pet.pictures[0].url})`;
    document.getElementById('output_image2').style.backgroundImage =  `url(${pet.pictures[1].url})`;
    document.getElementById('output_image3').style.backgroundImage =  `url(${pet.pictures[2].url})`;
})


