using Kodlamaio.Business.Abstracts;
using Kodlamaio.Business.Dtos.Requests;
using Kodlamaio.Business.Dtos.Responses;
using Kodlamaio.DataAccess.Abstracts;
using Kodlamaio.Entities.Concretes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kodlamaio.Business.Concretes;

public class CategoryManager : ICategoryService
{
    private readonly ICategoryDal _categoryDal;

    public CategoryManager(ICategoryDal categoryDal)
    {
        _categoryDal = categoryDal;
    }

    public CreatedCategoryResponse Add(CreateCategoryRequest createCategoryRequest)
    {
        Category category = new();
        category.Title = createCategoryRequest.Title;

        _categoryDal.Add(category);

        CreatedCategoryResponse createdCategoryResponse = new CreatedCategoryResponse();
        createdCategoryResponse.Title = category.Title;
        createdCategoryResponse.CreatedDate = category.CreatedDate;

        return createdCategoryResponse;
    }

    public void Delete(int id)
    {
        Category category = GetCategory(id);
        _categoryDal.Delete(category);
    }

    public List<GetAllCategoryResponse> GetAll()
    {
        List<Category> categories = _categoryDal.GetAll();
        List<GetAllCategoryResponse> getAllCategoryResponses = new List<GetAllCategoryResponse>();

        foreach (Category category in categories)
        {
            GetAllCategoryResponse getAllCategoryResponse = new GetAllCategoryResponse();
            getAllCategoryResponse.Id = category.Id;
            getAllCategoryResponse.Title = category.Title;
            getAllCategoryResponse.CreatedDate = category.CreatedDate;
            getAllCategoryResponse.UpdatedDate = category.UpdatedDate;

            getAllCategoryResponses.Add(getAllCategoryResponse);
        }

        return getAllCategoryResponses;
    }

    public Category GetCategory(int id)
    {
        Category category = _categoryDal.Get(cat => cat.Id.Equals(id));

        return category;
    }

    public UpdateCategoryRequest GetCategoryUpdate(int id)
    {
        Category category = GetCategory(id);

        UpdateCategoryRequest updateCategoryRequest = new UpdateCategoryRequest();
        updateCategoryRequest.Id = category.Id;
        updateCategoryRequest.Title = category.Title;

        return updateCategoryRequest;
    }

    public UpdatedCategoryResponse Update(UpdateCategoryRequest updateCategoryRequest)
    {
        Category category = GetCategory(updateCategoryRequest.Id);
        category.Title = updateCategoryRequest.Title;
        category.UpdatedDate = DateTime.Now;

        _categoryDal.Update(category);

        UpdatedCategoryResponse updateCategoryResponse = new UpdatedCategoryResponse();
        updateCategoryResponse.Title = category.Title;
        updateCategoryResponse.UpdatedDate= DateTime.Now;

        return updateCategoryResponse;
    }
}
