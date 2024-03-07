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

public class CourseManager : ICourseService
{
    private readonly ICourseDal _courseDal;

    public CourseManager(ICourseDal courseDal)
    {
        _courseDal = courseDal;
    }
    public List<GetAllCourseResponse> GetAll()
    {
        List<Course> courses = _courseDal.GetAll();
        List<GetAllCourseResponse> getAllCourseResponses = new List<GetAllCourseResponse>();

        foreach (Course course in courses)
        {
            GetAllCourseResponse getAllCourseResponse = new GetAllCourseResponse();
            getAllCourseResponse.Id = course.Id;
            getAllCourseResponse.CategoryId = course.CategoryId;
            getAllCourseResponse.Title = course.Title;
            getAllCourseResponse.Description = course.Description;
            getAllCourseResponse.CreatedDate = course.CreatedDate;
            getAllCourseResponse.ImageUrl = course.ImageUrl;
            getAllCourseResponse.UpdatedDate = course.UpdatedDate;

            getAllCourseResponses.Add(getAllCourseResponse);
        }

        return getAllCourseResponses;
    }

    public Course GetCourse(int id)
    {
        Course course = _courseDal.Get(crs => crs.Id == id);

        return course;
    }

    public CreatedCourseResponse Add(CreateCourseRequest createCouseRequest)
    {
        Course course = new();
        course.CategoryId = createCouseRequest.CategoryId;
        course.Title = createCouseRequest.Title;
        course.Description = createCouseRequest.Description;
        course.ImageUrl = createCouseRequest.ImageUrl;

        _courseDal.Add(course);

        CreatedCourseResponse createdCourseResponse = new CreatedCourseResponse();
        createdCourseResponse.CategoryId = course.CategoryId;
        createdCourseResponse.Title = course.Title;
        createdCourseResponse.Description = course.Description;
        createdCourseResponse.CreatedDate = course.CreatedDate;
        createdCourseResponse.ImageUrl = course.ImageUrl;

        return createdCourseResponse;
    }


    public UpdateCourseRequest GetCourseUpdate(int id)
    {
        Course course = GetCourse(id);

        UpdateCourseRequest updateCourseRequest = new UpdateCourseRequest();
        updateCourseRequest.Id = course.Id;
        updateCourseRequest.CategoryId = course.CategoryId;
        updateCourseRequest.Title = course.Title;
        updateCourseRequest.Description = course.Description;
        updateCourseRequest.ImageUrl = course.ImageUrl;
        return updateCourseRequest;
    }

    public UpdatedCourseResponse Update(UpdateCourseRequest updateCourseRequest)
    {
        Course course = GetCourse(updateCourseRequest.Id);
        course.CategoryId = updateCourseRequest.CategoryId;
        course.Title = updateCourseRequest.Title;
        course.Description = updateCourseRequest.Description;
        course.ImageUrl = updateCourseRequest.ImageUrl;
        course.UpdatedDate = DateTime.Now;

        _courseDal.Update(course);

        UpdatedCourseResponse updatedCourseResponse = new UpdatedCourseResponse();
        updatedCourseResponse.CategoryId = course.CategoryId;
        updatedCourseResponse.Title = course.Title;
        updatedCourseResponse.Description = course.Description;
        updatedCourseResponse.ImageUrl = course.ImageUrl;
        updatedCourseResponse.UpdatedDate = DateTime.Now;

        return updatedCourseResponse;
    }

    public void Delete(int id)
    {
        Course course = GetCourse(id);
        _courseDal.Delete(course);
    }

    public List<GetAllCourseResponse> GetCourseByCategory(int categoryId)
    {
        List<Course> courses = _courseDal.GetAll(crs => crs.CategoryId == categoryId);

        List<GetAllCourseResponse> getAllCourseResponses = new List<GetAllCourseResponse>();

        foreach (Course course in courses)
        {
            GetAllCourseResponse getAllCourseResponse = new GetAllCourseResponse();
            getAllCourseResponse.Id = course.Id;
            getAllCourseResponse.CategoryId = course.CategoryId;
            getAllCourseResponse.Title = course.Title;
            getAllCourseResponse.Description = course.Description;
            getAllCourseResponse.CreatedDate = course.CreatedDate;
            getAllCourseResponse.ImageUrl = course.ImageUrl;
            getAllCourseResponse.UpdatedDate = course.UpdatedDate;

            getAllCourseResponses.Add(getAllCourseResponse);
        }

        return getAllCourseResponses;
    }
}
