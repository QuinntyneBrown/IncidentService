import { Component } from "@angular/core";
import { IncidentsService } from "./incidents.service";
import { Router } from "@angular/router";

@Component({
    templateUrl: "./incidents-list-page.component.html",
    styleUrls: ["./incidents-list-page.component.css"],
    selector: "ce-incidents-list-page"
})
export class IncidentsListPageComponent {
    constructor(
        private _indcidentsService: IncidentsService,
        private _router: Router
    ) { }

    ngOnInit() {
        this._indcidentsService.get().subscribe(incidents => this.incidents = incidents);
    }

    public tryToDelete($event) {
        this._indcidentsService.remove({ id: $event.detail.id })
            .subscribe(this.ngOnInit);
    }
    
    public tryToEdit($event) {
        this._router
            .navigate(["incidents", "edit", $event.detail.incident.id]);
    }

    public handleIncidentsFilterKeyUp($event) {

    }

    public setPageNumber() {

    }

    public incidents: Array<any> = [];
}
