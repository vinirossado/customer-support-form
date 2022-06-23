export class CustomerSupportModel {

    email!: string;
    phone!: string;
    number!: string;
    typeInquiry!: number;
    description!: string;
    agreementTerms!: boolean;

    constructor(email: string, phone: string, number: string, typeInquiry: number, description: string, terms: boolean) {
        this.email = email;
        this.phone = phone;
        this.number = number;
        this.typeInquiry = +typeInquiry;
        this.description = description;
        this.agreementTerms = terms;
    }
}
