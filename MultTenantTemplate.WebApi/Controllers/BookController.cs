using Microsoft.AspNetCore.Mvc;
using MultiTenantTemplate.Application.Interfaces;
using MultiTenantTemplate.Application.ViewModels.Books;
using System.Web.Http.OData;

namespace MultTenantTemplate.WebApi.Controllers;

[Route("books")]
public sealed class BookController : ControllerBase
{
    private readonly IBookServices _bookServices;

    public BookController(IBookServices bookServices)
    {
        _bookServices = bookServices;
    }

    [EnableQuery]
    [HttpGet]
    public async Task<IQueryable<ResponseBookViewModel>> GetAll()
        => (await _bookServices.GetAll()).AsQueryable();

    [HttpGet("{id}")]
    public async Task<ResponseBookViewModel> GetById(Guid id)
        => await _bookServices.GetById(id);

    [HttpPost]
    public async Task<IActionResult> Post(RequestBookViewModel viewModel)
        => Ok(await _bookServices.Create(viewModel));

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(Guid id, RequestBookViewModel viewModel)
       => Ok(await _bookServices.Update(id, viewModel));

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(Guid id)
    {
        var response = await _bookServices.Delete(id);

        return response is true
            ? Ok(await _bookServices.Delete(id))
            : BadRequest("Erro ao deletar o Autor.");
    }
}