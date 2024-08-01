import {IProduct} from './IProduct';

export interface IProductListProps {
    products: IProduct[];
    onEdit: (productId: number) => void;
    onDelete: (productId: number)   => void;
}