import axios from 'axios';
import { IProduct } from '../interfaces/products/IProduct';
import { ICategory } from '../interfaces/categories/ICategory';
import { ISupplier } from '../interfaces/suppliers/ISupplier';

const apiClient = axios.create({
    baseURL: 'http://localhost:5000/api',
    headers: {
        'Content-Type': 'application/json'
    }
});

// Product API calls
export const getProducts = () => apiClient.get('/products');
export const getProductById = (id: number) => apiClient.get(`/products/${id}`);
export const createProduct = (product: IProduct) => apiClient.post('/products', product);
export const updateProduct = (id: number, product: IProduct) => apiClient.put(`/products/${id}`, product);
export const deleteProduct = (id: number) => apiClient.delete(`/products/${id}`);

// Category API calls
export const getCategories = () => apiClient.get('/categories');
export const getCategoryById = (id: number) => apiClient.get(`/categories/${id}`);
export const createCategory = (category: ICategory) => apiClient.post('/categories', category);
export const updateCategory = (id: number, category: ICategory) => apiClient.put(`/categories/${id}`, category);
export const deleteCategory = (id: number) => apiClient.delete(`/categories/${id}`);

// Supplier API calls
export const getSuppliers = () => apiClient.get('/suppliers');
export const getSupplierById = (id: number) => apiClient.get(`/suppliers/${id}`);
export const createSupplier = (supplier: ISupplier) => apiClient.post('/suppliers', supplier);
export const updateSupplier = (id: number, supplier: ISupplier) => apiClient.put(`/suppliers/${id}`, supplier);
export const deleteSupplier = (id: number) => apiClient.delete(`/suppliers/${id}`);
