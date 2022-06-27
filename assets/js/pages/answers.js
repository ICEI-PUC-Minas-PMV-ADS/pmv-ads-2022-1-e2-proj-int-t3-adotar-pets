import {redirectIfRoleIsNot, redirectTo} from '../helpers/redirect.js';
import {petAges, getPetAgeInSeconds} from '../helpers/pet.js';
import {selectItem} from '../helpers/input.js';
import { api } from '../api/client.js';

document.addEventListener('DOMContentLoaded', async () => {
    await redirectIfRoleIsNot('protector', 'index.html');
    const urlParams = new URLSearchParams(window.location.search);
    const formId = urlParams.get('id');
    const answersContainer = document.getElementById('answers');
    try {
        const form = await api.formInfo(formId);
        document.getElementById('pet').innerText = form.pet.name;
        document.getElementById('user').innerText = form.user.name;
        document.getElementById('email').innerText = form.user.email;
        document.getElementById('address').innerText = `${form.user.address.name} / ${form.user.address.city}`;
        document.getElementById('totalscore').innerText = form.totalScore;
        form.answers.forEach((answer, i) => {
            answersContainer.insertAdjacentHTML('beforeend', `
            <span class="fs-20-b  textcolor-secondary">${i + 1} - ${answer.alternative.question.title}</span><br>
            <span class="fs-14">R: ${answer.alternative.title}${answer.penalties > 0 ? ` <i>(-${answer.penalties} pts)</i>` : ''}</span><br>
            `)
        })
    } catch (e) {
        redirectTo('index.html');
    }
});