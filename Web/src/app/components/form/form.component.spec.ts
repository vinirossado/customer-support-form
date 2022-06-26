import { ComponentFixture, inject, TestBed, waitForAsync } from '@angular/core/testing';
import { ReactiveFormsModule, FormBuilder } from '@angular/forms';
import { CommonModule } from '@angular/common';
import { FormComponent } from './form.component';
import { AppModule } from 'src/app/app.module';
import { FormService } from 'src/app/services';
import { CustomerSupportModel } from 'src/app/models/customer-support.model';

describe('FormComponent', () => {
    let component: FormComponent;
    let fixture: ComponentFixture<FormComponent>;
    let testBedFormBuilderService: FormBuilder;
    let testBedFormService: FormService;

    const formBuilder: FormBuilder = new FormBuilder();


    beforeEach(
        waitForAsync(() => {
            TestBed.configureTestingModule({
                declarations: [
                    FormComponent
                ],
                imports: [
                    CommonModule,
                    ReactiveFormsModule,
                    AppModule
                ],
                providers: [
                    { provide: FormBuilder, useValue: formBuilder }
                ]
            }).compileComponents();
        })
    );

    beforeEach(() => {
        fixture = TestBed.createComponent(FormComponent);
        component = fixture.componentInstance;
        testBedFormBuilderService = TestBed.inject(FormBuilder);
        testBedFormService = TestBed.inject(FormService);

        component.customerSupportForm = formBuilder.group({
            Email: null,
            Phone: null,
            CustomerNumber: null,
            TypeOfInquiry: 0,
            Description: "",
            AgreementTerms: false,
        });
        fixture.detectChanges();
    });

    it('should create an instance', () => {
        const component = new FormComponent(testBedFormBuilderService, testBedFormService);
        expect(component).toBeTruthy();
    });

    it('FormService injected via inject and TestBed.Inject should be the same instance',
        inject([FormService], (injectService: FormService) => {
            expect(injectService).toBe(testBedFormService);
        }),
    );

    it('FormBuilder injected via inject and TestBed.Inject should be the same instance',
        inject([FormBuilder], (injectService: FormBuilder) => {
            expect(injectService).toBe(testBedFormBuilderService);
        })
    );


    it('capitalizeFirstLetter', () => {
        const example: string = "testcapitalize"
        const stringCapitalized = component.capitalizeFirstLetter(example);
        expect("Testcapitalize").toEqual(stringCapitalized);
    });


    it('should call createObjectToSubmit() and method should return an instance of CustomerSupportModel', () => {
        const formValues = {
            Email: "test@gmail.com",
            Phone: "59036006",
            CustomerNumber: "AR2154",
            TypeOfInquiry: "2",
            Description: "Test description",
            AgreementTerm: true,
        }
        const createdObject = component.createObjectToSubmit(formValues);
        expect(typeof (new CustomerSupportModel("", "", "", 0, "", false))).toEqual(typeof (createdObject))
    });

    it('should be created', () => {
        expect(component).toBeTruthy();
    });
});
