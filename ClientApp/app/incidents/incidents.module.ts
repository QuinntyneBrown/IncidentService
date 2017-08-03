import { NgModule } from '@angular/core';
import { CommonModule } from "@angular/common";
import { SharedModule } from "../shared";
import { ReactiveFormsModule, FormsModule } from "@angular/forms";

import { IncidentsService} from './incidents.service';
import { IncidentListItemComponent } from "./incident-list-item.component";

const providers = [IncidentsService];

const declarables = [IncidentListItemComponent];

@NgModule({
    imports: [CommonModule, SharedModule, ReactiveFormsModule, FormsModule],
    exports: declarables,
    declarations: declarables,
    providers: providers
})
export class IncidentsModule { }
