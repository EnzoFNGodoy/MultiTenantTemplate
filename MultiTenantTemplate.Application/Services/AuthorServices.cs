﻿using AutoMapper;
using MultiTenantTemplate.Application.Core;
using MultiTenantTemplate.Application.Interfaces;
using MultiTenantTemplate.Application.ViewModels.Authors;
using MultiTenantTemplate.Domain.Entities;
using MultiTenantTemplate.Domain.Interfaces;
using MultiTenantTemplate.Domain.Transactions;

namespace MultiTenantTemplate.Application.Services;

public sealed class AuthorServices :
    BaseServices<Author, IAuthorRepository, RequestAuthorViewModel, ResponseAuthorViewModel>,
    IAuthorServices
{
    public AuthorServices(
        IAuthorRepository repository, 
        IUnitOfWork unitOfWork, 
        IMapper mapper
        ) : base(repository, unitOfWork, mapper)
    { }
}