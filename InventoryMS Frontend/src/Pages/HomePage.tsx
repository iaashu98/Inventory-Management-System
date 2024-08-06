import { Link } from 'react-router-dom'

const HomePage = () => {
    return (
        <div className="max-w-3xl mx-auto mt-10">
            <h1 className="text-3xl font-bold mb-6">Inventory Management System</h1>
            <nav className="mb-6">
                <ul className="space-y-2">
                    <li><Link to="/products" className="text-blue-500 hover:underline">Products</Link></li>
                    <li><Link to="/categories" className="text-blue-500 hover:underline">Categories</Link></li>
                    <li><Link to="/suppliers" className="text-blue-500 hover:underline">Suppliers</Link></li>
                </ul>
            </nav>
        </div>
    )
}

export default HomePage
