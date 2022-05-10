const button = document.getElementById('btn-cadastrar')
button.addEventListener('click', (event) => {
    event.preventDefault()
    const nome = document.getElementById('nome');
    const documento = document.getElementById('documento');
    const celular = document.getElementById('telefone');
    const email = document.getElementById('email');
    const senha = document.getElementById('senha');
    const confirmacao = document.getElementById('confirme');
    let auxiliar = 0;
    let arrays = [documento, senha, confirmacao];

    //console.log(documento.replace(/[^\d]+/g,''))

    arrays.forEach(e => {
        
        if(e.value){
            if(e.value.length <= 8){
                if(auxiliar === 0){
                    auxiliar = e;
                }
                else{
                    if(e.value !== auxiliar.value){
                        errorValidation(e,"Senhas não combinam");
                        errorValidation(auxiliar,"Senhas não combinam");
                    }
                    else{
                        if(auxiliar.value.match(/^(?=.*\d)(?=.*[a-z])(?=.*[A-Z])[0-9a-zA-Z]{8,}$/)){
                            successValidation(e);
                            successValidation(auxiliar);                              
                        }
                        else{
                            errorValidation(e,"As senhas devem possuir pelo menos um número, uma letra maiúscula e uma minúscula em sua composição");
                            errorValidation(auxiliar,"As senhas devem possuir pelo menos um número, uma letra maiúscula e uma minúscula em sua composição");
                        }
                    }
                    
                }
            }
            else if(e.value.length === 14){
                console.log(e.value.replace(/[^\d]+/g,'').length)
                documentValidation(e.value.replace(/[^\d]+/g,''));
            }
            else if(e.value.length > 14){
                documentValidation(e.value.replace(/[^\d]+/g,''));
            }
        }
        else{
            errorValidation(e,"Campos não preenchidos");
        }

    });
    if(email.value === ""){
        errorValidation(email,"Campos não preenchidos");
    }
    else{
        successValidation(email);
    }
    if (nome.value === ""){
        errorValidation(nome,"Campos não preenchidos");
    }
    else{
        successValidation(nome);
    }
    if(celular.value === ""){
        errorValidation(celular,"Campos não preenchidos");
    }
    else{
        successValidation(celular);
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
                }
                else{
                    successValidation(documento);
                }
                
            }
            else{
                errorValidation(documento,'CPF inválido');
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
});






