﻿using HelpApp.Domain.Entities;
using HelpApp.Domain.Interfaces;
using HelpApp.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace HelpApp.Infra.Data.Repositories
{
    public class CategoryRepository : ICategoryRepository
    {
        #region Fields
        private readonly ApplicationDbContext _dbContext;
        #endregion

        #region Constructor
        public CategoryRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        #endregion

        #region Methods
        public async Task<IEnumerable<Category>> GetCategories()
        {
            var categories = await _dbContext.Categories.AsNoTracking().OrderBy(category => category.Name).ToListAsync();
            return categories;
        }

        public async Task<Category> GetById(int? id)
        {
            ValidateId(id);
            var category = await _dbContext.Categories.FindAsync(id);
            return category;
        }

        public async Task<Category> Create(Category category)
        {
            ValidateCategory(category);
            _dbContext.Categories.Add(category);
            await _dbContext.SaveChangesAsync();
            return category;
        }

        public async Task<Category> Update(Category category)
        {
            ValidateCategory(category);
            _dbContext.Categories.Update(category);
            await _dbContext.SaveChangesAsync();
            return category;
        }

        public async Task<Category> Remove(Category category)
        {
            ValidateCategory(category);
            _dbContext.Categories.Remove(category);
            await _dbContext.SaveChangesAsync();
            return category;
        }
        #endregion

        #region Validation
        private void ValidateCategory(Category? category)
        {
            if (category == null)
                throw new ArgumentNullException(nameof(category), "Category is required.");
        }
        private void ValidateId(int? id)
        {
            if (!id.HasValue || id <= 0)
                throw new ArgumentException("Id must be positive.", nameof(id));
        }
        #endregion
    }
}
