import apiClient from "./api-client"
interface Entity{
    id:number
}
class HttpService {
    endPoint :string;
    constructor(endPoint:string) {
        this.endPoint = endPoint
    }
    getAll<T>(){
        const controller = new AbortController();
        const request = apiClient.get<T[]>(this.endPoint+"/All/",{signal : controller.signal});
        return {request, cancel:()=> controller.abort()}
    };
    get<T>(id:number){
        const controller = new AbortController();
        const request = apiClient.get<T>(this.endPoint+"/"+id,{signal : controller.signal});
        return {request, cancel:()=> controller.abort()}
    }
    add<T>(entity:T){
        return apiClient.post(this.endPoint+"/create",entity);
    }
    delete(id:number){
        return apiClient.delete(this.endPoint+"/delete/"+id);
    }
    update<T extends Entity>(entity:T){
        return apiClient.put(this.endPoint+"/update",entity);
    }
}
const create = (endPoint:string) => new HttpService(endPoint);
export default create;