const handleLayout = async () => {
    const partials = document.querySelectorAll('[data-partial]');
    let urls = [];
    partials.forEach((partial) => {
        let partialName = partial.getAttribute('data-partial');
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


document.addEventListener('DOMContentLoaded', () => {
    handleLayout();
});

