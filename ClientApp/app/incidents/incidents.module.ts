import { NgModule } from '@angular/core';
import { CommonModule } from "@angular/common";
import { SharedModule } from "../shared";

import { IncidentsService} from './incidents.service';

const providers = [IncidentsService];

@NgModule({
    imports: [CommonModule, SharedModule],
    providers: providers
})
export class IncidentsModule { }
