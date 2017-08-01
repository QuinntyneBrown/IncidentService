import { NgModule } from '@angular/core';
import { CommonModule } from "@angular/common";

import { IncidentsComponent } from './incidents.component';

const declarables = [IncidentsComponent];
const providers = [];

@NgModule({
    imports: [CommonModule],
    exports: [declarables],
    declarations: [declarables],
    providers: providers
})
export class IncidentsModule { }
