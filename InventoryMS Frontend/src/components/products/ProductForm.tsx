import React, { useEffect, useState } from 'react'
import { IProductFormProps } from '../../interfaces/products/IProductFormProps'
import { IProduct } from '../../interfaces/products/IProduct'
import { createProduct, getProductById, updateProduct } from '../../services/api';

const ProductForm = ({ productId, onSuccess, setShowForm, setShowAddBtn }: IProductFormProps) => {

    const [product, setProduct] = useState<IProduct>(
        {
            productID: 0,
            productName: '',
            categoryID: 0,
            supplierID: 0,
            quantityPerUnit: '',
            unitPrice: 0,
            unitsInStock: 0,
            unitsOnOrder: 0,
            reorderLevel: 0,
            discontinued: false
        }
    );

    useEffect(() => {
        if (productId) {
            const fetchProduct = async () => {
                try {
                    const response = await getProductById(productId);
                    setProduct(response.data);
                }
                catch {
                    console.error("Error fetching product: ", productId);
                }
            }
            fetchProduct();
        }
    }, [productId])


    const handleChange = (e: React.ChangeEvent<HTMLInputElement | HTMLSelectElement>) => {
        const {name, value} = e.target;
        setProduct({...product, [name]: value});
    }

    const handleSubmit = async (e: React.FormEvent<HTMLFormElement>) => {
        e.preventDefault();
        try{
            if(productId)
                await updateProduct(productId, product);
            else
                await createProduct(product);
            onSuccess();
        }
        catch(error){
            console.error("Error saving product: ", error);
        }
    }
    const handleCancel= () => {
        setShowForm(false);
        setShowAddBtn(true);
    }

    return (
        <form onSubmit={handleSubmit} className="space-y-4">
            <div className="flex flex-col">
                <label className="mb-1 font-semibold">Product Name</label>
                <input type="text" name="productName" value={product.productName} onChange={handleChange} className="border p-2 rounded" />
            </div>
            <div className="flex flex-col">
                <label className="mb-1 font-semibold">Category ID</label>
                <input type="number" name="categoryID" value={product.categoryID} onChange={handleChange} className="border p-2 rounded" />
            </div>
            <div className="flex flex-col">
                <label className="mb-1 font-semibold">Supplier ID</label>
                <input type="number" name="supplierID" value={product.supplierID} onChange={handleChange} className="border p-2 rounded" />
            </div>
            <div className="flex flex-col">
                <label className="mb-1 font-semibold">Quantity Per Unit</label>
                <input type="text" name="quantityPerUnit" value={product.quantityPerUnit} onChange={handleChange} className="border p-2 rounded" />
            </div>
            <div className="flex flex-col">
                <label className="mb-1 font-semibold">Unit Price</label>
                <input type="number" name="unitPrice" value={product.unitPrice} onChange={handleChange} className="border p-2 rounded" />
            </div>
            <div className="flex flex-col">
                <label className="mb-1 font-semibold">Units In Stock</label>
                <input type="number" name="unitsInStock" value={product.unitsInStock} onChange={handleChange} className="border p-2 rounded" />
            </div>
            <div className="flex flex-col">
                <label className="mb-1 font-semibold">Units On Order</label>
                <input type="number" name="unitsOnOrder" value={product.unitsOnOrder} onChange={handleChange} className="border p-2 rounded" />
            </div>
            <div className="flex flex-col">
                <label className="mb-1 font-semibold">Reorder Level</label>
                <input type="number" name="reorderLevel" value={product.reorderLevel} onChange={handleChange} className="border p-2 rounded" />
            </div>
            <div className="flex flex-col">
                <label className="mb-1 font-semibold">Discontinued</label>
                <select name="discontinued" value={product.discontinued.toString()} onChange={handleChange} className="border p-2 rounded">
                    <option value="false">No</option>
                    <option value="true">Yes</option>
                </select>
            </div>
            <div className="flex items-center space-x-2">
                <button
                    type='submit'
                    className="bg-green-600 text-white py-2 px-4 mb-4 rounded hover:bg-green-700 w-24 h-10 flex items-center justify-center"
                >
                    {productId ? 'Update' : 'Create'}
                </button>
                <button
                    onClick={() => handleCancel()}
                    className="bg-red-500 text-white py-2 px-4 mb-4 rounded hover:bg-red-600 w-24 h-10 flex items-center justify-center"
                >
                    Cancel
                </button>
            </div>
        </form>
    )
}

export default ProductForm

