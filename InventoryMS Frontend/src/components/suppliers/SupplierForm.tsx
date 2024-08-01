import React, { useState, useEffect } from 'react';
import { createSupplier, updateSupplier, getSupplierById } from '../../services/api';
import { ISupplierFormProps } from '../../interfaces/suppliers/ISupplierFormProps';
import { ISupplier } from '../../interfaces/suppliers/ISupplier';

const SupplierForm = ({ supplierId, onSuccess }: ISupplierFormProps) => {
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
            fetchSupplier();
        }
    }
    }, [supplierId]);

    const handleChange = (e: React.ChangeEvent<HTMLInputElement>) => {
        const { name, value } = e.target;
        setSupplier({ ...supplier, [name]: value });
    };

    const handleSubmit = async (e: React.FormEvent) => {
        e.preventDefault();
        if (supplierId) {
            await updateSupplier(supplierId, supplier);
        } else {
            await createSupplier(supplier);
        }
        onSuccess();
    };

    return (
        <form onSubmit={handleSubmit}>
            <div>
                <label>Supplier Name</label>
                <input type="text" name="supplierName" value={supplier.supplierName} onChange={handleChange} />
            </div>
            <div>
                <label>Contact Name</label>
                <input type="text" name="contactName" value={supplier.contactName} onChange={handleChange} />
            </div>
            <div>
                <label>Address</label>
                <input type="text" name="address" value={supplier.address} onChange={handleChange} />
            </div>
            <div>
                <label>City</label>
                <input type="text" name="city" value={supplier.city} onChange={handleChange} />
            </div>
            <div>
                <label>Postal Code</label>
                <input type="text" name="postalCode" value={supplier.postalCode} onChange={handleChange} />
            </div>
            <div>
                <label>Country</label>
                <input type="text" name="country" value={supplier.country} onChange={handleChange} />
            </div>
            <div>
                <label>Phone</label>
                <input type="text" name="phone" value={supplier.phone} onChange={handleChange} />
            </div>
            <div>
                <label>Email</label>
                <input type="email" name="email" value={supplier.email} onChange={handleChange} />
            </div>
            <button type="submit">{supplierId ? 'Update' : 'Create'}</button>
        </form>
    );
};

export default SupplierForm;
