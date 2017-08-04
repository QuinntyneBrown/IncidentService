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

@Component({
    templateUrl: "./set-tenant-form.component.html",
    styleUrls: ["./set-tenant-form.component.css"],
    selector: "ce-set-tenant-form"
})
export class SetTenantFormComponent { }
