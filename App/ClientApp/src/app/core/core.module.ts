import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import {HTTP_INTERCEPTORS, HttpClientModule} from "@angular/common/http";
import {AuthInterceptorService} from "./interceptors/auth-interceptor.service";
import {BrowserModule} from "@angular/platform-browser";
import {RefreshTokenInterceptor} from "./interceptors/refresh-token-interceptor.service";

@NgModule({
  declarations: [
  ],
  imports: [
    CommonModule,
    HttpClientModule,
    BrowserModule
  ],
  providers: [
    { provide: HTTP_INTERCEPTORS, useClass: AuthInterceptorService, multi: true },
    { provide: HTTP_INTERCEPTORS, useClass: RefreshTokenInterceptor, multi: true },
  ],
})
export class CoreModule { }
