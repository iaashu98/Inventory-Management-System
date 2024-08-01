import { ICategory } from '../../interfaces/categories/ICategory';

interface CategoryItemProps {
    category: ICategory;
    onEdit: (categoryId: number) => void;
    onDelete: (categoryId: number) => void;
}

const CategoryItem = ({ category, onEdit, onDelete } : CategoryItemProps) => {
    return (
        <li>
            {category.categoryName}
            <button onClick={() => onEdit(category.categoryID)}>Edit</button>
            <button onClick={() => onDelete(category.categoryID)}>Delete</button>
        </li>
    );
};

export default CategoryItem;
