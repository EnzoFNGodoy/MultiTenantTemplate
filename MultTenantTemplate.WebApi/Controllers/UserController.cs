using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Query;
using MultiTenantTemplate.Application.Interfaces;
using MultiTenantTemplate.Application.ViewModels.Users;

namespace MultTenantTemplate.WebApi.Controllers;

[Authorize]
[Route("users")]
public sealed class UserController : ControllerBase
{
    private readonly IUserServices _userServices;

    public UserController(IUserServices userServices)
    {
        _userServices = userServices;
    }

    [EnableQuery]
    [HttpGet]
    public async Task<IQueryable<ResponseUserViewModel>> GetAll()
        => (await _userServices.GetAll()).AsQueryable();

    [HttpGet("{id}")]
    public async Task<ResponseUserViewModel> GetById(Guid id)
        => await _userServices.GetById(id);

    [HttpPost]
    public async Task<IActionResult> Post([FromBody] RequestUserViewModel viewModel)
    {
        var response = await _userServices.Create(viewModel);

        return CreatedAtAction("GetById", new { id = response.Id }, response);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(Guid id, [FromBody] RequestUserViewModel viewModel)
       => Ok(await _userServices.Update(id, viewModel));

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(Guid id)
    {
        var response = await _userServices.Delete(id);

        return response is true
            ? Ok(await _userServices.Delete(id))
            : BadRequest("Erro ao deletar o Usuário.");
    }
}