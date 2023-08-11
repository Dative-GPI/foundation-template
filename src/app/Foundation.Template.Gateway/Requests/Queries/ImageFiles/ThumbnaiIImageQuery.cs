using System;

using Bones.Flow;

namespace Foundation.Template.Gateway
{
    public class ThumbnailImageQuery : IRequest<byte[]>
    {        
        public Guid Id { get; set; }
    }
}