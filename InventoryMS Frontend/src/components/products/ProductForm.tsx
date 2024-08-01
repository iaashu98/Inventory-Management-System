import React, { useEffect, useState } from 'react'
import { IProductFormProps } from '../../interfaces/products/IProductFormProps'
import { IProduct } from '../../interfaces/products/IProduct'
import { createProduct, getProductById, updateProduct } from '../../services/api';

const ProductForm = ({ productId, onSuccess }: IProductFormProps) => {
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

    return (
        <form onSubmit={handleSubmit}>
            <div>
                <label>Product Name</label>
                <input type="text" name="productName" placeholder='Enter Product Name' value={product.productName} onChange={handleChange} />
            </div>
            <div>
                <label>Category ID</label>
                <input type="number" name="categoryID" value={product.categoryID} onChange={handleChange} />
            </div>
            <div>
                <label>Supplier ID</label>
                <input type="number" name="supplierID" value={product.supplierID} onChange={handleChange} />
            </div>
            <div>
                <label>Quantity Per Unit</label>
                <input type="text" name="quantityPerUnit" value={product.quantityPerUnit} onChange={handleChange} />
            </div>
            <div>
                <label>Unit Price</label>
                <input type="number" name="unitPrice" value={product.unitPrice} onChange={handleChange} />
            </div>
            <div>
                <label>Units In Stock</label>
                <input type="number" name="unitsInStock" value={product.unitsInStock} onChange={handleChange} />
            </div>
            <div>
                <label>Units On Order</label>
                <input type="number" name="unitsOnOrder" value={product.unitsOnOrder} onChange={handleChange} />
            </div>
            <div>
                <label>Reorder Level</label>
                <input type="number" name="reorderLevel" value={product.reorderLevel} onChange={handleChange} />
            </div>
            <div>
                <label>Discontinued</label>
                <select name="discontinued" value={product.discontinued.toString()} onChange={handleChange}>
                    <option value="false">No</option>
                    <option value="true">Yes</option>
                </select>
            </div>
            <button type='submit'> {productId ? 'Update' : 'Create'}</button>
        </form>
    )
}

export default ProductForm

