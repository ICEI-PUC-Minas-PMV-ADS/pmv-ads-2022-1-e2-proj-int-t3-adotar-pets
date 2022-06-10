import {api} from '../api/client.js';

export const redirectTo = (path = './index.html') => {
    window.location.href = path;
}

export const redirectIfLogged = async (path = './index.html') => {
    try {
        await api.info();
        redirectTo(path);
    } catch (e) {}
}

export const redirectIfNotLogged = async (path = './index.html') => {
    try {
        return await api.info();rt
    } catch (e) {
        redirectTo(path);
    }
}

export const redirectIfRoleIs = async (role, path = './index.html') => {
    try {
        const user = await api.info();
        if (user && user.role !== role) {
            return user;
        }
        redirectTo(path);
    } catch (e) {
        redirectTo(path);
    }
}

export const redirectIfRoleIsNot = async (role, path = './index.html') => {
    try {
        const user = await api.info();
        if (user && user.role === role) {
            return user;
        }
        redirectTo(path);
    } catch (e) {
        redirectTo(path);
    }
}