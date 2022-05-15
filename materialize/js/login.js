const button = document.getElementById('btn-entrar')
button.addEventListener('click', ()=>{
  let inputSenha = document.querySelector('#senha')
  
  if(inputSenha.getAttribute('type') == 'password'){
    inputSenha.setAttribute('type', 'text')
  } else {
    inputSenha.setAttribute('type', 'password')
  }
})

function entrar(){
  let email = document.querySelector('#email')
  let emailLabel = document.querySelector('#emailLabel')
  
  let senha = document.querySelector('#senha')
  let senhaLabel = document.querySelector('#senhaLabel')
  
  let form = document.querySelector('form')
  let listaUser = []
  
  let userValid = {
    email: '',
    senha: ''
  }
  
  listaUser = JSON.parse(localStorage.getItem(''))
  
  listaUser.forEach((item) => {
    if(email.value == item.userCad && senha.value == item.senhaCad){
       
      userValid = {
         email: item.nomeCad,
         senha: item.senhaCad
       }
      
    }
  })
   
  if(email.value == userValid.user && senha.value == userValid.senha){
    window.location.href = pmv-ads-2022-1-e2-proj-int-t3-adotar-pets/busca.html
    
    let mathRandom = Math.random().toString(16).substr(2)
    let token = mathRandom + mathRandom
    
    localStorage.setItem('token', token)
    localStorage.setItem('userLogado', JSON.stringify(userValid))
  } else {
    emailLabel.setAttribute('style', 'color: red')
    email.setAttribute('style', 'border-color: red')
    senhaLabel.setAttribute('style', 'color: red')
    senha.setAttribute('style', 'border-color: red')
    form.setAttribute('style', 'display: block')
    form.innerHTML = 'Usuário ou senha incorretos'
    email.focus()
  }
  
}

