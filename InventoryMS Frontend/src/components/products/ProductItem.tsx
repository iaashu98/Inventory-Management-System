import { IProduct } from '../../interfaces/products/IProduct';
import { IProductListProps } from '../../interfaces/products/IProductListProps';

interface ProductItemProps extends IProductListProps {
    product: IProduct;
}

const ProductItem = ({ product, onEdit, onDelete } : ProductItemProps) => {
    return (
        <li className="flex justify-between items-center bg-white p-4 shadow rounded mb-2">
            <span>{product.productName}</span>
            <div>
                <button onClick={() => onEdit(product.productID)} className="bg-yellow-500 text-white py-1 px-3 rounded hover:bg-yellow-600 mr-2">Edit</button>
                <button onClick={() => onDelete(product.productID)} className="bg-red-500 text-white py-1 px-3 rounded hover:bg-red-600">Delete</button>
            </div>
        </li>
    );
};

export default ProductItem;
