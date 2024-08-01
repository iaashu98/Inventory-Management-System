import './App.css'
import { BrowserRouter as Router, Link, Route, Routes } from 'react-router-dom'
import HomePage from './Pages/HomePage'
import ProductsPage from './Pages/ProductsPage'
import CategoriesPage from './Pages/CategoriesPage'
import SuppliersPage from './Pages/SuppliersPage'

const App = () => {
  return (
    <Router>
      <nav>
        <ul>
          <li><Link to="/">Home</Link></li>
          <li><Link to="/products">Products</Link></li>
          <li><Link to="/categories">Categories</Link></li>
          <li><Link to="/suppliers">Suppliers</Link></li>
        </ul>
      </nav>
      <Routes>
                <Route path="/" element={<HomePage />} />
                <Route path="/products" element={<ProductsPage />} />
                <Route path="/categories" element={<CategoriesPage />} />
                <Route path="/suppliers" element={<SuppliersPage />} />
            </Routes>
    </Router>
  )
}

export default App
