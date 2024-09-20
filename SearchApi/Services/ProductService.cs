

using SearchApi.Models;
using SearchApi.Repositories;

namespace SearchApi.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _repository;

        public ProductService(IProductRepository repository)
        {
            _repository = repository;
        }

        public Task<IEnumerable<Product>> GetAllProductsAsync() => _repository.GetAllProductsAsync();
        public Task<Product> GetProductByIdAsync(int id) => _repository.GetProductByIdAsync(id);
        public Task<Product> AddProductAsync(Product product) => _repository.AddProductAsync(product);
        public Task UpdateProductAsync(Product product) => _repository.UpdateProductAsync(product);
        public Task DeleteProductAsync(int id) => _repository.DeleteProductAsync(id);

        public Task<IEnumerable<Product>> GetProductsByTitleAsync(string title)
        {
            return _repository.GetProductsByTitleAsync(title);
        }
        /*
        public Task<IEnumerable<Product>> GetProductsByTitleOrFeaturesAsync(string searchItem)
        {
            throw new NotImplementedException();
        }
        */

        /*
        public Task<IEnumerable<Product>> GetProductsByTitleOrFeaturesAsync(string searchTerm)
        {
            return _repository.GetProductsByTitleOrFeaturesAsync(searchTerm);


        }
        */
        /*
        public Task<IEnumerable<Product>> GetProductsByTitleOrFeaturesAsync(string searchTerm)
        {
            return _repository.GetProductsByTitleOrFeaturesAsync(searchTerm);
        }
        */

        public Task<IEnumerable<Product>> GetProductsByMultipleSearchTermsAsync(string[] searchTerms)
        {
            return _repository.GetProductsByMultipleSearchTermsAsync(searchTerms);
        }



    }
}
