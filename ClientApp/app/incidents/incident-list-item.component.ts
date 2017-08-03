import {Component,Input,Output,EventEmitter} from "@angular/core";

@Component({
    templateUrl: "./incident-list-item.component.html",
    styleUrls: ["./incident-list-item.component.css"],
    selector: "ce-incident-list-item"
})
export class IncidentListItemComponent {   
    constructor() {
        this.edit = new EventEmitter();
        this.delete = new EventEmitter();
    } 
    @Input()
    public incident: any = <any>{};
    
    @Output()
    public edit: EventEmitter<any>;

    @Output()
    public delete: EventEmitter<any>;        
}
