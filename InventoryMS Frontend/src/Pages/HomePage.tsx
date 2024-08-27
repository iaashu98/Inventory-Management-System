import ProductList from '../components/products/ProductList'
import CategoryList from '../components/categories/CategoryList'
import SupplierList from '../components/suppliers/SuuplierList'
import Collapsible from '../helpers/Collapsible'

const HomePage = () => {
    return (
        <div className="max-w-5xl mx-auto mt-10">
            <h1 className="text-5xl font-bold mb-6">Inventory Management System</h1>
            <nav className="mb-6">
                <ul className="space-y-4">
                    <Collapsible title="Products">
                        <ProductList/>
                    </Collapsible>
                    <Collapsible title="Categories">
                        <CategoryList/>
                    </Collapsible>
                    <Collapsible title="Suppliers">
                        <SupplierList/>
                    </Collapsible>
                </ul>
            </nav>
        </div>
    )
}

export default HomePage
