import {Component, ViewEncapsulation} from "@angular/core";
import { IncidentsService } from "./incidents.service";
import { Router, ActivatedRoute } from "@angular/router";

@Component({
    templateUrl: "./incidents-edit-page.component.html",
    styleUrls: ["./incidents-edit-page.component.css"],
    selector: "ce-incidents-edit-page"
})
export class IncidentsEditPageComponent {
    constructor(private _indcidentsService: IncidentsService) {

    }

    ngOnInit() {

    }
}
