using JWTAuthentication.NET6._0.Auth;
using JWTAuthentication.NET6._0.Data;
using JWTAuthentication.NET6._0.Models.Models;
using JWTAuthentication.NET6._0.Repositories.Contracts;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace JWTAuthentication.NET6._0.Repositories
{
    public class ProductRepository : BaseRepository, IProductRepository
    {
        private readonly ApplicationDbContext _context;
        public ProductRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }
        public ProductEntity? AddProduct(ProductEntity product)
        {
            CategoryEntity? categoryEntity = _context.categories.FirstOrDefault(c => c.CategoryId == product.CategoryId);
            if (categoryEntity == null)
                throw new Exception("Category not found with id: " + product.CategoryId);
            EntityEntry<ProductEntity> entityEntry = _context.products.Add(product);
            return entityEntry.Entity;
        }

        public bool DeleteProduct(ProductEntity product)
        {
            try {                
                _context.products.Remove(product);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public List<ProductEntity> GetAll()
        {
            return _context.products.ToList();
        }

        public ProductEntity? GetProductById(int productId)
        {
            return _context.products.FirstOrDefault(p => p.ProductId == productId);
        }

        public bool UpdateProduct(ProductEntity product)
        {
            ProductEntity? productEntity = GetProductById(product.ProductId);
            if(productEntity == null)
                return false;
            else
                _context.Entry(productEntity).State = EntityState.Detached;
            _context.Attach(product);
            _context.Entry(product).State = EntityState.Modified;
            return true;
        }
    }
}
