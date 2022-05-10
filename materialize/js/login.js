const form = document.getElementById('form')
const email = document.getElementById('email')
const senha = document.getElementById('senha')

form.addEventListener('btn-entrar', (e) => {
    e.preventDefault()

    checkInputs()
})


function checkInputs() {

    const emailValue = email.value.trim()
    const senhaValue = senha.value.trim()
    console.log(emailValue)


    if(emailValue === '') {
        // mostrar erro
        // add classe
        setErrorFor(email, 'Preencha esse campo')
    
    } else {
        // adicionar a classe de sucesso
        setSuccessFor(email)
    }
   
    if(senhaValue === '') {
        // mostrar erro
        // add classe
        setErrorFor(senha, 'Preencha esse campo')
    
    } else {
        // adicionar a classe de sucesso
        setSuccessFor(senha)
    }


}
