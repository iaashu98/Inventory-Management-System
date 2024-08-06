import { useEffect, useState } from 'react';
import { getSuppliers, deleteSupplier } from '../../services/api';
import SupplierForm from './SupplierForm';
import SupplierItem from './SupplierItem';
import { ISupplier } from '../../interfaces/suppliers/ISupplier';

const SupplierList = () => {
    const [suppliers, setSuppliers] = useState<ISupplier[]>([]);
    const [selectedSupplierId, setSelectedSupplierId] = useState<number | null>(null);

    useEffect(() => {
        loadSuppliers();
    }, []);

    const loadSuppliers = async () => {
        const response = await getSuppliers();
        setSuppliers(response.data);
    };

    const handleEdit = (supplierId: number) => {
        setSelectedSupplierId(supplierId);
    };

    const handleDelete = async (supplierId: number) => {
        await deleteSupplier(supplierId);
        loadSuppliers();
    };

    const handleFormSuccess = () => {
        setSelectedSupplierId(null);
        loadSuppliers();
    };

    return (
<div className="max-w-3xl mx-auto mt-10">
            <h1 className="text-2xl font-bold mb-4">Suppliers</h1>
            <SupplierForm supplierId={selectedSupplierId ?? undefined} onSuccess={handleFormSuccess} />
            <ul className="mt-4">
                {suppliers.map(supplier => (
                    <li key={supplier.supplierID}>
                        {supplier.supplierName}
                        <button onClick={() => handleEdit(supplier.supplierID)} className="bg-yellow-500 text-white py-1 px-3 rounded hover:bg-yellow-600 mr-2">Edit</button>
                        <button onClick={() => handleDelete(supplier.supplierID)} className="bg-red-500 text-white py-1 px-3 rounded hover:bg-red-600">Delete</button>
                    </li>
                ))}
            </ul>
        </div>
    );
};

export default SupplierList;
