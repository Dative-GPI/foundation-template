using System;
using System.Threading.Tasks;

using Foundation.Template.Gateway.ViewModels;

namespace Foundation.Template.Gateway.Abstractions
{
    public interface IImageService
    {
        Task<byte[]> GetRaw(Guid id);
        Task<byte[]> GetThumbnail(Guid id);
    }
}