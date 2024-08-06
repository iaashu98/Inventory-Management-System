import { ICategory } from '../../interfaces/categories/ICategory';

interface CategoryItemProps {
    category: ICategory;
    onEdit: (categoryId: number) => void;
    onDelete: (categoryId: number) => void;
}

const CategoryItem = ({ category, onEdit, onDelete } : CategoryItemProps) => {
    return (
        <li className="flex justify-between items-center bg-white p-4 shadow rounded mb-2">
            <span>{category.categoryName}</span>
            <div>
                <button onClick={() => onEdit(category.categoryID)} className="bg-yellow-500 text-white py-1 px-3 rounded hover:bg-yellow-600 mr-2">Edit</button>
                <button onClick={() => onDelete(category.categoryID)} className="bg-red-500 text-white py-1 px-3 rounded hover:bg-red-600">Delete</button>
            </div>
        </li>
    );
};

export default CategoryItem;
