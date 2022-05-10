using Microsoft.AspNetCore.Components;
using System.Net.Http.Json;

namespace OrderManagementApp.Client.Services.SupplierService
{
    public class SupplierService : ISupplierService
    {
        private readonly HttpClient _http;
        private readonly NavigationManager _navgationManager;

        public SupplierService(HttpClient http, NavigationManager navgationManager)
        {
            _http = http;
            _navgationManager = navgationManager;
        }
        public List<Supplier> Suppliers { get ; set ; }
        public List<State> States { get ; set ; }
        
        public async Task GetSatesAsync()
        {
            var result = await _http.GetFromJsonAsync<List<State>>("api/suppliers/states");
            if (result != null)
                States = result;
        } 

        public async Task<Supplier> GetSupplierAsync(int id)
        {
            var data = await _http.GetFromJsonAsync<Supplier>($"api/suppliers/{id}");
            if (data != null)
                return data;
            throw new Exception("Supplier not found !");
        }

        public async Task GetSuppliersAsync()
        {
            var result = await _http.GetFromJsonAsync<List<Supplier>>("api/suppliers");
            if(result !=null)
                Suppliers = result;
        }
        public async Task CreateSupplierAsync(Supplier supplier)
        {
            var result = await _http.PostAsJsonAsync("api/suppliers", supplier);
            await SetSuppliers(result);
        }
        public async Task UpdateSupplierAsync(Supplier supplier)
        {
            var result = await _http.PutAsJsonAsync($"api/suppliers/{supplier.Id}", supplier);
            await SetSuppliers(result);
        }

        public async Task DeleteSupplierAsync(int id)
        {
            var result = await _http.DeleteAsync($"api/suppliers/{id}");
            await SetSuppliers(result);
        }

        private async Task SetSuppliers(HttpResponseMessage result)
        {
            var response = await result.Content.ReadFromJsonAsync<List<Supplier>>();
            Suppliers = response;
            _navgationManager.NavigateTo("suppliers");
        }

    }
}
