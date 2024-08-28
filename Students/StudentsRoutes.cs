using cSharpCrud.Data;
using Microsoft.EntityFrameworkCore;

namespace cSharpCrud.Students;

public static class StudentsRoutes
{
  public static void AddRoutesStudents(this WebApplication app) {
    var studentsRoutes = app.MapGroup(prefix: "students");

    studentsRoutes.MapPost(pattern: "", 
    handler: async (AddStudentRequest request, AppDbContext context, CancellationToken ct) => {
      var studentAlreadyExists = await context.Stutents.AnyAsync(
        student => student.Name == request.Name,
        ct
      );

      if (studentAlreadyExists) {
        return Results.Conflict(error: "Student already exists");
      }

      var newStudent = new Student(request.Name);
      await context.Stutents.AddAsync(newStudent,ct);
      await context.SaveChangesAsync(ct);

      var studentReturn = new StudentDto(newStudent.Id, newStudent.Name);

      return Results.Ok(studentReturn);
    });

    studentsRoutes.MapGet(pattern:"", handler: 
    async(AppDbContext context, CancellationToken ct) =>{
      var students = await context
      .Stutents
      .Where(student => student.Active)
      .Select(student => new StudentDto(student.Id, student.Name))
      .ToListAsync(ct);

      return students;
    });

    studentsRoutes.MapPut("{id}", async(Guid id, UpdateStudentRequest request, AppDbContext context, CancellationToken ct) => {
      var student = await context.Stutents.SingleOrDefaultAsync(estudante => estudante.Id == id, ct);

      if (student == null) {
        return Results.NotFound();
      }
      
      student.UpdateStudent(request.Name);
      await context.SaveChangesAsync(ct);

      return Results.Ok(new StudentDto(student.Id, student.Name));
    });

    studentsRoutes.MapDelete("{id}", async(Guid id, AppDbContext context, CancellationToken ct) => {
      var student = await context.Stutents.FindAsync(id, ct);

      if (student == null) {
        return Results.NotFound();
      }

      student.Deactivate();
      await context.SaveChangesAsync(ct);

      return Results.Ok();
    });
  }
}