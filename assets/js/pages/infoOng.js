import { redirectIfRoleIsNot } from '../helpers/redirect.js';
import { petAges } from '../helpers/petAge.js';
import { mergeDeep } from '../utils.js';
import { api } from '../api/client.js';

document.addEventListener('DOMContentLoaded', async () => {
    

    const urlParams = new URLSearchParams(window.location.search);
    const ongId = urlParams.get('id');

    const ong = await api.info(ongId);
    M.FormSelect.init(document.querySelectorAll('select'));
    console.log(ong);

    document.getElementById('name-ong').textContent = ong.name;
    document.getElementById('document').textContent = ong.document.number;
    document.getElementById('zipcode').textContent = ong.address.zipCode;
    document.getElementById('street').textContent = ong.address.name;
    document.getElementById('number').textContent = ong.address.number;
    document.getElementById('city').textContent = ong.address.city;
    document.getElementById('output_image1').style.backgroundImage =  `url(${ong.pictures[0].url})`;
})
