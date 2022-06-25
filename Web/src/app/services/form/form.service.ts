import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { CustomerSupportModel } from 'src/app/models/customer-support.model';
import { environment } from 'src/environments/environment';

@Injectable()
export class FormService {

    constructor(private _httpClient: HttpClient) { }

    createTicket(model: CustomerSupportModel): Observable<CustomerSupportModel> {
        return this._httpClient.post<CustomerSupportModel>(`${environment.apiUrl}customersupport`, model)
    }
}
