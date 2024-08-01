import { useEffect, useState } from 'react';
import { getCategories, deleteCategory } from '../../services/api';
import CategoryForm from './CategoryForm';
import { ICategory } from '../../interfaces/categories/ICategory';
import CategoryItem from './CategoryItem';

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
        <div>
            <h1>Categories</h1>
            <CategoryForm categoryId={selectedCategoryId ?? undefined} onSuccess={handleFormSuccess} />
            <ul>
                {categories.map(category => (
                    <CategoryItem key={category.categoryID} category={category} onEdit={handleEdit} onDelete={handleDelete} />
                ))}
            </ul>
        </div>
    );
};

export default CategoryList;
