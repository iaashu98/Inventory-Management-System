import SupplierList from "../components/suppliers/SuuplierList"

const SuppliersPage = () => {
  return (
    <div className="max-w-5xl mx-auto mt-10 px-4 sm:px-6 lg:px-8">
    <h1 className="text-2xl font-bold mb-4">Suppliers Management</h1>
    <SupplierList />
</div>
  )
}

export default SuppliersPage
