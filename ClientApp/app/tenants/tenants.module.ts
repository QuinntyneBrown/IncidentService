import { NgModule } from '@angular/core';
import { CommonModule } from "@angular/common";

import { SetTenantFormComponent } from "./set-tenant-form.component";

const declarables = [SetTenantFormComponent];
const providers = [];

@NgModule({
    imports: [CommonModule],
    exports: [declarables],
    declarations: [declarables],
    providers: providers
})
export class TenantsModule { }
