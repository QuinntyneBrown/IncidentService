import {Routes, RouterModule} from '@angular/router';
import {IncidentsEditPageComponent,IncidentsListPageComponent} from "./incidents";
import {SetTenantPageComponent} from "./tenants";
import {TenantGuardService} from "./shared/guards/tenant-guard.service";

export const routes: Routes = [
    {
        path: '',
        component: IncidentsListPageComponent,
        pathMatch: "full",
        canActivate: [TenantGuardService]
    },
    {
        path: 'incidents/create',
        component: IncidentsEditPageComponent,
        canActivate: [TenantGuardService]
    },
    {
        path: 'incidents/:id',
        component: IncidentsEditPageComponent,
        canActivate: [TenantGuardService]
    },
    {
        path: 'tenants/set',
        component: SetTenantPageComponent,
        canActivate: [TenantGuardService]
    }
];

export const RoutingModule = RouterModule.forRoot([
    ...routes
]);

export const routedComponents = [
    IncidentsListPageComponent,
    IncidentsEditPageComponent,
    SetTenantPageComponent
];