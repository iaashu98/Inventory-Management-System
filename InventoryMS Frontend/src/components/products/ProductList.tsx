import { useEffect, useState } from 'react';
import { getProducts, deleteProduct } from '../../services/api';
import ProductForm from './ProductForm';
import { IProduct } from '../../interfaces/products/IProduct';

const ProductList = () => {
    const [products, setProducts] = useState<IProduct[]>([]);
    const [selectedProductId, setSelectedProductId] = useState<number | null>(null);

    useEffect(() => {
        loadProducts();
    }, []);

    const loadProducts = async () => {
        const response = await getProducts();
        setProducts(response.data);
    };

    const handleEdit = (productId: number) => {
        setSelectedProductId(productId);
    };

    const handleDelete = async (productId: number) => {
        await deleteProduct(productId);
        loadProducts();
    };

    const handleFormSuccess = () => {
        setSelectedProductId(null);
        loadProducts();
    };

    return (
        <div className="max-w-3xl mx-auto mt-10">
            <h1 className="text-2xl font-bold mb-4">Products</h1>
            <ProductForm productId={selectedProductId ?? undefined} onSuccess={handleFormSuccess} />
            <ul className="mt-4">
                {products.map(product => (
                    <li key={product.productID}>
                        {product.productName}
                        <button onClick={() => handleEdit(product.productID)} className="bg-yellow-500 text-white py-1 px-3 rounded hover:bg-yellow-600 mr-2">Edit</button>
                        <button onClick={() => handleDelete(product.productID)} className="bg-red-500 text-white py-1 px-3 rounded hover:bg-red-600">Delete</button>
                    </li>
                ))}
            </ul>
        </div>
    );
};

export default ProductList;
