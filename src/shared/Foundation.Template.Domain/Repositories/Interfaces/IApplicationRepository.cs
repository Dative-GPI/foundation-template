using System;
using System.Threading.Tasks;
using Bones.Repository.Interfaces;

using Foundation.Template.Domain.Models;
using Foundation.Template.Domain.Repositories.Commands;

namespace Foundation.Template.Domain.Repositories.Interfaces 
{
    public interface IApplicationRepository 
    {
        Task<ApplicationDetails> Get(Guid applicationId);
        Task<IEntity<Guid>> Create(CreateApplication payload);
        Task<IEntity<Guid>> Update(UpdateApplication payload);
        Task Remove(Guid id);
    }
}