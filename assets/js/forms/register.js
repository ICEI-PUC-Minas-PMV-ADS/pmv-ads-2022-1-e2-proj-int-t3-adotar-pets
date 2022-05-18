import { setFieldError, Validate } from "./validation.js";
import {mergeDeep} from "../utils.js";
import {Api} from "../api/index.js";

const api = new Api('https://adoptapi.azurewebsites.net/api');

const registerForm = document.querySelector('[data-register]');

const documentMask = IMask(registerForm.querySelector('input[name="document.number"]'), {
    mask: [
        {
            mask: '000.000.000-00',
        },
        {
            mask: '00.000.000/0000-00',
        }
    ]
});

const birthDateMask = IMask(registerForm.querySelector('input[name="user.birthdate"]'), {
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

const zipCodeMask = IMask(registerForm.querySelector('input[name="address.zipcode"]'), {mask: '00000-000'});

const registerSchema = (field) => {
    switch (field.getAttribute('name').toLowerCase()) {
        case 'user.name':
            return new Validate(field).required().min(5).max(50);
        case 'document.number':
            const documentType = documentMask.unmaskedValue.length === 14 ? 'cnpj' : 'cpf';
            return new Validate(field).required().transform(() => documentMask.unmaskedValue).document(documentType);
        case 'user.birthdate':
            return new Validate(field).required().transform(() => {
                const dayMonthYear = birthDateMask.value.split('/');
                const date = [dayMonthYear[2], dayMonthYear[1], dayMonthYear[0]].join('-');
                return date;
            }).regex(/^\d{4}-\d{2}-\d{2}$/, 'Data inválida.');
        case 'address.zipcode':
            return new Validate(field).required().transform(() => zipCodeMask.unmaskedValue).digits(8, 'CEP inválido.');
        case 'user.email':
            return new Validate(field).required().email();
        case 'user.password':
            return new Validate(field).required().min(8);
        case 'password_confirmation':
            return new Validate(field).required().equals(registerForm.querySelector('input[name="user.password"]').value);
        default:
            return;
    }
}

registerForm.addEventListener("submit", async (e) => {
    e.preventDefault();
    let inputs = registerForm.querySelectorAll('input[name], select[name]');
    let errors = false;
    let validatedInputs = {};
    inputs.forEach((input) => {
        try {
            let inputName = input.getAttribute('name');
            let validatedInput = registerSchema(input).getField();
            if (inputName !== 'password_confirmation') {
                mergeDeep(validatedInputs, validatedInput);
            }
        } catch (e) {
            errors = true;
        }
    });
    if (!errors) {
        try {
            const userType = validatedInputs.document.number.length === 14 ? 1 : 0;
            validatedInputs.user.type = userType;
            validatedInputs.document.type = userType;
            const response = await api.register(validatedInputs);
            console.log(response);
        } catch (e) {
            try {
                const error = JSON.parse(e.message);
                if (!error.hasOwnProperty('errors')) {
                    throw e;
                }
                Object.entries(error.errors).forEach(([key, value]) => {
                    setFieldError(registerForm.querySelector(`input[name="${key.toLowerCase()}"]`), value.join(' / '));
                });
            } catch (e) {
                return setFieldError(registerForm.querySelector('input[name="user.email"]'), 'Um erro ocorreu ao registrar.');
            }
        }
    }
});