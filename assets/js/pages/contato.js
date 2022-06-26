import { setFieldError, Validate } from "./validation.js";
import {mergeDeep} from "../utils.js";
import {api} from '../api/client.js';
import {redirectIfLogged} from '../helpers/redirect.js';

redirectIfLogged().then(() => {
    const contactForm = document.querySelector('[data-contact]');

    const contactSchema = (field) => {
        switch (field.getAttribute('name').toLowerCase()) {
            case 'user.email':
                return new Validate(field).required().email();
            case 'user.doubt':
                return new Validate(field).required().min(8);
            default:
                return;
        }
    }

    contactForm.addEventListener('submit', async (e) => {
        e.preventDefault();
        let inputs = contactForm.querySelectorAll('input[name]');
        let errors = false;
        let validatedInputs = {};
        inputs.forEach((input) => {
            try {
                let validatedInput = contactSchema(input).getField();
                mergeDeep(validatedInputs, validatedInput);
            } catch (e) {
                errors = true;
            }
        });
        if (!errors) {
            enviar(validatedInputs)
        }
    });
    async function enviar(validatedInputs){
        const apiUrl = 'user/contact';
      
            try {
      
               const response = await api.enviarContato('user/contact', body, true);
               
               if (!response) {
                  throw response;
               }
      
               alert("Enviado com sucesso!")
      
            } catch (err) {
               //caso falhe, execute isso
               const error = err;
               alert("Ocorreu um erro ao enviar.");
            }
      
        
    }
});
