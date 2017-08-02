import { NgModule } from '@angular/core';
import { CommonModule } from "@angular/common";
import { HttpClientModule, HTTP_INTERCEPTORS } from "@angular/common/http";

import { HeaderComponent } from './components/header.component';
import { TenantInterceptor } from "./interceptors/tenant.interceptor";

const declarables = [HeaderComponent];

const providers = [{
    provide: HTTP_INTERCEPTORS,
    useClass: TenantInterceptor,
    multi: true,
}];

@NgModule({
    imports: [CommonModule, HttpClientModule],
    exports: [declarables],
    declarations: [declarables],
    providers: providers
})
export class SharedModule { }
