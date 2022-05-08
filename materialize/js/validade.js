const button = document.getElementById('btn-cadastrar')
button.addEventListener('click', (event) => {
    //event.preventDefault()
    const nome = document.getElementById('nome');
    const documento = document.getElementById('documento');
    const celular = document.getElementById('telefone');
    const email = document.getElementById('email');
    const senha = document.getElementById('senha');
    const confirmacao = document.getElementById('confirme');
    
    //console.log(documento.replace(/[^\d]+/g,''))
    if(nome.value === ""){
        errorValidation(nome,"Campo não preenchido");
    }
    else{
        successValidation(nome);
    }
    if(documento.value === ""){
        errorValidation(documento,"Campo não preenchido");
    }
    else{
        validation = documentValidation(documento.value.replace(/[^\d]+/g,''));
        if (validation !== 1){
            successValidation(documento);
        }
    }
    if(celular.value === ""){
        errorValidation(celular,"Campo não preenchido");
    }
    else{
        successValidation(celular);
    }
    if(email.value === ""){
        errorValidation(email,"Campo não preenchido");
    }
    else{
        successValidation(email);
    }
    
    if(senha.value === confirmacao.value & senha.value !== "" & confirmacao.value !== ""){
        successValidation(senha);
        successValidation(confirmacao);
    }
    else{
        errorValidation(senha,"Senhas não conferem");
        errorValidation(confirmacao,"Senhas não conferem");
    }

    if(~senha.value.match(/^(?=.*\d)(?=.*[a-z])(?=.*[A-Z])[0-9a-zA-Z]{8,}$/)){
        errorValidation(senha,"Senhas deve possuir pelo menos um número, uma letra maiúscula e uma letra minúscula");
    }
})

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
        successValidation(documento);
       }
       else{
        errorValidation(documento,'CPF inválido');
        return 1
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
    }
    else{
     errorValidation(documento,'CNPJ inválido');
     return 1;
    }
   }
}