using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Query;
using Microsoft.EntityFrameworkCore;
using MultiTenantTemplate.Application.Interfaces;
using MultiTenantTemplate.Application.ViewModels.Users;
using MultiTenantTemplate.Domain.Entities;

namespace MultTenantTemplate.WebApi.Controllers;

[Route("users")]
public class UserController : ControllerBase
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

    [HttpPost("auth")]
    public async Task<IActionResult> Login(RequestUserLoginViewModel viewModel)
        => Ok(await _userServices.Login(viewModel));

    [HttpPost]
    public async Task<IActionResult> Post(RequestUserViewModel viewModel)
    {
        var response = await _userServices.Create(viewModel);

        return CreatedAtAction("GetById", new { id = response.Id }, response);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(Guid id, RequestUserViewModel viewModel)
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