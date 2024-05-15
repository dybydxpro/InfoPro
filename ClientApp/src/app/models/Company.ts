export default interface Company{
    id?: number;
    companyName?: string;
    addressLine1?: string;
    addressLine2?: string;
    city?: string;
    postalCode?: string;
    companyEmail?: string;
    companyContact?: string;
    website?: string;

    adminIdentifire?: string | any;

    isDeleted?: boolean | any;
    createdOn?: any;
    updatedOn?: any;
}