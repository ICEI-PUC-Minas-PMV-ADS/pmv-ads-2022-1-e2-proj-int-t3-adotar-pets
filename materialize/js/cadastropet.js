import { setFieldError, Validate } from '../../assets/js/forms/validation.js';
import {api} from '../../assets/js/api/client.js';

const registerPetForm = document.querySelector('[data-register]');

var file = document.getElementById("image-input");
var imgPet = "";
var pet;

//validações //

const birthDateMask = IMask(registerPetForm.querySelector('input[name="pet.birthdate"]'), {
  mask: Date,
  pattern: 'd/m/Y',
  blocks: {
      d: {
          mask: IMask.MaskedRange,
          from: 1,
          to: 31,
          maxLength: 2,
      },
      m: {
          mask: IMask.MaskedRange,
          from: 1,
          to: 12,
          maxLength: 2,
      },
      Y: {
          mask: IMask.MaskedRange,
          from: 1900,
          to: (new Date()).getFullYear(),
      }
  },
  format: function (date) {
      let day = date.getDate();
      let month = date.getMonth() + 1;
      let year = date.getFullYear();
      if (day < 10) day = "0" + day;
      if (month < 10) month = "0" + month;
      return [day, month, year].join('/');
  },
  parse: function (str) {
      const dayMonthYear = str.split('/');
      return new Date(dayMonthYear[2], dayMonthYear[1] - 1, dayMonthYear[0]);
  },
  autofix: true,
});


const registerForm = document.querySelector('[data-register]');

var file = document.getElementById("image-input");
var imgPet = "";
var pet;

// Funcionar os selects //

document.addEventListener('DOMContentLoaded', function() {
  var elems = document.querySelectorAll('select');
  var instances = M.FormSelect.init(elems,);
});

init();
  
function init(){

  pet = {
    Nome: null,
    Idade: null,
    Tipo: null,
    Genero: null,
    Porte: null,
    Condicao: null,
    Descricao: null,
  };

}



registerPetForm.addEventListener("submit", async (e) => {
  e.preventDefault();

  var erros = false;

  var inputNome = document.getElementById("nome-pet");
  var inputIdade = document.getElementById("idade-pet");
  var inputTipo = document.getElementById("tipo-pet");
  var inputGenero = document.getElementById("genero-pet");
  var inputPorte = document.getElementById("porte-pet");
  var inputPontuacao = document.getElementById("pontuacao-pet")
  var inputDescricao = document.getElementById("descricao-pet");
  var inputCondicoes = document.getElementById("condicoes-pet");

  let inputs = registerPetForm.querySelectorAll('input[name], select[name], textarea[name]');

  
  inputs.forEach((input)=>{
  
    try {
      
      if(input.id == "tipo-pet" || input.id == "genero-pet" || input.id == "porte-pet" || input.id == "pontuacao-pet")
      {
        let selects = new Validate(input).requiredSelect(); 
      }
     
      else
      {
        let inputsSimples = new Validate(input).required();
      }

    } catch (e) {
      erros = true;
    }
  });

  
  if (!erros){

    var opcoes =  Array.from(inputCondicoes.options);

    var opcoesSelecionadas = [];

    opcoes.forEach((opcao)=>{

        if(opcao.selected && opcao.value != "0")
           opcoesSelecionadas.push(opcao.value);

    });

   var body = {

      pet: {
          Name: inputNome.value,
          Type: parseInt(inputTipo.value),
          Gender: parseInt(inputGenero.value),
          BirthDate: inputIdade.value,
          Size: parseInt(inputPorte.value),
          MinScore: parseInt(inputPontuacao.value),
          Needs: opcoesSelecionadas,
          Description: inputDescricao.value
      },    
     }
     salvar(body);
  };
});

async function salvar(body){

  const apiUrl = 'pet/create';
  
  try { 
    console.log(body);  
    const response = await api.cadastrarPet('pet/create', body, true);
        
        if (!response) {
            throw response;
        }

        alert("Pet cadastrado com sucesso!")

  } catch (err) {
    //caso falhe, execute isso
    const error = err;
    alert("Ocorreu um erro no cadastro");
  }
};


function inserirImagem(){      
  file.click();

  file.addEventListener("change", function () {
    const reader = new FileReader();

    reader.addEventListener("load", () => {
      this.imgPet = reader.result;
      document.getElementById("output_image").style.backgroundImage = `url(${imgPet})`;
      pet.imagem1 = imgPet;
    });

    reader.readAsDataURL(this.files[0]);
  });
}

var file2 = document.getElementById("image-input2");
var uploaded_image2 = "";

function inserirImagem2() {
  file2.click();

  file2.addEventListener("change", function () {
    const reader = new FileReader();

    reader.addEventListener("load", () => {
      uploaded_image = reader.result;
      document.getElementById(
        "output_image2"
      ).style.backgroundImage = `url(${uploaded_image})`;
    });

    reader.readAsDataURL(this.files[0]);
  });
}

var file3 = document.getElementById("image-input3");
var uploaded_image3 = "";

function inserirImagem3() {
  file3.click();

  file3.addEventListener("change", function () {
    const reader = new FileReader();

    reader.addEventListener("load", () => {
      uploaded_image = reader.result;
      document.getElementById(
        "output_image3"
      ).style.backgroundImage = `url(${uploaded_image})`;
    });

    reader.readAsDataURL(this.files[0]);
  });
}

document.addEventListener("DOMContentLoaded", function () {
  var elems = document.querySelectorAll("select");
  var instances = M.FormSelect.init(elems);
});
