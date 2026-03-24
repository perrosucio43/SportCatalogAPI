using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManager.Application.DTOs;
using TaskManager.Application.Interfaces.Repositories;
using TaskManager.Domain.Entities;

namespace TaskManager.Infrastructure.Persistence.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly AppDbContext _context;

        public ProductRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<(List<Product>, int)> GetAllAsync(PaginationParams p)
        {
            var query = _context.Products
                .AsNoTracking()
                .AsQueryable();

            var total = await query.CountAsync();

            var products = await query
                .Include(x => x.Category)
                .Skip((p.GetpageNumber() - 1) * p.GetPageSize())
                .Take(p.GetPageSize())
                .ToListAsync();

            return (products, total);
        }
        public async Task<Product> AddAsync(Product product)
        {
            _context.Products.Add(product);

            await _context.SaveChangesAsync();

            return product;
        }

        public async Task<bool> CategoryExists(Guid categoryId)
        {
            return await _context.Categories.AnyAsync(c => c.Id == categoryId);
        }
        public async Task<Product?> GetByIdAsync(Guid id)
        {
            return await _context.Products
                .Include(p => p.Category)
                .FirstOrDefaultAsync(p => p.Id == id);
        }
        public async Task<List<Product>> GetAllNoPaginationAsync()
        {
            return await _context.Products
                .Include(p => p.Category)
                .ToListAsync();
        }
        public async Task<List<Product>> GetByCategoryAsync(Guid categoryId)
        {
            return await _context.Products
                .Include(p => p.Category)
                .Where(p => p.CategoryId == categoryId)
                .ToListAsync();
        }

        public async Task DeleteAsync(Guid id)
        {
            var product = await _context.Products.FindAsync(id);

            if (product == null)
                throw new Exception("Product not found");

            _context.Products.Remove(product);

            await _context.SaveChangesAsync();
        }
    }
}
