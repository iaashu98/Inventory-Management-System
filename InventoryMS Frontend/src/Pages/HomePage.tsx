import { Link } from 'react-router-dom'

const HomePage = () => {
    return (
        <div>
            <h1>Inventory Management System</h1>
            <nav>
                <ul>
                    <li><Link to="/products">Products</Link></li>
                    <li><Link to="/categories">Categories</Link></li>
                    <li><Link to="/suppliers">Suppliers</Link></li>
                </ul>
            </nav>
        </div>
    )
}

export default HomePage
