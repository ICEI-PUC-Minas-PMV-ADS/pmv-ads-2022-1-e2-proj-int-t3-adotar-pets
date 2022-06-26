import { setFieldError, Validate } from "./validation.js";
import {mergeDeep} from "../utils.js";
import {api} from '../api/client.js';
import {redirectIfLogged, redirectTo} from '../helpers/redirect.js';

redirectIfLogged().then(() => {
    const loginForm = document.querySelector('[data-login]');

    const loginSchema = (field) => {
        switch (field.getAttribute('name').toLowerCase()) {
            case 'user.email':
                return new Validate(field).required().email();
            case 'user.password':
                return new Validate(field).required().min(8);
            default:
                return;
        }
    }

    loginForm.addEventListener('submit', async (e) => {
        e.preventDefault();
        let inputs = loginForm.querySelectorAll('input[name]');
        let errors = false;
        let validatedInputs = {};
        inputs.forEach((input) => {
            try {
                let validatedInput = loginSchema(input).getField();
                mergeDeep(validatedInputs, validatedInput);
            } catch (e) {
                errors = true;
            }
        });
        if (!errors) {
            try {
                const {user} = await api.login(validatedInputs);
                redirectTo(user.document.type === 0 ? 'busca.html' : 'gerenciar-pets.html');
            } catch (e) {
                try {
                    const error = JSON.parse(e.message);
                    if (!error.hasOwnProperty('errors')) {
                        throw e;
                    }
                    Object.entries(error.errors).forEach(([key, value]) => {
                        setFieldError(loginForm.querySelector(`input[name="${key.toLowerCase()}"]`), value.join(' / '));
                    });
                } catch (e) {
                    return setFieldError(loginForm.querySelector('input[name="email"]'), 'Um erro ocorreu ao fazer login.');
                }
            }
        }
    });
});