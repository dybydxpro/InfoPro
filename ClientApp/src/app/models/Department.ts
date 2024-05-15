export default interface Department{
    id?: number;
    companyId?: number;
    departmentName: string | any;

    isDeleted?: boolean | any;
    createdBy?: number;
    createdOn?: any;
    updatedBy?: number;
    updatedOn?: any;
}