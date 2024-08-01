import { createCategory, updateCategory, getCategoryById } from '../../services/api';
import { ICategoryFormProps } from '../../interfaces/categories/ICategoryFormProps';
import { ICategory } from '../../interfaces/categories/ICategory';
import { useEffect, useState } from 'react';

const CategoryForm = ({ categoryId, onSuccess }: ICategoryFormProps) => {
    const [category, setCategory] = useState<ICategory>({
        categoryID: 0,
        categoryName: '',
        description: ''
    });

    useEffect(() => {
        if (categoryId) {
            const fetchCategory = async () => {
                try {
                    const response = await getCategoryById(categoryId);
                    setCategory(response.data);
                }
                catch {
                    console.error("Error fetching category: ", categoryId)
                }
            }
            fetchCategory();
        }
    }, [categoryId]);

    const handleChange = (e: React.ChangeEvent<HTMLInputElement | HTMLTextAreaElement>) => {
        const { name, value } = e.target;
        setCategory({ ...category, [name]: value });
    };

    const handleSubmit = async (e: React.FormEvent) => {
        e.preventDefault();
        if (categoryId) {
            await updateCategory(categoryId, category);
        } else {
            await createCategory(category);
        }
        onSuccess();
    };

    return (
        <form onSubmit={handleSubmit}>
            <div>
                <label>Category Name</label>
                <input type="text" name="categoryName" value={category.categoryName} onChange={handleChange} />
            </div>
            <div>
                <label>Description</label>
                <textarea name="description" value={category.description} onChange={handleChange} />
            </div>
            <button type="submit">{categoryId ? 'Update' : 'Create'}</button>
        </form>
    );
};

export default CategoryForm;
