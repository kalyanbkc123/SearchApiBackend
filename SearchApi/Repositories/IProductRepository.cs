


using SearchApi.Models;

namespace SearchApi.Repositories;

public interface IProductRepository
{
    Task<IEnumerable<Product>> GetAllProductsAsync();
    Task<Product> GetProductByIdAsync(int id);
    Task<Product> AddProductAsync(Product product);
    Task UpdateProductAsync(Product product);
    Task DeleteProductAsync(int id);

    Task<IEnumerable<Product>> GetProductsByTitleAsync(string title);

    //Task<IEnumerable<Product>> GetProductsByTitleOrFeaturesAsync(string title);

    // Task<IEnumerable<Product>> GetProductsByTitleOrFeaturesAsync(string searchTerm);

    Task<IEnumerable<Product>> GetProductsByMultipleSearchTermsAsync(string[] searchTerms);



}