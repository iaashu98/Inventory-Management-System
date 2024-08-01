import { IProduct } from './IProduct';

export interface IProductFormProps{
    productId?: IProduct["productID"]; //check if it;s correct 
    onSuccess: () => void;
}