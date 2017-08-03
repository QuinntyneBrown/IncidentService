import { Component } from "@angular/core";
import { IncidentsService } from "./incidents.service";
import { Router } from "@angular/router";
import { toPageListFromInMemory, IPagedList } from "../shared/components/pager.component";

@Component({
    templateUrl: "./incidents-list-page.component.html",
    styleUrls: [
        "../../styles/forms.css",
        "./incidents-list-page.component.css"
    ],
    selector: "ce-incidents-list-page"
})
export class IncidentsListPageComponent {
    constructor(
        private _indcidentsService: IncidentsService,
        private _router: Router
    ) {
        this.pagedList = toPageListFromInMemory([], this.pageNumber, this.pageSize);
    }

    ngOnInit() {
        this._indcidentsService.get().subscribe(incidents => {  
            this.incidents = incidents;          
            this.pagedList = toPageListFromInMemory(incidents, this.pageNumber, this.pageSize);               
        });     
    }

    public pageNumber: any = 1;
    public pageSize: any = 5;

    public pagedList: IPagedList<any>;
    public incidents: Array<any> = [];
    
    public tryToDelete($event) {        
        this._indcidentsService.remove({ id: $event.detail.incident.id })
            .subscribe(() => {
                this._indcidentsService.get().subscribe(incidents => {
                    this.incidents = incidents;
                    this.pagedList = toPageListFromInMemory(this.filteredIncidents, this.pageNumber, this.pageSize);
                });
            });
    }
    
    public tryToEdit($event) {
        this._router
            .navigate(["incidents", $event.detail.incident.id]);
    }

    public handleIncidentsFilterKeyUp($event) {
        this.filterTerm = $event.detail.value;        
        this.pageNumber = 1;
        this.pagedList = toPageListFromInMemory(this.filteredIncidents, this.pageNumber, this.pageSize);
    }

    public get filteredIncidents() {
        return this.incidents.filter(x => {
            return x.name.indexOf(this.filterTerm) > -1;
        });
    }
    public setPageNumber($event) {
        this.pageNumber = $event.detail.pageNumber;
        this.pagedList = toPageListFromInMemory(this.filteredIncidents, this.pageNumber, this.pageSize);
    }     

    public filterTerm: string = "";
}
