import {Component, ViewEncapsulation} from "@angular/core";
import { IncidentsService } from "./incidents.service";
import { Router } from "@angular/router";

@Component({
    templateUrl: "./incidents-list-page.component.html",
    styleUrls: ["./incidents-list-page.component.css"],
    selector: "ce-incidents-list-page"
})
export class IncidentsListPageComponent {
    constructor(private _indcidentsService: IncidentsService) {

    }

    ngOnInit() {

    }
}
