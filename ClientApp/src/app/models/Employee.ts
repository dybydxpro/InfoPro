import Company from "./Company";
import Department from "./Department";
import Designation from "./Designation";

export default interface Employee{
    id?: number;
    companyId?: number;
    firstName?: string;
    lastName?: string;
    gender?: string;
    dob?: any;
    address?: any;
    nic?: string;
    designationId?: number;
    departmentId?: number;

    company?: Company;
    designation?: Designation
    department?: Department

    isDeleted?: boolean | any;
    createdBy?: number;
    createdOn?: any;
    updatedBy?: number;
    updatedOn?: any;
}