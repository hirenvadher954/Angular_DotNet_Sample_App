using System;
using Microsoft.AspNetCore.Mvc;

namespace WebApplication1.Controllers;

[ApiController]
[Route("[controller]")]
public class StudentController : ControllerBase
{
    private readonly List<Student> _students = new();

    private static readonly string[] Name = new[]
    {
        "Hetav", "Bharat", "ABC", "CDE",
    };

    private readonly ILogger<StudentController> _logger;

    public StudentController(ILogger<StudentController> logger)
    {
        _logger = logger;
    }

    [HttpGet(Name = "GetStudentDetails")]
    public IEnumerable<Student> Get()
    {
        return Enumerable.Range(1, 5).Select(index => new Student
            {
                id = Random.Shared.Next(5),
                Dob = DateTime.Now.AddDays(index),
                Name = Name[Random.Shared.Next(Name.Length)],
                Address = Name[Random.Shared.Next(Name.Length)]
            })
            .ToArray();
    }

    [HttpPost(Name = "SaveStudentDetails")]
    public IEnumerable<Student> Post([FromBody] Student student)
    {
        _students.Add(student);
        return _students;
    }

    [HttpPut(Name = "UpdateStudentDetails")]
    public IEnumerable<Student> Update([FromBody] Student student)
    {
        _students.Add(student);
        return _students;
    }

    [HttpDelete("{id:int}", Name = "DeleteStudentDetails")]
    public String Delete(int id)
    {
        return "Delete succefully";
    }
}