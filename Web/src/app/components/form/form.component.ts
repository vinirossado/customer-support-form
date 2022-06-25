import { HttpErrorResponse } from '@angular/common/http';
import {
    Component,
    OnDestroy,
    OnInit,
} from '@angular/core';
import { FormBuilder, FormGroup, ValidationErrors, Validators } from '@angular/forms';
import { BehaviorSubject, Observable, Subscription } from 'rxjs';
import { CustomerSupportModel } from 'src/app/models/customer-support.model';
import { FormService } from 'src/app/services';

@Component({
    selector: 'app-form',
    templateUrl: './form.component.html',
    styleUrls: ['./form.component.scss']
})

export class FormComponent implements OnInit, OnDestroy {
    private isLoading: BehaviorSubject<boolean>;
    emailRegexPattern = /^(([^<>()\[\]\\.,;:\s@"]+(\.[^<>()\[\]\\.,;:\s@"]+)*)|(".+"))@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\])|(([a-zA-Z\-0-9]+\.)+[a-zA-Z]{2,}))$/;

    alertState: boolean = false;
    alertMessage: string = "";

    customerSupportForm: FormGroup;
    propertiesForm: Set<string> = new Set<string>();
    subscription: Subscription = new Subscription();
    loading$!: Observable<boolean>;
    readonly customerSupportFormInitialState!: FormGroup;

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

        this.customerSupportForm = this._formBuilder.group({
            Email: [null, [Validators.required]],
            Phone: [null, [Validators.required]],
            CustomerNumber: [null],
            TypeOfInquiry: [0, [Validators.required]],
            Description: ["", [Validators.required]],
            AgreementTerms: [false, [Validators.required]],
        });

        this.customerSupportFormInitialState = this.customerSupportForm.value;
        this.isLoading = new BehaviorSubject<boolean>(false);
        this.loading$ = this.isLoading.asObservable();

    }

    ngOnDestroy(): void {
        this.subscription.unsubscribe();
        this.isLoading.complete();
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

    createObjectToSubmit(formValues: any): CustomerSupportModel {
        return new CustomerSupportModel(
            formValues.Email,
            formValues.Phone,
            formValues.CustomerNumber,
            formValues.TypeOfInquiry,
            formValues.Description,
            formValues.AgreementTerms
        );
    }

    handleAlert(state: boolean, message: string) {
        this.alertState = state;
        this.alertMessage = message;
    }

    submit() {
        this.isLoading.next(true);

        const model = this.createObjectToSubmit(this.customerSupportForm.value);

        this.subscription.add(
            this._formService.createTicket(model)
                .subscribe({
                    next: (_: CustomerSupportModel) => {
                        this.customerSupportForm.reset(this.customerSupportFormInitialState);
                        this.handleAlert(true, "Thank you for contact us.");
                        this.setTimoutHideAlert();

                    },
                    error: (fallback: HttpErrorResponse) => {
                        const errorProperty = fallback.error.errors;
                        this.propertiesForm.forEach((propertyForm: string) => {
                            if (errorProperty.hasOwnProperty(propertyForm)) {
                                this.customerSupportForm.controls[propertyForm].setErrors({ [propertyForm]: errorProperty[propertyForm] });
                            }
                        });
                        this.handleAlert(true, "Try again later");
                        this.setTimoutHideAlert();
                    },
                    complete: () => {

                        this.isLoading.next(false);

                    }
                }));
    }

    setTimoutHideAlert(){
        setTimeout(() => {
            this.alertState = false;
        }, 2000);
    }


    capitalizeFirstLetter(property: string) {
        return property.charAt(0).toUpperCase() + property.slice(1);
    }

}
