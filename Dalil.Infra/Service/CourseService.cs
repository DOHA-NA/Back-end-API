
using dalil.Core.Repository;
using ApiCe.Core.Entites;
using System.Collections.Generic;
using dalil.Core;
using Microsoft.EntityFrameworkCore;
using System.Text;
using System.Net.Http.Headers;
using ApiCe.Infra.Data;
using Dalil.Core.Mappings;
using ApiCe.Core.courses;
using FluentValidation;
using dalil.Core.Exptions;
namespace Dalil.Infra.Repository
{
    public class  CourseService (ICourseRepository courseRepository,IValidator<CreateCourseDto>validator): ICourseService
    {
       public  Task< List<CourseResposDto>>GetAllAsnyc()
        {
            return courseRepository.GetAllAsnyc();
            // var courses= await courseRepository.GetAllAsnyc();
            // return courses.Select(c => CourseMapping.ToDto(c)).ToList();
        }
       public async Task<CourseResposDto?> GetByIDAsnyc(int id)
        {
            var course=await courseRepository.GetByIDAsnyc(id) ?? throw new NotFoundExption($"courses {id} was not found");
            return course?.ToDto();
        }
       public 
        async Task<CourseResposDto> CreateAsnyc(CreateCourseDto dto)
        {
            await validator.ValidateAndThrowAsync(dto);
            var coures=dto.ToEntity();
            var created = await courseRepository.CreateAsnyc(coures);
              return created.ToDto();
        }
       public async Task UpdateAsnyc( int id,Course input)
        {
            var Cou = await courseRepository.GetByIDAsnyc(id)?? throw new NotFoundExption($"courses {id} was not found");
            Cou.Title = input.Title;
             Cou.Price = input.Price;

            await courseRepository.UpdateAsnyc(Cou);
        }
        public  async Task DeleteAsnyc(int id)
        {
            if(! await courseRepository.DeleteAsnyc(id))
             throw new NotFoundExption($"courses {id} was not found");
        }
    }
}
