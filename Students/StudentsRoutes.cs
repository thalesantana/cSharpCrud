using cSharpCrud.Data;
using Microsoft.EntityFrameworkCore;

namespace cSharpCrud.Students;

public static class StudentsRoutes
{
  public static void AddRoutesStudents(this WebApplication app) {
    var studentsRoutes = app.MapGroup(prefix: "students");

    studentsRoutes.MapPost(pattern: "", 
    handler: async (AddStudentRequest request, AppDbContext context) => {
      var studentAlreadyExists = await context.Stutents.AnyAsync(
        student => student.Name == request.Name
      );

      if (studentAlreadyExists) {
        return Results.Conflict(error: "Student already exists");
      }

      var newStudent = new Student(request.Name);
      await context.Stutents.AddAsync(newStudent);
      await context.SaveChangesAsync();

      return Results.Ok(newStudent);
    });

    studentsRoutes.MapGet(pattern:"", handler: 
    async(AppDbContext context) =>{
      var students = await context
      .Stutents
      .Where(student => student.Active)
      .ToListAsync();
      
      return students;
    });
  }
}