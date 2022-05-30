import { setFieldError, Validate } from '../../assets/js/forms/validation.js';





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

// var pet = {
//   Nome: document.getElementById("nome-pet"),
//   Idade: document.getElementById("idade-pet"),
//   Tipo: document.getElementById("tipo-pet"),
//   Genero: document.getElementById("genero-pet"),
//   Porte: document.getElementById("porte-pet"),
//   Condicao: document.getElementById("condicoes-pet"),
//   Descricao: document.getElementById("descricao-pet"),
// }

registerForm.addEventListener("submit", async (e) => {
  e.preventDefault();

  var inputNome = document.getElementById("nome-pet");
  var inputIdade = document.getElementById("idade-pet");
  var inputTipo = document.getElementById("tipo-pet");
  var inputGenero = document.getElementById("genero-pet");
  var inputPorte = document.getElementById("porte-pet");
  var inputCondicoes = document.getElementById("condicoes-pet");
  var inputDescricao = document.getElementById("descricao-pet");

  var erros = false;

  let inputs = registerForm.querySelectorAll('input[name], select[name], textarea[name]');

  inputs.forEach((input)=>{
    try {
      let validatedInputNome = new Validate(input).required();  
    } catch (e) {
      erros = true;
    }
  });

  
  if (!erros){
    alert("chegou aqui")

    var body = {
      user: {
          name: document.getElementById("nome-pet"),
          email: document.getElementById("idade-pet"),
          birthDate: document.getElementById("genero-pet"),
          phone: document.getElementById("porte-pet"),
          condicoes: document.getElementById("condicoes-pet"),
          descricao: document.getElementById("descricao-pet"),
          imagem1: document.getElementById("image-input1"),
          imagem2: document.getElementById("image-input2"),
          imagem3: document.getElementById("image-input3"),
      },    
     }
  };

});


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
