
namespace OrderManagementApp.Server.Data
{
    public class OrderManagementAppDataContext : DbContext
    {
        public OrderManagementAppDataContext(DbContextOptions<OrderManagementAppDataContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<State>().HasData(
                new State { Id = 1, Name = "Texas" },
                new State { Id = 2, Name = "California" }
                );

            modelBuilder.Entity<Supplier>().HasData(
                    new Supplier
                    {
                        Id = 1,
                        SupplierName = "Beximco",
                        AddressLine1 = "Dhaka 1",
                        AddressLine2 = "Dhaka 2",
                        City = "Dhaka",
                        PostalCode = "1230",
                        StateId = 1
                    },
                    new Supplier
                    {
                        Id = 2,
                        SupplierName = "Square",
                        AddressLine1 = "Chaitagong 1",
                        AddressLine2 = "Chaitagong 2",
                        City = "Chaitagong",
                        PostalCode = "1250",
                        StateId = 2
                    }
                );
        }

        public DbSet<Supplier> Suppliers { get; set; }
        public DbSet<State> States { get; set; }
    }
}
