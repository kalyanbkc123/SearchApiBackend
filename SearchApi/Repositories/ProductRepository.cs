using Microsoft.EntityFrameworkCore;

using SearchApi.Data;
using SearchApi.Models;


namespace SearchApi.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly ApplicationDbContext _dbcontext;

        public ProductRepository(ApplicationDbContext dbcontext)
        {
            _dbcontext = dbcontext;
        }

        public async Task<IEnumerable<Product>> GetAllProductsAsync()
        {
            return await _dbcontext.Products.ToListAsync();
        }

        public async Task<IEnumerable<Product>> GetProductsByTitleAsync(string title)
        {
            return await _dbcontext.Products
                .Where(p => p.Title.Contains(title))
                .ToListAsync();
        }
        /*
        public async Task<IEnumerable<Product>> GetProductsByTitleOrFeaturesAsync(string searchTerm)
        {
            return await _dbcontext.Products
                .Where(p => p.Title.Contains(searchTerm) || p.Features.Contains(searchTerm))
                .ToListAsync();
        }
        */





        public async Task<Product> GetProductByIdAsync(int id) {
            
            return await _dbcontext.Products.FindAsync(id);

        }
        public async Task<Product> AddProductAsync(Product product)
        {
            await _dbcontext.Products.AddAsync(product);
            await _dbcontext.SaveChangesAsync();

            return product;

        }

        public async Task UpdateProductAsync(Product product) 
        {
            _dbcontext.Products.Update(product);
            await _dbcontext.SaveChangesAsync();


        }

        public async Task DeleteProductAsync(int id)
        {
            var product = await GetProductByIdAsync(id);
            if (product != null) _dbcontext.Products.Remove(product);
        }

        public async Task<IEnumerable<Product>> GetProductsByTitleOrFeaturesAsync(string searchTerm)
        {
            return await _dbcontext.Products
                .Where(p => p.Title.Contains(searchTerm) || p.Features.Contains(searchTerm))
                .ToListAsync();
        }

        public async Task<IEnumerable<Product>> GetProductsByMultipleSearchTermsAsync(string[] searchTerms)
        {
            return await _dbcontext.Products
                .Where(p => searchTerms.Any(term => p.Title.Contains(term) || p.Features.Contains(term)))
                .ToListAsync();
        }




    }

}
