import { ISupplier } from "./ISupplier";

export interface ISupplierFormProps {
    supplierId?: ISupplier["supplierID"];
    setShowForm: (status : boolean) => void;
    setShowAddBtn: (btn : boolean) => void;
    onSuccess: () => void;
}
