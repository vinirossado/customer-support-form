import { NgModule } from '@angular/core';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { CommonModule } from '@angular/common';
import { FormComponent } from './form.component';
import { FormService } from '../../services';
import { TextareaAutoresizeDirective } from '../../directives/textarea-autoresize.directive';
import { HttpClientModule } from '@angular/common/http';

@NgModule({
    declarations: [
        FormComponent,
        TextareaAutoresizeDirective,
    ],
    imports: [
        ReactiveFormsModule,
        FormsModule,
        CommonModule,
        HttpClientModule

    ],
    providers: [FormService],
    exports: [FormComponent]

})
export class FormModule { }
