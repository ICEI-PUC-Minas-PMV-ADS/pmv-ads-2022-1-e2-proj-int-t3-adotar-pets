const masks = {
    documento(value){
        value = value.replace(/\D/g,"")
        if(value.length<=11){
            value = value.replace(/(\d{3})(\d)/, "$1.$2")
            value = value.replace(/(\d{3})(\d)/, "$1.$2")
            value = value.replace(/(\d{3})(\d{1,2})$/, "$1-$2")
        }
        else{
            value = value.replace(/^(\d{2})(\d)/, "$1.$2")
            value = value.replace(/^(\d{2})\.(\d{3})(\d)/, "$1.$2.$3")
            value = value.replace(/\.(\d{3})(\d)/, ".$1/$2")
            value = value.replace(/(\d{4})(\d)/, "$1-$2")
            value = value.replace(/(-\d{2})\d+?$/,'$1')
        }
        return value
    },
    celular(value){
        value = value.replace(/\D/g,"")
        value = value.replace(/(\d{2})(\d)/,'($1) $2')
        value = value.replace(/(\d{5})(\d)/,'$1-$2')
        value = value.replace(/(-\d{4})\d+?$/,'$1')
        return value
    }
    
}

document.querySelectorAll('input').forEach(($input) => {
    const field = $input.dataset.js

    $input.addEventListener('input', (e) => {
        e.target.value = masks[field](e.target.value)
    },false)
})

