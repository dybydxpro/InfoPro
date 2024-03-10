export default interface Designation{
    id?: number;
    companyId?: number;
    designationName: string | any;

    isDeleted?: boolean | any;
    createdBy?: number;
    createdOn?: any;
    updatedBy?: number;
    updatedOn?: number;
}