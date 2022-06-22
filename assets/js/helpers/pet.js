export const petAges = [
    {
        label: '0-12 meses',
        value: 0,
    },
    {
        label: '1-7 anos',
        value: 31536000,
    },
    {
        label: '7+ anos',
        value: 220924800,
    },
];

export const getPetAge = (birthDate) => {
    birthDate = new Date(`${birthDate}T00:00:00`);
    const seconds = (Date.now() / 1000) - (birthDate.getTime() / 1000);
    return petAges.reverse().find(age => age.value <= seconds).label;
};

export const getPetSize = (size) => {
    switch (size) {
        case 0:
        case '0':
            return 'Pequeno';
        case 1:
        case '1':
            return 'Médio';
        default:
            return 'Grande';
    }
};

export const getPetIcon = (type) => {
    return type === 0 ? '<img src="/materialize/img/dog-2.svg" alt="">' : '<img src="/materialize/img/cat-1.svg" alt="">';
}