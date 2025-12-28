using System.Runtime.CompilerServices;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Todo.Data;
using Todo.Models;

namespace Todo.Controllers;

[ApiController]

public class TodoController : ControllerBase
{
    [HttpGet("/")]
    public /*List<TodoModel>*/ IActionResult Get([FromServices] AppDbContext context)
        //return Ok(context.Todos.ToList());
        => Ok(context.Todos.ToList());

    [HttpGet("/{id:int}")]
    public IActionResult/*TodoModel*/ GetById([FromRoute] int id, [FromServices] AppDbContext context)
    {
        // return context.Todos.FirstOrDefault(x => x.Id == id);
        var todos = context.Todos.FirstOrDefault(x => x.Id == id);
        if (todos == null)
            return NotFound();
        return Ok(todos);
    }


    [HttpPost("/")]
    public /*TodoModel*/ IActionResult Post([FromBody] TodoModel todo, [FromServices] AppDbContext context)
    {
        context.Todos.Add(todo);
        context.SaveChanges();

        //return todo;
        return Created($"/{todo.Id}", todo);
    }
    [HttpPut("/{id:int}")]
    public /*TodoModel*/ IActionResult Put(
            [FromRoute] int id,
            [FromBody] TodoModel todo,
            [FromServices] AppDbContext context)
    {
        var model = context.Todos.FirstOrDefault(x => x.Id == id);
        if (model == null)
        {
            return NotFound();
        }
        model.Title = todo.Title;
        model.Done = todo.Done;

        context.Todos.Update(model);
        context.SaveChanges();

        return Ok(todo);

    }
    [HttpDelete("/{id:int}")]
    public /*TodoModel*/ IActionResult Delete(
           [FromRoute] int id,
           [FromServices] AppDbContext context)
    {
        var model = context.Todos.FirstOrDefault(x => x.Id == id);

        if (model == null)
            return NotFound();

        context.Todos.Remove(model);
        context.SaveChanges();


        return Ok(model);

    }
}