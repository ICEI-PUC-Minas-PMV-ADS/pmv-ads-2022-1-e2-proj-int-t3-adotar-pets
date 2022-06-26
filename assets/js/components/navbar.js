import {Auth} from '../api/auth.js';

const sideNavElems = document.querySelectorAll('.sidenav');
const dropDownElems = document.querySelectorAll('.dropdown-trigger');
M.Sidenav.init(sideNavElems);
M.Dropdown.init(dropDownElems);

const logout = document.querySelector('[data-logout]');
logout.addEventListener('click', () => {
    Auth.revokeToken();
    location.href = 'index.html';
});
