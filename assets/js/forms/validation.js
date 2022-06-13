const setFieldError = (field, message) => {

    if(field.localName == "select"){
        field.parentElement.parentElement.classList.add('error');
        field.parentElement.parentElement.querySelector('small').innerText = message;
    }else{
       field.parentElement.classList.add('error');
       field.parentElement.querySelector('small').innerText = message; 
    }
}

const convertDotPathToNestedObject = (path, value) => {
    const [last, ...paths] = path.split('.').reverse();
    return paths.reduce((acc, el) => ({ [el]: acc }), { [last]: value });
}

const Validate = (function () {

    let field;
    let fieldValue;

    function error(message) {
        setFieldError(field, message);
        throw new Error(JSON.stringify({ field: field.getAttribute('name'), message }));
    }

    function Validate(fieldToValidate) {

        if(fieldToValidate.localName == "select"){          
            fieldToValidate.parentElement.parentElement.classList.remove('error');
            fieldToValidate.parentElement.parentElement.querySelector('small').innerText = '';
        }else{      
            fieldToValidate.parentElement.classList.remove('error');
            fieldToValidate.parentElement.querySelector('small').innerText = '';
        }
        
        field = fieldToValidate;
        fieldValue = field.value;
    }

    Validate.prototype.required = function (message = null) {
        if (fieldValue.trim() === '') {
            error(message ?? 'Preencha este campo.');
        }
        return this;
    }

    Validate.prototype.requiredSelect = function (message = null) {
        if (fieldValue.trim() === '') {
            error(message ?? 'Selecione uma opção');
        }
        return this;
    }

    Validate.prototype.requiredMultiSelect = function (message = null) {

        var opcoes =  Array.from(field.options);

        var opcoesSelecionadas = [];

        opcoes.forEach((opcao)=>{

            if(opcao.selected && opcao.value != "0")
            opcoesSelecionadas.push(opcao.value);

        });

        if(opcoesSelecionadas.length == 0)
        {
            error(message ?? 'Preencha este campo.');
        }

        return this;
    }

    Validate.prototype.email = function (message = null) {
        const re = /^(([^<>()[\]\\.,;:\s@"]+(\.[^<>()[\]\\.,;:\s@"]+)*)|(".+"))@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\])|(([a-zA-Z\-0-9]+\.)+[a-zA-Z]{2,}))$/;
        if (!re.test(String(fieldValue).toLowerCase())) {
            error(message ?? 'Este campo deve ser um e-mail.');
        }
        return this;
    }

    Validate.prototype.min = function (len, message = null) {
        if (fieldValue.length < len) {
            error(message ?? `O tamanho deve ser maior que ${len}.`);
        }
        return this;
    }

    Validate.prototype.max = function (len, message = null) {
        if (fieldValue.length > len) {
            error(message ?? `O tamanho deve ser menor que ${len}.`);
        }
        return this;
    }

    Validate.prototype.document = function (type, message = null) {
        let errors = false;
        let doc = fieldValue;
        switch (type.toLowerCase()) {
            case 'cpf':
                for (let t = 9; t < 11; t++) {
                    let d = 0;
                    let c = 0;
                    for (d, c; c < t; c++) {
                        d += doc[c] * ((t + 1) - c);
                    }
                    d = ((10 * d) % 11) % 10;
                    if (doc[c] != d) {
                        errors = true;
                    }
                }
                break;
            case 'cnpj':
                const match = doc.match(/\d/g);
                const numbers = Array.isArray(match) ? match.map(Number) : [];
                const items = [...new Set(numbers)];
                if (items.length === 1) {
                    errors = true;
                    break;
                }
                const calc = (x) => {
                    const slice = numbers.slice(0, x);
                    let factor = x - 7;
                    let sum = 0;
                    for (let i = x; i >= 1; i--) {
                        const n = slice[x - i];
                        sum += n * factor--;
                        if (factor < 2) factor = 9;
                    }
                    const result = 11 - (sum % 11);
                    return result > 9 ? 0 : result;
                }
                const digits = numbers.slice(12);
                const digit0 = calc(12);
                if (digit0 !== digits[0]) {
                    errors = true;
                    break;
                }
                const digit1 = calc(13);
                if (digit1 !== digits[1]) {
                    errors = true;
                }
                break;
            default:
                errors = true;
        }
        if (errors) {
            error(message ?? `Documento inválido.`);
        }
        return this;
    }

    Validate.prototype.regex = function (regex, message = null) {
        if(!regex.test(fieldValue)){
            error(message ?? `Campo inválido`);
        }
        return this;
    }

    Validate.prototype.equals = function (value, message = null) {
        if (fieldValue !== value) {
            error(message ?? `Campo não coincide.`);
        }
        return this;
    }

    Validate.prototype.digits = function (len, message) {
        const re = new RegExp(`\\d{${len}}`);
        if (!re.test(fieldValue)) {
            error(message ?? `Este campo precisa ter ${len} dígitos.`);
        }
        return this;
    }

    Validate.prototype.transform = function (newValueCallback) {
        let newValue = newValueCallback(fieldValue);
        fieldValue = newValue;
        return this;
    }

    Validate.prototype.ensure = function (testFunction, message) {
        let test = Boolean(testFunction(fieldValue));
        if (!test) {
            error(message ?? `Campo inválido.`);
        }
        return this;
    }

    Validate.prototype.getField = function () {
        return convertDotPathToNestedObject(field.getAttribute('name'), fieldValue);
    }

    return Validate;

}());

export { Validate, setFieldError };