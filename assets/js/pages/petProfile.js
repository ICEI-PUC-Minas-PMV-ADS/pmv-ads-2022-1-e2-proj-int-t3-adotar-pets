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
    let petGender = "Fêmia";
    let petSize;

    let ageStatus = ((new Date()-new Date(pet.birthDate))/(1000*60*60*24*365)) <= 1 ? "Filhote" : ((new Date()-new Date(pet['birthDate']))/(1000*60*60*24*365)) > 7 ? "Idoso" : "Adulto";
    pet.gender === 0 ? petGender : petGender = "Macho";
    pet.size === 0 ? petSize = "Pequeno" : pet.size === 1 ? petSize = "Médio" : petSize = "Grande";
    
    let condicoes = "";
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

    const buttonGerenciarPet = document.getElementById('btn-ajudar');

    buttonGerenciarPet.onclick = function(){
        window.location.href = `infoOng.html?id=${pet.userId}`
    };



    document.getElementById('name-pet').textContent = pet.name;
    document.getElementById('birthDate-pet').textContent = ageStatus;
    document.getElementById('gender-pet').textContent = petGender;
    document.getElementById('size-pet').textContent = petSize;
    document.getElementById('description-pet').textContent = pet.description;
    document.getElementById('needs-pet').textContent = condicoes;
    document.getElementById('output_image1').style.backgroundImage =  `url(${pet.pictures[0].url})`;
    document.getElementById('output_image2').style.backgroundImage =  `url(${pet.pictures[1].url})`;
    document.getElementById('output_image3').style.backgroundImage =  `url(${pet.pictures[2].url})`;
})



// document.addEventListener('DOMContentLoaded', async () => {
   
    
//     const buttonGerenciarPet = document.getElementById('btn-ajudar');

//     buttonGerenciarPet.onclick = function(){
//         window.location.href = "infoOng.html?id=1"
//     };


// });


document.addEventListener('DOMContentLoaded', function() {
var elems = document.querySelectorAll('.slider');
var instances = M.Slider.init(elems,);
});



