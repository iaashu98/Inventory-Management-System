import { IProduct } from '../../interfaces/products/IProduct';
import { IProductListProps } from '../../interfaces/products/IProductListProps';

interface ProductItemProps extends IProductListProps {
    product: IProduct;
}

const ProductItem = ({ product, onEdit, onDelete } : ProductItemProps) => {
    return (
        <li>
            {product.productName}
            <button onClick={() => onEdit(product.productID)}>Edit</button>
            <button onClick={() => onDelete(product.productID)}>Delete</button>
        </li>
    );
};

export default ProductItem;
