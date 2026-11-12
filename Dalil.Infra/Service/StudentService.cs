using ApiCe.Core.courses;
using ApiCe.Core.Entites;
using dalil.Core.Exptions;
using Dalil.Core.Mappings;
using FluentValidation;
using Dalil.Infra.Repository;
using dalil.Core.Repository;
using Dalil.Infra.Data;
using ApiCe.Core.Interfaces;
using dalil.Core;
using Microsoft.EntityFrameworkCore;
using System.Text;
using System.Collections.Generic;

using ApiCe.Core.Services;
using ApiCe.Core.Students;
namespace ApiCe.Infra.Repositories
{
    public class StudentService(IStudentRepository studentRepository, IValidator<CreateSTDDto> validator) : IStudentService
    {
        public async Task<List<STDResposDto>> GetAllAsync()
        {
            var students = await studentRepository.GetAllAsync();
            return students.Select(s => s.ToDto()).ToList();
        }

        public async Task<STDResposDto?> GetByIdAsync(int id)
        {
            var student = await studentRepository.GetByIdAsync(id) ?? throw new NotFoundExption($"Student {id} was not found");
            return student.ToDto();
        }

        public async Task<STDResposDto> CreateAsync(CreateSTDDto dto)
        {
            await validator.ValidateAndThrowAsync(dto);
            var student = dto.ToEntity();
            var created = await studentRepository.CreateAsync(student);
            return created.ToDto();
        }

        public async Task UpdateAsync(int id, UpdateSTSDto dto)
        {
            var std = await studentRepository.GetByIdAsync(id) ?? throw new NotFoundExption($"Student {id} was not found");
            
            std.FullName = dto.FullName;
            std.Email = dto.Email;
            std.phone = dto.Phone;

            await studentRepository.UpdateAsync(std);
        }

        public async Task DeleteAsync(int id)
        {
            if (!await studentRepository.DeleteAsync(id))
                throw new NotFoundExption($"Student {id} was not found");
        }
    }
}