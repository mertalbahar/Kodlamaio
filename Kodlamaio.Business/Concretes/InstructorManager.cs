using Kodlamaio.Business.Abstracts;
using Kodlamaio.Business.Dtos.Requests;
using Kodlamaio.Business.Dtos.Responses;
using Kodlamaio.DataAccess.Abstracts;
using Kodlamaio.DataAccess.Concretes.EntityFramework;
using Kodlamaio.Entities.Concretes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kodlamaio.Business.Concretes;

public class InstructorManager : IInstructorService
{
    private readonly IInstructorDal _instructorDal;

    public InstructorManager(IInstructorDal instructorDal)
    {
        _instructorDal = instructorDal;
    }

    public CreatedInstructorResponse Add(CreateInstructorRequest createInstructorRequest)
    {
        Instructor instructor = new();
        instructor.FirstName = createInstructorRequest.FirstName;
        instructor.LastName = createInstructorRequest.LastName;

        _instructorDal.Add(instructor);

        CreatedInstructorResponse createdInstructorResponse = new CreatedInstructorResponse();
        createdInstructorResponse.FirstName = instructor.FirstName;
        createdInstructorResponse.LastName = instructor.LastName;
        createdInstructorResponse.FullName = instructor.FullName;
        createdInstructorResponse.CreatedDate = instructor.CreatedDate;

        return createdInstructorResponse;
    }

    public void Delete(int id)
    {
        Instructor instructor = GetInstructor(id);
        _instructorDal.Delete(instructor);
    }

    public List<GetAllInstructorResponse> GetAll()
    {
        List<Instructor> instructors = _instructorDal.GetAll();
        List<GetAllInstructorResponse> getAllInstructorResponses = new List<GetAllInstructorResponse>();

        foreach (Instructor instructor in instructors)
        {
            GetAllInstructorResponse getAllInstructorResponse = new GetAllInstructorResponse();
            getAllInstructorResponse.Id = instructor.Id;
            getAllInstructorResponse.FirstName = instructor.FirstName;
            getAllInstructorResponse.LastName = instructor.LastName;
            getAllInstructorResponse.FullName= instructor.FullName;
            getAllInstructorResponse.CreatedDate = instructor.CreatedDate;
            getAllInstructorResponse.UpdatedDate = instructor.UpdatedDate;

            getAllInstructorResponses.Add(getAllInstructorResponse);
        }

        return getAllInstructorResponses;
    }

    public Instructor GetInstructor(int id)
    {
        Instructor instructor = _instructorDal.Get(ins => ins.Id.Equals(id));

        return instructor;
    }

    public UpdateInstructorRequest GetInstructorUpdate(int id)
    {
        Instructor instructor = GetInstructor(id);

        UpdateInstructorRequest updateInstructorRequest = new UpdateInstructorRequest();
        updateInstructorRequest.Id = instructor.Id;
        updateInstructorRequest.FirstName = instructor.FirstName;
        updateInstructorRequest.LastName = instructor.LastName;
        updateInstructorRequest.FullName = instructor.FullName;

        return updateInstructorRequest;
    }

    public UpdatedInstructorResponse Update(UpdateInstructorRequest updateInstructorRequest)
    {
        Instructor instructor = GetInstructor(updateInstructorRequest.Id);
        instructor.FirstName = updateInstructorRequest.FirstName;
        instructor.LastName = updateInstructorRequest.LastName;
        instructor.UpdatedDate = DateTime.Now;

        _instructorDal.Update(instructor);

        UpdatedInstructorResponse updatedInstructorResponse = new UpdatedInstructorResponse();
        updatedInstructorResponse.FirstName = instructor.FirstName;
        updatedInstructorResponse.LastName = instructor.LastName;
        updatedInstructorResponse.FullName = instructor.FullName;
        updatedInstructorResponse.UpdatedDate = DateTime.Now;

        return updatedInstructorResponse;
    }
}
