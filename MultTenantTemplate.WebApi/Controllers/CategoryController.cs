using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MultiTenantTemplate.Application.Interfaces;
using MultiTenantTemplate.Application.ViewModels.Categories;
using System.Web.Http.OData;

namespace MultTenantTemplate.WebApi.Controllers;

[Authorize]
[Route("categories")]
public sealed class CategoryController : ControllerBase
{
    private readonly ICategoryServices _categoryServices;

    public CategoryController(ICategoryServices categoryServices)
    {
        _categoryServices = categoryServices;
    }

    [EnableQuery]
    [HttpGet]
    public async Task<IQueryable<ResponseCategoryViewModel>> GetAll()
        => (await _categoryServices.GetAll()).AsQueryable();

    [HttpGet("{id}")]
    public async Task<ResponseCategoryViewModel> GetById(Guid id)
        => await _categoryServices.GetById(id);

    [HttpPost]
    public async Task<IActionResult> Post([FromBody] RequestCategoryViewModel viewModel)
        => Ok(await _categoryServices.Create(viewModel));

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(Guid id, [FromBody] RequestCategoryViewModel viewModel)
       => Ok(await _categoryServices.Update(id, viewModel));

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(Guid id)
    {
        var response = await _categoryServices.Delete(id);

        return response is true
            ? Ok(await _categoryServices.Delete(id))
            : BadRequest("Erro ao deletar o Autor.") ;
    }
}