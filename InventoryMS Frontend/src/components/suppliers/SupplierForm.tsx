import React, { useState, useEffect } from 'react';
import { createSupplier, updateSupplier, getSupplierById } from '../../services/api';
import { ISupplierFormProps } from '../../interfaces/suppliers/ISupplierFormProps';
import { ISupplier } from '../../interfaces/suppliers/ISupplier';

const SupplierForm = ({ supplierId, onSuccess, setShowForm, setShowAddBtn }: ISupplierFormProps) => {
    const [supplier, setSupplier] = useState<ISupplier>({
        supplierID: 0,
        supplierName: '',
        contactName: '',
        address: '',
        city: '',
        postalCode: '',
        country: '',
        phone: '',
        email: ''
    });

    useEffect(() => {
        if (supplierId) {
            const fetchSupplier = async () =>{
                try{
                    const response = await getSupplierById(supplierId)
                    setSupplier(response.data);
            }
            catch{
                console.error("Error fetching supplier: ", supplierId)
            }
        }
        fetchSupplier();
    }
    }, [supplierId]);

    const handleChange = (e: React.ChangeEvent<HTMLInputElement | HTMLSelectElement>) => {
        const { name, value } = e.target;
        setSupplier({ ...supplier, [name]: value });
    }

    const handleSubmit = async (e: React.FormEvent<HTMLFormElement>) => {
        e.preventDefault();
        try {
            if (supplierId) {
                await updateSupplier(supplierId, supplier);
            } else {
                await createSupplier(supplier);
            }
            onSuccess();
        } catch (error) {
            console.error("Error saving supplier: ", error);
        }
    }

    const handleCancel = () => {
        setShowForm(false);
        setShowAddBtn(true);
    }

    return (
        <form onSubmit={handleSubmit} className="space-y-4">
            <div className="flex flex-col">
                <label className="mb-1 font-semibold">Supplier Name</label>
                <input type="text" name="supplierName" value={supplier.supplierName} onChange={handleChange} className="border p-2 rounded" />
            </div>
            <div className="flex flex-col">
                <label className="mb-1 font-semibold">Contact Name</label>
                <input type="text" name="contactName" value={supplier.contactName} onChange={handleChange} className="border p-2 rounded" />
            </div>
            <div className="flex flex-col">
                <label className="mb-1 font-semibold">Address</label>
                <input type="text" name="address" value={supplier.address} onChange={handleChange} className="border p-2 rounded" />
            </div>
            <div className="flex flex-col">
                <label className="mb-1 font-semibold">City</label>
                <input type="text" name="city" value={supplier.city} onChange={handleChange} className="border p-2 rounded" />
            </div>
            <div className="flex flex-col">
                <label className="mb-1 font-semibold">Postal Code</label>
                <input type="text" name="postalCode" value={supplier.postalCode} onChange={handleChange} className="border p-2 rounded" />
            </div>
            <div className="flex flex-col">
                <label className="mb-1 font-semibold">Country</label>
                <input type="text" name="country" value={supplier.country} onChange={handleChange} className="border p-2 rounded" />
            </div>
            <div className="flex flex-col">
                <label className="mb-1 font-semibold">Phone</label>
                <input type="text" name="phone" value={supplier.phone} onChange={handleChange} className="border p-2 rounded" />
            </div>
            <div className="flex flex-col">
                <label className="mb-1 font-semibold">Email</label>
                <input type="email" name="email" value={supplier.email} onChange={handleChange} className="border p-2 rounded" />
            </div>
            <div className="flex items-center space-x-2">
                <button
                    type='submit'
                    className="bg-green-600 text-white py-2 px-4 mb-4 rounded hover:bg-green-700 w-24 h-10 flex items-center justify-center"
                >
                    {supplierId ? 'Update' : 'Create'}
                </button>
                <button
                    onClick={() => handleCancel()}
                    className="bg-red-500 text-white py-2 px-4 mb-4 rounded hover:bg-red-600 w-24 h-10 flex items-center justify-center"
                >
                    Cancel
                </button>
            </div>
        </form>

    );
};

export default SupplierForm;
