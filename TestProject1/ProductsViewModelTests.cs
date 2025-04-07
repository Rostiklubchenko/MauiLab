using MAUISql.Models;
using MAUISql.Tests;
using MAUISql.ViewModels;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace MAUISql.UnitTests
{
    public class ProductTests
    {
        [Fact]
        public async Task Can_Add_New_Product()
        {
                         var context = new TestDatabaseContext();
            var vm = new ProductsViewModel(context);

            vm.SetOperatingProduct(new Product { Name = "Test Product", Price = 9.99m });

            
            await vm.SaveProductAsync();

            
            Assert.Single(vm.Products);
            Assert.Equal("Test Product", vm.Products.First().Name);
        }

        [Fact]
        public async Task Can_Delete_Product()
        {
            
            var context = new TestDatabaseContext();
            var vm = new ProductsViewModel(context);

            
            var product = new Product { Name = "To Delete", Price = 5.00m };
            await context.AddItemAsync(product); 

            
            await vm.LoadProductsAsync();
            var productBeforeDelete = vm.Products.FirstOrDefault(p => p.Name == "To Delete");

            
            Assert.NotNull(productBeforeDelete);

            
            await vm.DeleteProductAsync(productBeforeDelete.Id);

            
            await vm.LoadProductsAsync(); 
            Assert.DoesNotContain(vm.Products, p => p.Id == productBeforeDelete.Id); 
        }



        [Fact]
        public async Task Invalid_Product_Should_Not_Save()
        {
            var invalidProduct = new Product { Name = "", Price = 0 };

            Assert.False(invalidProduct.Validate().IsValid);
        }


    }
}
