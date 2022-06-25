import { CommonModule } from '@angular/common';
import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { AppComponent } from './app.component';
import { HttpClientModule } from '@angular/common/http';
import { FormModule } from './components/form/form.module';
import { NgbModule } from '@ng-bootstrap/ng-bootstrap';


@NgModule({
    declarations: [AppComponent],
    imports: [
        BrowserModule,
        CommonModule,
        FormModule,
        HttpClientModule,
        NgbModule,

    ],
    providers: [],
    exports: [],
    bootstrap: [AppComponent],
})
export class AppModule { }
