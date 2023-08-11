using System.Threading.Tasks;
using Foundation.Template.Context.Models;

namespace Foundation.Template.Context.Abstractions
{
    public interface IImageHelper
    {
        Task<Image> Compute(byte[] data, int maxSize);
    }
}