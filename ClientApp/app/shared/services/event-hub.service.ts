import { Injectable } from "@angular/core";
import { Observable } from "rxjs/Observable";
import { BehaviorSubject } from 'rxjs/BehaviorSubject';
import "rxjs/add/observable/fromPromise";
import "rxjs/add/operator/map";
import { Dispatcher } from "./dispatcher";
import { constants } from "../constants/constants";

declare var $: any;

@Injectable()
export class EventHubService {
    private _connection: any;

    constructor(private _dispatcher: Dispatcher<any>) {
        
    }

    public connect(): Promise<any> {
        
        return new Promise((resolve) => {
            this._connection = this._connection || $.hubConnection(constants.HUB_URL);
            
            var eventHub = this._connection.createHubProxy("eventHub");

            eventHub.on("events", (value) => {
                
                this._dispatcher.dispatch(value);
            });

            this._connection.start().done(() => {
                resolve();
            });
        });
    }
}