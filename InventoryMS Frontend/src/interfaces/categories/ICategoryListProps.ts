import { ICategory } from "./ICategory";

export interface ICategoryListProps {
    categories: ICategory[];
    onEdit: (categoryId: number) => void;
    onDelete: (categoryId: number) => void;
}
