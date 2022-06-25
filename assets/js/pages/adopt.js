import {redirectIfNotLogged, redirectTo} from "../helpers/redirect.js";
import {api} from "../api/client.js";
import {setLoading} from '../layout.js';

const buildForm = (progress) => {
    if (progress instanceof Error) {
        if (progress.message.indexOf("Pet não existe ou não está mais ativo.") !== -1) {
            redirectTo('index.html');
        }
        return;
    }
    const percentage = document.querySelector('.progress-fill');
    percentage.style.width = `${progress.percentage}%`;
    const question = document.getElementById('question');
    question.classList.add('hide');
    const {currentQuestion} = progress;
    if (!currentQuestion) {
        redirectTo('questionario-envio.html');
    }
    question.querySelector('[data-title]').textContent = `${progress.totalQuestions - progress.questionsLeft + 1} - ${currentQuestion.title}`;
    const alternatives = document.getElementById('alternatives');
    alternatives.innerHTML = '';
    currentQuestion.alternatives.forEach(alternative => {
        const alternativeDiv = document.createElement('p');
        alternativeDiv.innerHTML = `
            <label>
                <input class="with-gap" value="${alternative.id}" name="alternative" type="radio" class="validate"
                       required="" />
                <span>${alternative.title}</span>
            </label>
        `;
        alternatives.insertAdjacentElement('beforeend', alternativeDiv);
    });
    question.classList.remove('hide');
    setLoading(false);
};

const sendForm = async (petId, alternativeId) => {
    try {
        setLoading(true);
        const formProgress = await api.answerForm(petId, alternativeId);
        buildForm(formProgress);
    } catch (e) {
        buildForm(e);
    }
}

document.addEventListener('DOMContentLoaded', async () => {
    await redirectIfNotLogged();
    const urlParams = new URLSearchParams(window.location.search);
    const petId = urlParams.get('id');
    
    if (!petId) {
        redirectTo('index.html');
    }
    
    const adoptForm = document.querySelector('[data-adopt]');
    adoptForm.addEventListener('submit', async (e) => {
        e.preventDefault();
        const alternativeId = document.getElementById('alternatives').querySelector('input[name=alternative]:checked').value;
        await sendForm(petId, parseInt(alternativeId, 10));
    })
    
    try {
        const formProgress = await api.getFormProgress(petId);
        buildForm(formProgress);
    } catch (e) {
        buildForm(e);
    }
});