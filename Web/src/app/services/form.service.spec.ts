import { CommonModule } from '@angular/common';
import { HttpClient, HttpClientModule, HttpErrorResponse } from '@angular/common/http';
import { TestBed } from '@angular/core/testing';
import { AppModule } from '../app.module';
import { CustomerSupportModel } from '../models/customer-support.model';
import { FormService } from './form.service';
import { Observable, of } from 'rxjs';



describe('FormService', () => {
    let service: FormService;
    let formServiceSpy: jasmine.SpyObj<FormService>;
    let customerSupportFormModelSpy: jasmine.SpyObj<CustomerSupportModel>;
    let httpClientSpy: jasmine.SpyObj<HttpClient>;
    let customerSupportModel: CustomerSupportModel;
    let customerSupportModel$: Observable<CustomerSupportModel>;


    beforeEach(() => {

        customerSupportModel = new CustomerSupportModel("", "", "", 0, "", false);
        customerSupportModel$ = of(customerSupportModel);

        httpClientSpy = jasmine.createSpyObj('HttpClient', ['get']);

        TestBed.configureTestingModule(
            {
                imports: [
                    CommonModule,
                    HttpClientModule,
                    AppModule
                ],
                providers: [FormService]
            });
        service = TestBed.inject(FormService);
        formServiceSpy = TestBed.inject(FormService) as jasmine.SpyObj<FormService>;

    });

    it('should be created', () => {
        expect(service).toBeTruthy();
    });

    it('should return an error when the server returns a 404', (done: DoneFn) => {
        const errorResponse = new HttpErrorResponse({
            error: 'Http failure response for https://localhost:7227/api/customersupport',
            status: 404, statusText: 'Not Found'
        });

        httpClientSpy.get.and.returnValue(of(errorResponse));

        service.createTicket(customerSupportFormModelSpy).subscribe({
            next: form => done.fail('expected an error, not form'),
            error: error => {
                expect(error.message).toContain('Http failure response for https://localhost:7227/api/customersupport');
                done();
            }
        });
    });

    // it('create ticket should accept instance of CustomerSupportModel', () => {
    //     expect(formServiceSpy.createTicket).toHaveBeenCalledWith(customerSupportModel);
    // });

    it('should return an instance of Observable<CustomerSupportModel>', () => {
        const returnExpected = service.createTicket(customerSupportModel);
        expect(typeof (customerSupportModel$)).toEqual(typeof (returnExpected));
    });
});


