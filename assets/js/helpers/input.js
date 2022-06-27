export const selectItem = (elem, value) => {
    for(let i = 0; i < elem.options.length; i++) {
        elem.options[i].selected = elem.options[i].value === value;
    }
}