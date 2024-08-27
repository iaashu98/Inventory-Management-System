import ProductList from '../components/products/ProductList'

const ProductsPage = () => {
  return (
    <div className="max-w-5xl mx-auto mt-10 px-4 sm:px-6 lg:px-8">
      <h1 className="text-3xl font-bold mb-6">Products Management</h1>
      <ProductList />
    </div>
  )
}

export default ProductsPage
