import { HttpErrorResponse } from '@angular/common/http';
import {
    Component,
    OnDestroy,
    OnInit,
} from '@angular/core';
import { FormBuilder, FormGroup, ValidationErrors, Validators } from '@angular/forms';
import { Subscription } from 'rxjs';
import { CustomerSupportModel } from 'src/app/models/customer-support.model';
import { FormService } from 'src/app/services';
declare var page: any;

@Component({
    selector: 'app-form',
    templateUrl: './form.component.html',
    styleUrls: ['./form.component.scss']
})

export class FormComponent implements OnInit, OnDestroy {
    customerSupportForm: FormGroup;
    emailRegexPattern = /^(([^<>()\[\]\\.,;:\s@"]+(\.[^<>()\[\]\\.,;:\s@"]+)*)|(".+"))@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\])|(([a-zA-Z\-0-9]+\.)+[a-zA-Z]{2,}))$/;
    propertiesForm: Set<string> = new Set<string>();
    subscription: Subscription = new Subscription();

    typesOfInquiry = [
        {
            key: 0,
            description: "Service"
        },

        {
            key: 1,
            description: "Technical Problems"
        },

        {
            key: 2,
            description: "Others"
        },

    ]

    constructor(private _formBuilder: FormBuilder, private _formService: FormService) {
        page = this;

        this.customerSupportForm = this._formBuilder.group({
            Email: [null, [Validators.required]],
            Phone: [null, [Validators.required]],
            CustomerNumber: [null],
            TypeOfInquiry: [0, [Validators.required]],
            Description: ["", [Validators.required]],
            AgreementTerms: [false, [Validators.required]],
        });

    }

    ngOnDestroy(): void {
        this.subscription.unsubscribe();
    }

    ngOnInit(): void {
        Object.keys(this.customerSupportForm.controls).forEach(property => {
            this.propertiesForm.add(this.capitalizeFirstLetter(property));
        });
    }

    hasError(propertyForm: string): ValidationErrors | null {
        if (this.customerSupportForm.controls[propertyForm].errors == null)
            return null;
        return this.customerSupportForm.controls[propertyForm].errors![propertyForm];
    }

    submit() {
        const formValue = this.customerSupportForm.value;
        var model = new CustomerSupportModel(
            formValue.Email,
            formValue.Phone,
            formValue.CustomerNumber,
            formValue.TypeOfInquiry,
            formValue.Description,
            formValue.AgreementTerms
        );
        this.subscription.add(this._formService.createTicket(model)
            .subscribe((ret: CustomerSupportModel) => console.log(ret),
                (fallback: HttpErrorResponse) => {
                    const errorProperty = fallback.error.errors;
                    this.propertiesForm.forEach((propertyForm: string) => {
                        if (errorProperty.hasOwnProperty(propertyForm)) {
                            this.customerSupportForm.controls[propertyForm].setErrors({ [propertyForm]: errorProperty[propertyForm] })
                        }
                    });
                }))
    }

    capitalizeFirstLetter(property: string) {
        return property.charAt(0).toUpperCase() + property.slice(1);
    }

}
