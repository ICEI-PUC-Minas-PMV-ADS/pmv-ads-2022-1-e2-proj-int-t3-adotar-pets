const button = document.getElementById('btn-cadastrar');
button.addEventListener('click', event => {
    event.preventDefault();
    const fields = document.querySelectorAll("[required]");
    let validacao = [0,0,0,0,0];
    let valAuxiliar = 0;
    let documentType;

    fields.forEach(element => {
        if(element.id === "nome"){
            if(element.value.length < 3){
                errorValidation(element,"Este campo deve ser preenchido com mais que 3 caracteres");
                validacao[0] = 1;
            }
            else{
                valAuxiliar = validationEmpty(element);
                if(valAuxiliar === false){
                    validacao[0] = 1;
                }
            }
        }
        else if(element.id === "documento"){
            if(element.value === ""){
                errorValidation(element,"Campo não preenchido");
                validacao[1] = 1;
            }
            else{
                valAuxiliar,documentType = documentValidation(element.value.replace(/[^\d]+/g,''));
                if(valAuxiliar === false){
                    validacao[1] = 1;
                }
            }            
        }
        else if(element.id === "cep"){
            valAuxiliar = validationEmpty(element);
            if(valAuxiliar === false){
                validacao[2] = 1;
            }
        }
        else if(element.id === "email"){
            if(element.value === ""){
                errorValidation(element,"Campo não preenchido");
                validacao[3] = 1;
            }
            else{
                if(element.value.match(/^(([^<>()[\]\\.,;:\s@"]+(\.[^<>()[\]\\.,;:\s@"]+)*)|(".+"))@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\])|(([a-zA-Z\-0-9]+\.)+[a-zA-Z]{2,}))$/)){
                    successValidation(element);
                }
                else{
                    errorValidation(element,"Esse campo deve ser preenchido por um email");
                    validacao[3] = 1;
                }
            }
        }
        else if(element.id === "senha"){
            let confirmacao = document.getElementById('confirme');
            if(element.value === confirmacao.value & element.value.length >= 8){
                successValidation(element);
            }
            else{
                if(element.value.length < 8){
                    errorValidation(element,"A senha deve possuir um número de caracteres maior que 8");
                    validacao[4] = 1;
                }
                else{
                    errorValidation(element,"As senhas estão diferentes");
                    errorValidation(confirmacao,"As senhas estão diferentes");
                    validacao[4] = 1;
                }
            }
        }
    });
    
    if(sumValidation(validacao) === 0){
        let body = 0
        if (documentType === 0){
            body = {
                "name": document.getElementById("nome").value,
                "email": document.getElementById("email").value,
                "password": document.getElementById("senha").value, //falta a encriptação
                "type": 0,
                "document":{
                    "type": 0,
                    "number": document.getElementById("documento").value.replace(/[^\d]+/g,'')
                },
                "address":{
                    "name":"",
                    "zipCode": document.getElementById("cep").value.replace(/[^\d]+/g,''),
                    "complement": ""
                }
            }
        }
        else{
            body = {
                "name": document.getElementById("nome").value,
                "email": document.getElementById("email").value,
                "password": document.getElementById("senha").value, //Falta a encriptação
                "type": "1",
                "document":{
                    "type": "1",
                    "number": document.getElementById("documento").value.replace(/[^\d]+/g,'')
                },
                "address":{
                    "name":"",
                    "zipCode": document.getElementById("cep").value.replace(/[^\d]+/g,''),
                    "complement": ""
                }
            }
        }
        
        singInUser(body);
    }
});
    

function validationEmpty(input){
    let inputValue = input.value;
    if (inputValue !== ""){
        successValidation(input);
        return true
    }
    else{
        errorValidation(input,"Este campo deve ser preenchido");
        return false
    }
}  

function errorValidation(input,message){
    const formControl = input.parentElement;
    formControl.className = 'label-cadastro error';
    const small = formControl.querySelector('small');
    small.innerText = message;
}

function successValidation(input){
    const formControl = input.parentElement;
    formControl.className = 'label-cadastro sucesso';
}

function documentValidation(input){

    if(input.length === 11){
        let array = [11,10,9,8,7,6,5,4,3,2];
        let validation1 = 0;
        let validation2 = 0;
        let aux1 = 0;
        let aux2 = 0;
        for (i = 1; i<array.length; i++){
            aux1 = aux1 + (array[i]*parseInt(input[i-1]));
        }
        for(j = 0; j<array.length;j++){
            aux2 = aux2 + (array[j]*parseInt(input[j]));
        }
        validation1 = (aux1*10)%11;
        validation2 = (aux2*10)%11;
        
        if(validation1 === parseInt(input[9]) & validation2 === parseInt(input[10])){
            if(input === "00000000000"||input === "11111111111"||input === "22222222222"||input === "33333333333"||input === "44444444444"||
            input === "55555555555"||input === "66666666666"||input === "77777777777"||input === "88888888888"||input === "99999999999"){
                errorValidation(documento,'CPF inválido');
                return false
            }
            else{
                successValidation(documento);
                return true,0
            }
            
        }
        else{
            errorValidation(documento,'CPF inválido');
            return false
        }
        
    }
    else{
     let array = [6,5,4,3,2,9,8,7,6,5,4,3,2];
     let validation1 = 0;
     let validation2 = 0;
     let aux1 = 0;
     let aux2 = 0;
     for (i = 1; i<array.length; i++){
         aux1 = aux1 + (array[i]*parseInt(input[i-1]));
     }
     for(j = 0; j<array.length;j++){
         aux2 = aux2 + (array[j]*parseInt(input[j]));
     }
     validation1 = (aux1*10)%11;
     validation2 = (aux2*10)%11;
 
     if(validation1 === parseInt(input[12]) & validation2 === parseInt(input[13])){
      successValidation(documento);
      return true,1
     }
     else{
      errorValidation(documento,'CNPJ inválido');
      return false;
     }
    }
}

function sumValidation(input){
    let auxiliar = 0;
    input.forEach(element => {
        auxiliar += element;
    });
    return auxiliar;
}

function singInUser(body){
    let url = "https://adoptapi.azurewebsites.net/api/auth/register" //api
    let request = new XMLHttpRequest();
    request.open("POST", url, true);
    request.setRequestHeader("Content-type", "aplication/json")
    request.send(JSON.stringify(body));
    request.onload = function() {
        //console.log(this.responseText)
    }
    return request.responseText
}
