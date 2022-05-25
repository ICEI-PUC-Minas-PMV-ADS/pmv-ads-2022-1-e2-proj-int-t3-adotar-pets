import {Auth} from "./auth.js";

export class Api {
    
    #baseUrl;
    
    constructor(baseUrl) {
        this.#baseUrl = baseUrl;
    }
    
    #getEndpoint(endpoint) {
        return `${this.#baseUrl}/${endpoint}`;
    }
    
    static #baseHeaders() {
        return new Headers({
            'Content-Type': 'application/json',
        });
    }
    
    static #withBearer(headers, token) {
        if (!(headers instanceof Headers)) {
            throw new Error('Cabeçalho não fornecido.');
        }
        headers.append('Authorization', `Bearer ${token}`);
    }
    
    static async #getJsonResponse(request) {
        if (!(request instanceof Request)) {
            throw new Error('Requisição não fornecida.');
        }
        const response = await fetch(request);
        const json = await response.json();
        if (!response.ok) {
            throw new Error(JSON.stringify(json));
        }
        return json;
    }
    
    static #buildRequest(endpoint, method, useToken = false, data = null) {
        const headers = Api.#baseHeaders();
        if (useToken) {
            Api.#withBearer(headers, Auth.getToken());
        }
        const options = {method, headers};
        if (data) {
            options.body = JSON.stringify(data);
        }
        return new Request(endpoint, options);
    }
    
    async #get(endpoint, withToken = false) {
        const request = Api.#buildRequest(this.#getEndpoint(endpoint), 'GET', withToken);
        return await Api.#getJsonResponse(request);
    }

    async #post(endpoint, data = {}, withToken = false) {
        const request = Api.#buildRequest(this.#getEndpoint(endpoint), 'POST', withToken, data);
        return await Api.#getJsonResponse(request);
    }
    
    async register(userInfo) {
        return this.#post('auth/register', userInfo);
    }
    
    async login(credentials) {
        try {
            const user = await this.#post('auth/login', credentials);
            Auth.setToken(user.token);
            return user;
        } catch (e) {
            throw e;
        }
    }
    
    async info() {
        try {
            const user = await this.#get('user/profile', true);
            user.role = user.document.type === 0 ? 'adopter' : 'protector';
            return user;
        } catch (e) {
            throw e;
        }
    }
    
}