using HelpApp.Domain.Entities;
using HelpApp.Domain.Interfaces;
using HelpApp.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace HelpApp.Infra.Data.Repositories
{
    public class ProductRepository : IProductRepository
    {
        #region Fields
        private readonly ApplicationDbContext _dbcontext;
        #endregion
        
        #region Constructor
        public ProductRepository(ApplicationDbContext dbcontext)
        {
            _dbcontext = dbcontext;
        }
        #endregion

        #region Methods
        public async Task<IEnumerable<Product>> GetProducts()
        {
            var products = await _dbcontext.Products.Include(product => product.Category).AsNoTracking().ToListAsync();
            return products;
        }

        public async Task<Product> GetById(int? id)
        {
            ValidateId(id);
            var product = await _dbcontext.Products.Include(product => product.Category).AsNoTracking().FirstOrDefaultAsync(product => product.Id == id);
            return product;
        }

        public async Task<Product> Create(Product product)
        {
            ValidateProduct(product);
            _dbcontext.Products.Add(product);
            await _dbcontext.SaveChangesAsync();
            return product;
        }

        public async Task<Product> Update(Product product)
        {
            ValidateProduct(product);
            _dbcontext.Products.Update(product);
            await _dbcontext.SaveChangesAsync();
            return product;
        }

        public async Task<Product> Remove(Product product)
        {
            ValidateProduct(product);
            _dbcontext.Products.Remove(product);
            await _dbcontext.SaveChangesAsync();
            return product;
        }
        #endregion

        #region Validation
        private void ValidateProduct(Product? product)
        {
            if (product == null)
                throw new ArgumentNullException(nameof(product), "Product is required.");
        }

        public void ValidateId(int? id)
        {
            if (!id.HasValue || id <= 0)
                throw new ArgumentOutOfRangeException("Product Id must be a positive.", nameof(id));
        }
        #endregion
    }
}
