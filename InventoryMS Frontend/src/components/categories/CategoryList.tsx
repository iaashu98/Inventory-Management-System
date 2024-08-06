import { useEffect, useState } from 'react';
import { getCategories, deleteCategory } from '../../services/api';
import CategoryForm from './CategoryForm';
import { ICategory } from '../../interfaces/categories/ICategory';

const CategoryList = () => {
    const [categories, setCategories] = useState<ICategory[]>([]);
    const [selectedCategoryId, setSelectedCategoryId] = useState<number | null>(null);

    useEffect(() => {
        loadCategories();
    }, []);

    const loadCategories = async () => {
        const response = await getCategories();
        setCategories(response.data);
    };

    const handleEdit = (categoryId: number) => {
        setSelectedCategoryId(categoryId);
    };

    const handleDelete = async (categoryId: number) => {
        await deleteCategory(categoryId);
        loadCategories();
    };

    const handleFormSuccess = () => {
        setSelectedCategoryId(null);
        loadCategories();
    };

    return (
        <div className="max-w-3xl mx-auto mt-10">
            <h1 className="text-2xl font-bold mb-4">Categories</h1>
            <CategoryForm categoryId={selectedCategoryId ?? undefined} onSuccess={handleFormSuccess} />
            <ul className="mt-4">
                {categories.map(category => (
                    <li key={category.categoryID}>
                        {category.categoryName}
                        <button onClick={() => handleEdit(category.categoryID)} className="bg-yellow-500 text-white py-1 px-3 rounded hover:bg-yellow-600 mr-2">Edit</button>
                        <button onClick={() => handleDelete(category.categoryID)} className="bg-red-500 text-white py-1 px-3 rounded hover:bg-red-600">Delete</button>
                    </li>
                ))}
            </ul>
        </div>
    );
};

export default CategoryList;
