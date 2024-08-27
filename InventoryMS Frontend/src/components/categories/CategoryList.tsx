import { useEffect, useState } from 'react';
import { getCategories, deleteCategory } from '../../services/api';
import CategoryForm from './CategoryForm';
import { ICategory } from '../../interfaces/categories/ICategory';
import { notifyDelete, notifyCreate, notifyUpdate } from '../../utils/toastNotification';

const CategoryList = () => {
    const [categories, setCategories] = useState<ICategory[]>([]);
    const [selectedCategoryId, setSelectedCategoryId] = useState<number | null>(null);
    const [showForm, setShowForm] = useState(false);
    const [hideCreateBtn, setShowCreateBtn] = useState(true);

    useEffect(() => {
        loadCategories();
    }, []);

    const loadCategories = async () => {
        const response = await getCategories();
        setCategories(response.data);
    };

    const handleEdit = (categoryId: number) => {
        setSelectedCategoryId(categoryId);
        setShowForm(true);
        setShowCreateBtn(false);
    };

    const createCategory = () =>{
        setSelectedCategoryId(null);
        setShowForm(true);
        setShowCreateBtn(false);
    }

    const getCatNameById = (categoryId: number | null) => {
        return categories.find(x => x.categoryID == categoryId)?.categoryName;
    }

    const handleDelete = async (categoryId: number) => {
        await deleteCategory(categoryId);
        loadCategories();
        notifyDelete(getCatNameById(selectedCategoryId));
    };

    const handleFormSuccess = () => {
        setSelectedCategoryId(null);
        loadCategories();
        setShowForm(false);
        selectedCategoryId ? notifyUpdate(getCatNameById(selectedCategoryId)) :
            notifyCreate(getCatNameById(selectedCategoryId));
        setShowCreateBtn(true);
    };

    return (
        <div className="max-w-3xl mx-auto mt-10">
            <h1 className="text-2xl font-bold mb-4">Categories</h1> 
            { hideCreateBtn && (<button
                onClick={createCategory}
                className="bg-green-600 text-white py-2 px-4 mb-4 rounded hover:bg-green-700 w-30 h-10 flex items-center"
            >
                Add New
            </button>)}
            {showForm && (<CategoryForm categoryId={selectedCategoryId ?? undefined} onSuccess={handleFormSuccess} setShowForm={setShowForm} setHideCreateBtn ={setShowCreateBtn} />)}
            <table className="min-w-full bg-white border border-gray-300">
                <thead>
                    <tr className="bg-gray-200 text-gray-600 uppercase text-sm leading-normal">
                        <th className="py-3 px-6 text-left">Category Name</th>
                        <th className="py-3 px-6 text-left">Description</th>
                        <th className="py-3 px-6 text-center">Actions</th>
                    </tr>
                </thead>
                <tbody className="text-gray-600 text-sm font-light">
                    {categories.map(category => (
                        <tr key={category.categoryID} className="border-b border-gray-200 hover:bg-gray-100">
                            <td className="py-3 px-6 text-left whitespace-nowrap">
                                {category.categoryName}
                            </td>
                            <td className="py-3 px-6 text-left">
                                {category.description}
                            </td>
                            <td className="py-3 px-6 text-center">
                                <div className="flex justify-center items-center space-x-2">
                                    <button
                                        onClick={() => handleEdit(category.categoryID)}
                                        className="bg-green-600 text-white py-2 px-4 rounded hover:bg-green-700 w-24 h-10 flex items-center justify-center"
                                    >
                                        Edit
                                    </button>
                                    <button
                                        onClick={() => handleDelete(category.categoryID)}
                                        className="bg-red-500 text-white py-2 px-4 rounded hover:bg-red-600 w-24 h-10 flex items-center justify-center"
                                    >
                                        Delete
                                    </button>
                                </div>
                            </td>
                        </tr>
                    ))}
                </tbody>
            </table>
        </div>
    );
};

export default CategoryList;
