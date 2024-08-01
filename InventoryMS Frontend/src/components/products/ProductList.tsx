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
        <div>
            <h1>Products</h1>
            <ProductForm productId={selectedProductId ?? undefined} onSuccess={handleFormSuccess} />
            <ul>
                {products.map(product => (
                    <li key={product.productID}>
                        {product.productName}
                        <button onClick={() => handleEdit(product.productID)}>Edit</button>
                        <button onClick={() => handleDelete(product.productID)}>Delete</button>
                    </li>
                ))}
            </ul>
        </div>
    );
};

export default ProductList;
