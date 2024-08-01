import { ISupplier } from "./ISupplier";

export interface ISupplierFormProps {
    supplierId?: ISupplier["supplierID"];
    onSuccess: () => void;
}
