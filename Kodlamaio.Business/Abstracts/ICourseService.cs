using Kodlamaio.Business.Dtos.Requests;
using Kodlamaio.Business.Dtos.Responses;
using Kodlamaio.Entities.Concretes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kodlamaio.Business.Abstracts;

public interface ICourseService
{
    List<GetAllCourseResponse> GetAll();
    Course GetCourse(int id);
    UpdateCourseRequest GetCourseUpdate(int id);
    CreatedCourseResponse Add(CreateCourseRequest createCourseRequest);
    UpdatedCourseResponse Update(UpdateCourseRequest updateCourseRequest);
    List<GetAllCourseResponse> GetCourseByCategory(int categoryId);
    void Delete(int id);
}
