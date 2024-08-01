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
        <div>
            <h1>Suppliers</h1>
            <SupplierForm supplierId={selectedSupplierId ?? undefined} onSuccess={handleFormSuccess} />
            <ul>
                {suppliers.map(supplier => (
                    <SupplierItem key={supplier.supplierID} supplier={supplier} onEdit={handleEdit} onDelete={handleDelete} />
                ))}
            </ul>
        </div>
    );
};

export default SupplierList;
