



using SearchApi.Models;

namespace SearchApi.Services
{
    public interface IProductService
    {
        Task<IEnumerable<Product>> GetAllProductsAsync();


        Task<Product> GetProductByIdAsync(int id);


        Task<Product> AddProductAsync(Product product);


        Task UpdateProductAsync(Product product);

        Task DeleteProductAsync(int id);

        //Task<IEnumerable<Product>> GetProductsByTitleAsync(string title);

        //Task<IEnumerable<Product>> GetProductsByTitleOrFeaturesAsync(string searchItem);



        Task<IEnumerable<Product>> GetProductsByMultipleSearchTermsAsync(string[] searchTerms);

}

}
