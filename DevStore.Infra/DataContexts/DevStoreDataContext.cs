using Dev.Store.Domain;
using DevStore.Infra.Mappings;
using System.Data.Entity;

namespace DevStore.Infra.DataContexts
{
    public class DevStoreDataContext : DbContext
    {
        public DevStoreDataContext() : base("DevStoreConnectionString")
        {
            Database.SetInitializer<DevStoreDataContext>(new DevStoreDataContextInitializer());
        }

        public IDbSet<Product> Products { get; set; }

        public IDbSet<Category> Categories { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new ProductMap());
            modelBuilder.Configurations.Add(new CategoryMap());
            base.OnModelCreating(modelBuilder);
        }


    }

    public class DevStoreDataContextInitializer : DropCreateDatabaseIfModelChanges<DevStoreDataContext>
    {
        protected override void Seed(DevStoreDataContext context)
        {
            context.Categories.Add(new Category { Id = 1, Title = "Informática" });
            context.Categories.Add(new Category { Id = 2, Title = "Games" });
            context.Categories.Add(new Category { Id = 3, Title = "Papelaria" });
            context.SaveChanges();

            context.Products.Add(new Product { Id = 1, CategoryId = 1, IsActive = true, Title = "Mouse Razer Deathadder", Price = 350 });
            context.Products.Add(new Product { Id = 2, CategoryId = 1, IsActive = true, Title = "Teclado Razer", Price = 300 });
            context.Products.Add(new Product { Id = 3, CategoryId = 1, IsActive = true, Title = "Mouse Pad Razer Goliathus", Price = 100 });
            context.Products.Add(new Product { Id = 4, CategoryId = 1, IsActive = true, Title = "Headset Razer Kraken", Price = 250 });


            context.Products.Add(new Product { Id = 5, CategoryId = 2, IsActive = true, Title = "Metal Gear Solid", Price = 59 });
            context.Products.Add(new Product { Id = 6, CategoryId = 2, IsActive = true, Title = "Metal Gear Solid 2", Price = 79 });
            context.Products.Add(new Product { Id = 7, CategoryId = 2, IsActive = true, Title = "Metal Gear Solid 3", Price = 99 });

            context.Products.Add(new Product { Id = 8, CategoryId = 3, IsActive = true, Title = "Papel A4 1000 folhas", Price = 9.90M });
            context.SaveChanges();

            base.Seed(context);
        }

    }

}
