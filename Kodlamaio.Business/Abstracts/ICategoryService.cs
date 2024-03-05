using Kodlamaio.Business.Dtos.Requests;
using Kodlamaio.Business.Dtos.Responses;
using Kodlamaio.Entities.Concretes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kodlamaio.Business.Abstracts;

public interface ICategoryService
{
    List<GetAllCategoryResponse> GetAll();
    Category GetCategory(int id);
    UpdateCategoryRequest GetCategoryUpdate(int id);
    CreatedCategoryResponse Add(CreateCategoryRequest createCategoryRequest);
    UpdatedCategoryResponse Update(UpdateCategoryRequest updateCategoryRequest);
    void Delete(int id);
}
