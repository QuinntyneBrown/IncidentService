import { NgModule } from '@angular/core';
import { CommonModule } from "@angular/common";

import { HeaderComponent } from './components/header.component';

const declarables = [HeaderComponent];
const providers = [];

@NgModule({
    imports: [CommonModule],
    exports: [declarables],
    declarations: [declarables],
    providers: providers
})
export class SharedModule { }
