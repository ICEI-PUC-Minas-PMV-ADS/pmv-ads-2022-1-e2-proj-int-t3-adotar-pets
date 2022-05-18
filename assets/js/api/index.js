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
        return this.#post('auth/login', credentials);
    }
    
    async info() {
        return this.#get('user', true);
    }
    
}