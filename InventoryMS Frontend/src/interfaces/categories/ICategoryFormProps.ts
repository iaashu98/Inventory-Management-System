import { ICategory } from './ICategory';

export interface ICategoryFormProps {
    categoryId?: ICategory["categoryID"];
    setShowForm:(status : boolean) => void;
    setHideCreateBtn:(status : boolean) => void;
    onSuccess: () => void;
}
