export class Auth {
    
    static getToken() {
        return localStorage.getItem('authToken');
    }
    
    static setToken(token) {
        localStorage.setItem('authToken', token);
    }
    
    static revokeToken() {
        localStorage.removeItem('authToken');
    }
    
}