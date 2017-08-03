import { IncidentsService } from "./incidents.service";
import { Router, ActivatedRoute } from "@angular/router";

import {
    Component,
    Input,
    OnInit,
    EventEmitter,
    Output,
    AfterViewInit,
    AfterContentInit,
    Renderer,
    ElementRef,
} from "@angular/core";

import { FormGroup, FormControl, Validators } from "@angular/forms";


@Component({
    templateUrl: "./incidents-edit-page.component.html",
    styleUrls: [
        "../../styles/forms.css",
        "./incidents-edit-page.component.css"
    ],
    selector: "ce-incidents-edit-page"
})
export class IncidentsEditPageComponent {
    constructor(private _indcidentsService: IncidentsService,
        private _router: Router,
        private _activatedRoute: ActivatedRoute
    ) { }

    public ngOnInit() {
        if (this._activatedRoute.snapshot.params["id"]) {
            this._indcidentsService.getById({ id: this._activatedRoute.snapshot.params["id"] })
                .subscribe(response => {                    
                    this.form.patchValue({
                        id: response.incident.id,
                        name: response.incident.name
                    });
                });
        }
    }

    public tryToSave($event) {
        this._indcidentsService.add({ incident: $event.detail.incident })
            .subscribe(() => this._router.navigateByUrl("/"));
    }

    public form = new FormGroup({
        id: new FormControl(0, []),
        name: new FormControl('', [Validators.required])
    });

    public incident: any;

    
}
