using System;
using System.Collections.Generic;
using System.Text;
using ApiCe.Core.Entites;

namespace ApiCe.Core.Students
{
        public record CreateSTDDto (string FullName ,string Email ,string Phone);
        // public record DeleteSTDDto (int id );
        public record STDResposDto (int Id,string FullName ,string Email ,string?Phone,string?UserId);
     public record UpdateSTSDto (int Id,string FullName ,string Email ,string?Phone);


    //     public string Title { get; init; } 

    //     public decimal Price { get; init; }

    //     public int InstructorId { get; init; }
    }
