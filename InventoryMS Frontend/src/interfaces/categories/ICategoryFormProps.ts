import { ICategory } from './ICategory';

export interface ICategoryFormProps {
    categoryId?: ICategory["categoryID"];
    onSuccess: () => void;
}
