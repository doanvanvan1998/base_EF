﻿using JWTAuthentication.NET6._0.Mappers.Contracts;
using JWTAuthentication.NET6._0.Models.Models;
using JWTAuthentication.NET6._0.Repositories.Contracts;
using JWTAuthentication.NET6._0.Services.Contracts;

namespace JWTAuthentication.NET6._0.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryMapper _categoryMapper;
        private readonly ICategoryRepository _categoryRepository;
        public CategoryService(ICategoryMapper categoryMapper, ICategoryRepository categoryRepository)
        {
            _categoryMapper = categoryMapper;
            _categoryRepository = categoryRepository;
        }

        public CategoryDTO AddCategory(CategoryModel categoryModel)
        {
            CategoryEntity categoryEntity = _categoryMapper.MapToCategory(categoryModel);
            CategoryEntity addedCategory = _categoryRepository.AddCategory(categoryEntity);
            _categoryRepository.SaveChanges();
            return _categoryMapper.MapToCategoryDTO(addedCategory);
        }

        public bool DeleteCategory(int categoryId)
        {
           CategoryEntity? categoryEntity = _categoryRepository.GetCategoryById(categoryId);
            if (categoryEntity != null)
            {
                _categoryRepository.DeleteCategory(categoryEntity);
                return true;
            }
            return false;
        }

        public List<CategoryDTO> GetCategories()
        {
            List<CategoryEntity> categories = _categoryRepository.getAll();
            return categories.Select(c => _categoryMapper.MapToCategoryDTO(c)).ToList();
        }

        public CategoryDTO? GetCategoryById(int categoryId)
        {
            CategoryEntity? categoryEntity = _categoryRepository.GetCategoryById(categoryId);
            if (categoryEntity != null)
            {
                return _categoryMapper.MapToCategoryDTO(categoryEntity);
            }
            return null;
        }

        public bool UpdateCategory(int categoryId, CategoryModel categoryModel)
        {
            CategoryEntity categoryEntity = _categoryMapper.MapToCategory(categoryModel);
            return _categoryRepository.UpdateCategory(categoryEntity);
        }

        public void SaveChanges()
        {
            _categoryRepository.SaveChanges();
        }
    }
}
