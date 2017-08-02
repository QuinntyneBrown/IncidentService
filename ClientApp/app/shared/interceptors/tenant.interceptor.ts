import { Injectable } from "@angular/core";
import { HttpClient, HttpRequest, HttpHandler, HttpEvent, HttpInterceptor } from "@angular/common/http";
import { Observable } from "rxjs/Observable";

@Injectable()
export class TenantInterceptor implements HttpInterceptor {
    intercept(httpRequest: HttpRequest<any>, next: HttpHandler): Observable<HttpEvent<any>> {
        return next.handle(httpRequest.clone({
            headers: httpRequest.headers.set('Tenant', '489902a0-a39d-4556-94b4-544d33d5ff5b')
        }));
    }
}
