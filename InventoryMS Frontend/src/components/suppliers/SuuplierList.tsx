import { useEffect, useState } from 'react';
import { getSuppliers, deleteSupplier } from '../../services/api';
import SupplierForm from './SupplierForm';
import { ISupplier } from '../../interfaces/suppliers/ISupplier';
import { notifyCreate, notifyDelete, notifyUpdate } from '../../utils/toastNotification';

const SupplierList = () => {
    const [suppliers, setSuppliers] = useState<ISupplier[]>([]);
    const [selectedSupplierId, setSelectedSupplierId] = useState<number | null>(null);
    const [showForm, setShowForm] = useState(false);
    const [showAddBtn, setShowAddBtn] = useState(true);

    useEffect(() => {
        loadSuppliers();
    }, []);

    const loadSuppliers = async () => {
        const response = await getSuppliers();
        setSuppliers(response.data);
    };

    const getSupplierNameById = (Id: number | null) => {
        return suppliers.find(x => x.supplierID == Id)?.supplierName;
    }

    const handleEdit = (supplierId: number) => {
        setSelectedSupplierId(supplierId);
        setShowForm(true);
        setShowAddBtn(false);
    };

    const handleDelete = async (supplierId: number) => {
        await deleteSupplier(supplierId);
        loadSuppliers();
        notifyDelete(getSupplierNameById(supplierId));
    };

    const handleFormSuccess = () => {
        setSelectedSupplierId(null);
        loadSuppliers();
        setShowForm(false);
        selectedSupplierId ? notifyUpdate(getSupplierNameById(selectedSupplierId))
            : notifyCreate(getSupplierNameById(selectedSupplierId));
        setShowAddBtn(true);
    };

    const createSupplier = () => {
        setShowForm(true);
        setSelectedSupplierId(null);
    }

    return (
        <div>
            <h1 className="text-2xl font-bold mb-4">Suppliers</h1>
            {showAddBtn && (<button
                onClick={() => createSupplier()}
                className="bg-green-600 text-white py-4 px-4 mb-4 rounded hover:bg-green-700 w-30 sm:w-30 h-8 sm:h-10 flex items-center">
                Add New
            </button>)}
            {showForm && (<SupplierForm supplierId={selectedSupplierId ?? undefined} onSuccess={handleFormSuccess} setShowForm={setShowForm} setShowAddBtn={setShowAddBtn} />)}
            <div className="overflow-x-auto lg:overflow-x-auto">
                <table className="min-w-full bg-white border border-gray-300">
                    <thead>
                        <tr className="bg-gray-200 text-gray-600 uppercase text-sm leading-normal">
                            <th className="py-3 px-6 text-left">Supplier Name</th>
                            <th className="py-3 px-6 text-left">Contact Name</th>
                            <th className="py-3 px-6 text-left">Phone No.</th>
                            <th className="py-3 px-6 text-left">Email Id</th>
                            <th className="py-3 px-6 text-left">Address</th>
                            <th className="py-3 px-6 text-left">City</th>
                            <th className="py-3 px-6 text-left">Country</th>
                            <th className="py-3 px-6 text-right">Postal Code</th>
                            <th className="py-3 px-6 text-center sticky right-0 bg-gray-200">Actions</th>
                        </tr>
                    </thead>
                    <tbody className="text-gray-600 text-sm font-light">
                        {suppliers.map(supplier => (
                            <tr key={supplier.supplierID} className="border-b border-gray-200 hover:bg-gray-100">
                                <td className="py-3 px-6 text-left whitespace-nowrap">
                                    {supplier.supplierName}
                                </td>
                                <td className="py-3 px-6 text-left">
                                    {supplier.contactName}
                                </td>
                                <td className="py-3 px-6 text-right">
                                    {supplier.phone}
                                </td>
                                <td className="py-3 px-6 text-right">
                                    {supplier.email}
                                </td>
                                <td className="py-3 px-6 text-right">
                                    {supplier.address}
                                </td>
                                <td className="py-3 px-6 text-right">
                                    {supplier.city}
                                </td>
                                <td className="py-3 px-6 text-right">
                                    {supplier.country}
                                </td>
                                <td className="py-3 px-6 text-right">
                                    {supplier.postalCode}
                                </td>
                                <td className="py-3 px-6 text-center sticky right-0 bg-white">
                                    <div className="flex flex-col space-y-2">
                                        <button
                                            onClick={() => handleEdit(supplier.supplierID)}
                                            className="bg-green-600 text-white py-2 px-4 rounded hover:bg-green-700 w-20 sm:w-24 h-8 sm:h-10 flex items-center justify-center"
                                        >
                                            Edit
                                        </button>
                                        <button
                                            onClick={() => handleDelete(supplier.supplierID)}
                                            className="bg-red-500 text-white py-2 px-4 rounded hover:bg-red-600 w-20 sm:w-24 h-8 sm:h-10 flex items-center justify-center"
                                        >
                                            Delete
                                        </button>
                                    </div>
                                </td>
                            </tr>
                        ))}
                    </tbody>
                </table>
            </div>
        </div>
    );
};

export default SupplierList;
