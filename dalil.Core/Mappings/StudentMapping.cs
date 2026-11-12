using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using ApiCe.Core.courses;
using ApiCe.Core.Entites;
using ApiCe.Core.Students;
using dalil.Core.Repository;
using Dalil.Core.Mappings;
namespace Dalil.Core.Mappings
{
    public static class StudentMapping
    {
        public static STDResposDto ToDto(this Student student)
        {
            return new STDResposDto(student.Id,student.FullName,student.Email,student.phone,student.UserId);
        }
          public static Student ToEntity(this CreateSTDDto dto)
        {
            return new Student {
                FullName=dto.FullName,
                Email = dto.Email,
                phone= dto.Phone 
                
                };
        }
    }
}
