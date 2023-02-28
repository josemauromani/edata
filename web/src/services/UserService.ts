import  http  from 'http-common';
class UserService {
    getAll(): Promise<any> {
        return http.get("/users")
    }

    get(id: any): Promise<any> {
        return http.get(`/users/${id}`)
    }

    create(data: any): Promise<any> {
        return http.post("/user", data)
    }

    update(id: any, data: any): Promise<any> {
        return http.put(`/users/${id}`, data);
    }

    delete(id: any): Promise<any> {
        return http.delete(`/users/${id}`);
    }
}

export default new UserService();