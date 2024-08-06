import { ISupplier } from '../../interfaces/suppliers/ISupplier';

interface SupplierItemProps {
    supplier: ISupplier;
    onEdit: (supplierId: number) => void;
    onDelete: (supplierId: number) => void;
}

const SupplierItem = ({supplier, onEdit, onDelete }: SupplierItemProps) => {
    return (
<li className="flex justify-between items-center bg-white p-4 shadow rounded mb-2">
            <span>{supplier.supplierName}</span>
            <div>
                <button onClick={() => onEdit(supplier.supplierID)} className="bg-yellow-500 text-white py-1 px-3 rounded hover:bg-yellow-600 mr-2">Edit</button>
                <button onClick={() => onDelete(supplier.supplierID)} className="bg-red-500 text-white py-1 px-3 rounded hover:bg-red-600">Delete</button>
            </div>
        </li>
    );
};

export default SupplierItem;
