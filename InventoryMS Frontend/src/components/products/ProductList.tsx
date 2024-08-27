import { useEffect, useState } from 'react';
import { getProducts, deleteProduct } from '../../services/api';
import ProductForm from './ProductForm';
import { IProduct } from '../../interfaces/products/IProduct';
import { notifyCreate, notifyDelete, notifyUpdate } from '../../utils/toastNotification';

const ProductList = () => {
    const [products, setProducts] = useState<IProduct[]>([]);
    const [selectedProductId, setSelectedProductId] = useState<number | null>(null);
    const [showForm, setShowForm] = useState(false);
    const [showAddBtn, setShowAddBtn] = useState(true);

    useEffect(() => {
        loadProducts();
    }, []);

    const loadProducts = async () => {
        const response = await getProducts();
        setProducts(response.data);
    };

    const handleEdit = (productId: number | null) => {
        setShowForm(true);
        if (productId !== null)
            setSelectedProductId(productId);
        setShowAddBtn(false);
    };

    const handleDelete = async (productId: number | null) => {
        if (productId !== null)
            await deleteProduct(productId);
        loadProducts();
        notifyDelete(getProductNameById(selectedProductId));
    };

    function getProductNameById(Id: number | null) {
        return products.find(x => x.productID == Id)?.productName;
    }

    const handleFormSuccess = () => {
        setSelectedProductId(null);
        loadProducts();
        setShowForm(false);
        setShowAddBtn(true);
        selectedProductId ? notifyUpdate(getProductNameById(selectedProductId))
                          : notifyCreate(getProductNameById(selectedProductId));
        
    };

    function createProduct(): void {
        setShowForm(true);
        setSelectedProductId(null);
    }

    return (
        <div>
            <h1 className="text-2xl font-bold mb-4">Products</h1>
            {showAddBtn && (<button
                onClick={() => createProduct()}
                className="bg-green-600 text-white py-4 px-4 mb-4 rounded hover:bg-green-700 w-30 sm:w-30 h-8 sm:h-10 flex items-center">
                Add New
            </button>)}
            {showForm && (
                <ProductForm productId={selectedProductId || undefined} onSuccess={handleFormSuccess} setShowForm={setShowForm} setShowAddBtn={setShowAddBtn}/>
            )}
            <div className="overflow-x-auto lg:overflow-x-auto">
                <table className="min-w-full bg-white border border-gray-300">
                    <thead>
                        <tr className="bg-gray-200 text-gray-600 uppercase text-sm leading-normal">
                            <th className="py-3 px-6 text-left">Product Name</th>
                            <th className="py-3 px-6 text-left">Category ID</th>
                            <th className="py-3 px-6 text-left">Supplier ID</th>
                            <th className="py-3 px-6 text-left">Quantity Per Unit</th>
                            <th className="py-3 px-6 text-left">Units in Stock</th>
                            <th className="py-3 px-6 text-left">Units on Order</th>
                            <th className="py-3 px-6 text-left">Discontinued</th>
                            <th className="py-3 px-6 text-right">Price</th>
                            <th className="py-3 px-6 text-center sticky right-0 bg-gray-200">Actions</th>
                        </tr>
                    </thead>
                    <tbody className="text-gray-600 text-sm font-light">
                        {products.map(product => (
                            <tr key={product.productID} className="border-b border-gray-200 hover:bg-gray-100">
                                <td className="py-3 px-6 text-left whitespace-nowrap">
                                    {product.productName}
                                </td>
                                <td className="py-3 px-6 text-left">
                                    {product.categoryID}
                                </td>
                                <td className="py-3 px-6 text-right">
                                    {product.supplierID}
                                </td>
                                <td className="py-3 px-6 text-right">
                                    {product.quantityPerUnit}
                                </td>
                                <td className="py-3 px-6 text-right">
                                    {product.unitsInStock}
                                </td>
                                <td className="py-3 px-6 text-right">
                                    {product.unitsOnOrder}
                                </td>
                                <td className="py-3 px-6 text-right">
                                    {product.discontinued ? "Yes" : "No"}
                                </td>
                                <td className="py-3 px-6 text-right">
                                    ₹{product.unitPrice.toFixed(2)}
                                </td>
                                <td className="py-3 px-6 text-center sticky right-0 bg-white">
                                    <div className="flex flex-col space-y-2">
                                        <button
                                            onClick={() => handleEdit(product.productID)}
                                            className="bg-green-600 text-white py-2 px-4 rounded hover:bg-green-700 w-20 sm:w-24 h-8 sm:h-10 flex items-center justify-center"
                                        >
                                            Edit
                                        </button>
                                        <button
                                            onClick={() => handleDelete(product.productID)}
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

export default ProductList;
