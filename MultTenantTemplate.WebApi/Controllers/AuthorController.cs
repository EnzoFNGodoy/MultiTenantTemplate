using Microsoft.AspNetCore.Mvc;
using MultiTenantTemplate.Application.Interfaces;
using MultiTenantTemplate.Application.ViewModels.Authors;
using System.Web.Http.OData;

namespace MultTenantTemplate.WebApi.Controllers;

[Route("authors")]
public sealed class AuthorController : ControllerBase
{
    private readonly IAuthorServices _authorServices;

    public AuthorController(IAuthorServices authorServices)
    {
        _authorServices = authorServices;
    }

    [EnableQuery]
    [HttpGet]
    public async Task<IQueryable<ResponseAuthorViewModel>> GetAll()
        => (await _authorServices.GetAll()).AsQueryable();

    [HttpGet("{id}")]
    public async Task<ResponseAuthorViewModel> GetById(Guid id)
        => await _authorServices.GetById(id);

    [HttpPost]
    public async Task<IActionResult> Post(RequestAuthorViewModel viewModel)
        => Ok(await _authorServices.Create(viewModel));

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(Guid id, RequestAuthorViewModel viewModel)
       => Ok(await _authorServices.Update(id, viewModel));

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(Guid id)
    {
        var response = await _authorServices.Delete(id);

        return response is true
            ? Ok(await _authorServices.Delete(id))
            : BadRequest("Erro ao deletar o Autor.");
    }
}