import { NgModule } from '@angular/core';
import { CommonModule } from "@angular/common";

import { IncidentsService } from './incidents.service';

const declarables = [];
const providers = [IncidentsService];

@NgModule({
    imports: [CommonModule],
    exports: [declarables],
    declarations: [declarables],
    providers: providers
})
export class IncidentsModule { }
