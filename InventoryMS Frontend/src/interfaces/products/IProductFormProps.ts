import { IProduct } from './IProduct';

export interface IProductFormProps {
    productId?: IProduct["productID"];
    setShowForm: (status: boolean) => void;
    setShowAddBtn: (btn: boolean) => void;
    onSuccess: () => void;
}