namespace OrderManagementApp.Client.Services.SupplierService
{
    public interface ISupplierService
    {
        List<Supplier> Suppliers { get; set; }
        List<State> States { get; set; }
        Task GetSatesAsync();
        Task GetSuppliersAsync();
        Task<Supplier> GetSupplierAsync(int id);
        Task CreateSupplierAsync(Supplier supplier);
        Task UpdateSupplierAsync(Supplier supplier);
        Task DeleteSupplierAsync(int id);
    }
}
