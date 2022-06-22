import {redirectIfRoleIsNot} from '../helpers/redirect.js';
import {api} from '../api/client.js';

document.addEventListener('DOMContentLoaded', async () => {
    await redirectIfRoleIsNot('protector', 'index.html');
    const pets = await api.listPets();
    console.log(pets);
});