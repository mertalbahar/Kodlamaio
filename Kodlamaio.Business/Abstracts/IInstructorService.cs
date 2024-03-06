using Kodlamaio.Business.Dtos.Requests;
using Kodlamaio.Business.Dtos.Responses;
using Kodlamaio.Entities.Concretes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kodlamaio.Business.Abstracts;

public interface IInstructorService
{
    List<GetAllInstructorResponse> GetAll();
    Instructor GetInstructor(int id);
    UpdateInstructorRequest GetInstructorUpdate(int id);
    CreatedInstructorResponse Add(CreateInstructorRequest createInstructorRequest);
    UpdatedInstructorResponse Update(UpdateInstructorRequest updateInstructorRequest);
    void Delete(int id);
}
