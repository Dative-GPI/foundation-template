using System;
using Bones.Flow;

namespace Foundation.Template.Gateway
{
    public class RawImageQuery : IRequest<byte[]>
    {        
        public Guid Id { get; set; }
    }
}