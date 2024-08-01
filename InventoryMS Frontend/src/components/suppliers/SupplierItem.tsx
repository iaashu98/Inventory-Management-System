import { ISupplier } from '../../interfaces/suppliers/ISupplier';

interface SupplierItemProps {
    supplier: ISupplier;
    onEdit: (supplierId: number) => void;
    onDelete: (supplierId: number) => void;
}

const SupplierItem = ({supplier, onEdit, onDelete }: SupplierItemProps) => {
    return (
        <li>
            {supplier.supplierName}
            <button onClick={() => onEdit(supplier.supplierID)}>Edit</button>
            <button onClick={() => onDelete(supplier.supplierID)}>Delete</button>
        </li>
    );
};

export default SupplierItem;
