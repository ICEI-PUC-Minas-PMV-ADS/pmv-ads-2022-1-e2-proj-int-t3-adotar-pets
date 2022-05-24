import {api} from '../api/client.js';

export const redirectTo = (path = './index.html') => {
    window.location.href = path;
}

export const redirectIfLogged = async (path = './index.html') => {
    try {
        await api.info();
        redirectTo(path);
    } catch (e) {
        return;
    }
}

export const redirectIfNotLogged = async (path = './index.html') => {
    try {
        await api.info();
    } catch (e) {
        redirectTo(path);
    }
}

export const redirectIfRoleIs = async (role, path = './index.html') => {
    const user = await auth.getUser();
    if (user && user.role !== role) {
        return;
    }
    redirectTo(path);
}

export const redirectIfRoleIsNot = async (role, path = './index.html') => {
    const user = await auth.getUser();
    if (user && user.role === role) {
        return;
    }
    redirectTo(path);
}