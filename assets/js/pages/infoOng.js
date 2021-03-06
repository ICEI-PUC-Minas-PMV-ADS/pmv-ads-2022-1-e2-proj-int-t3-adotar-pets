import {redirectIfNotLogged} from '../helpers/redirect.js';
import { api } from '../api/client.js';

document.addEventListener('DOMContentLoaded', async () => {
    const user = await redirectIfNotLogged('index.html');

    const urlParams = new URLSearchParams(window.location.search);
    const ongId = urlParams.get('id');

    const ong = await api.ongInfo(ongId);
    M.FormSelect.init(document.querySelectorAll('select'));
    console.log(ong);
    if (ong.picture?.url) {
        document.getElementById('output_image').style.backgroundImage = `url(${ong.picture.url})`;
     }
    
    document.getElementById('name-ong').textContent = ong.name;
    document.getElementById('document').textContent = ong.document.number;
    document.getElementById('zipcode').textContent = ong.address.zipCode;
    document.getElementById('street').textContent = ong.address.name;
    document.getElementById('number').textContent = ong.address.number;
    document.getElementById('city').textContent = ong.address.city;
    document.getElementById('complement').textContent = ong.address.complement;
    
})
