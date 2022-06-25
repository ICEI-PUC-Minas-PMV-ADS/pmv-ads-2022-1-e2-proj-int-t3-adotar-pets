import {api} from './api/client.js';

export const setLoading = (status) => {
    if (!status) {
        setTimeout(() => {
            document.getElementById('loading')?.remove();
            document.body.style.overflow = 'scroll';
        }, 500);
        return;
    }
    const loadingEl = document.createElement('div');
    loadingEl.id = 'loading';
    const spinner = document.createElement('div');
    spinner.classList.add('spinner', Math.random() >= 0.5 ? 'dog' : 'cat');
    loadingEl.insertAdjacentElement('beforeend', spinner);
    document.body.insertAdjacentElement('beforebegin', loadingEl);
    document.body.style.overflow = 'hidden';
};

const handleLayout = async () => {
    let loggedUser;
    try {
        loggedUser = await api.info();
    } catch (e) {
        loggedUser = false;
    }
    const partials = document.querySelectorAll('[data-partial]');
    let urls = [];
    partials.forEach((partial) => {
        let partialName = partial.getAttribute('data-partial');
        if (loggedUser && 'role' in loggedUser) {
            switch (loggedUser.role) {
                case 'adopter':
                case 'protector':
                    partialName = partial.getAttribute(`data-${loggedUser.role}`) ?? partialName;
                    break;
            }
        }
        urls.push({
            url:`./components/${partialName}.html`,
            node: partial,
        })
    });
    await Promise.all(urls.map(async ({url, node}) => {
        const res = await fetch(url);
        const contents = await res.text();
        const template = document.createElement('template');
        template.innerHTML = contents;
        const child = template.content.firstChild;
        node.replaceWith(child);
        const scripts = child.querySelectorAll('script');
        scripts.forEach( (script) => {
            const injectedScript = document.createElement("script");
            Array.from(script.attributes).map(attr => {
                injectedScript.setAttribute(attr.name, attr.value);
            })
            injectedScript.appendChild(document.createTextNode(script.innerHTML));
            child.replaceChild(injectedScript, script);
        });
    }));
}

document.addEventListener('DOMContentLoaded', async () => {
    setLoading(true);
    await handleLayout();
    setLoading(false);
});

