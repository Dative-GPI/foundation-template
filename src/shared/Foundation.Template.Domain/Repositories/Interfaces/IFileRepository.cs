using System;
using System.Threading.Tasks;

using Bones.Repository.Interfaces;

using Foundation.Template.Domain.Models;
using Foundation.Template.Domain.Repositories.Commands;

namespace Foundation.Template.Domain.Repositories.Interfaces
{
    public interface IFileRepository
    {
        Task<IEntity<Guid>> Create(CreateFile payload);
        Task<FileDetails> Get(Guid id);
        Task Remove(Guid id);
    }
}