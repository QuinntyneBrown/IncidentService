import { Injectable } from "@angular/core";
import { HttpClient } from "@angular/common/http";
import { Incident } from "./incident.model";
import { Observable } from "rxjs";

@Injectable()
export class IncidentsService {
    constructor(private _httpClient: HttpClient) { }

    public add(options: { incident: Incident}) {
        return this._httpClient
            .post(`${this._baseUrl}/api/incidents/add`, { incident: options.incident })            
            .catch(err => {
                return Observable.of(null);
            });
    }

    public get() {
        return this._httpClient
            .get<{ incidents: Array<any> }>(`${this._baseUrl}/api/incidents/get`)
            .map(data => data.incidents)
            .catch(err => {
                return Observable.of(null);
            });
    }

    public getById(options: { id: number }) {
        return this._httpClient
            .get(`${this._baseUrl}/api/incidents/getById?id=${options.id}`)            
            .catch(err => {
                return Observable.of(null);
            });
    }

    public remove(options: { id: number }) {
        return this._httpClient
            .delete(`${this._baseUrl}/api/incidents/remove?id=${options.id}`)
            .catch(err => {
                return Observable.of(null);
            });
    }

    public get _baseUrl() { return ""; }
}
