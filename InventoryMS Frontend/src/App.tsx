import './App.css'
import { BrowserRouter as Router, Link, Route, Routes } from 'react-router-dom'
import HomePage from './Pages/HomePage'
import ProductsPage from './Pages/ProductsPage'
import CategoriesPage from './Pages/CategoriesPage'
import SuppliersPage from './Pages/SuppliersPage'

const App = () => {
  return (
    <Router>
            <nav className="bg-gray-800 p-4">
                <ul className="flex space-x-4">
                    <li><Link to="/" className="text-white hover:underline">Home</Link></li>
                    <li><Link to="/products" className="text-white hover:underline">Products</Link></li>
                    <li><Link to="/categories" className="text-white hover:underline">Categories</Link></li>
                    <li><Link to="/suppliers" className="text-white hover:underline">Suppliers</Link></li>
                </ul>
            </nav>
            <div className="p-4">
                <Routes>
                    <Route path="/" element={<HomePage />} />
                    <Route path="/products" element={<ProductsPage />} />
                    <Route path="/categories" element={<CategoriesPage />} />
                    <Route path="/suppliers" element={<SuppliersPage />} />
                </Routes>
            </div>
        </Router>
  )
}

export default App
