using System;
using Foundation.Template.Core.Models;
using Foundation.Template.Core.Abstractions;

namespace Foundation.Template.Core.Tools
{
    public class RequestContextProvider : IRequestContextProvider
    {
        public RequestContext Context { get; set; }
    }
}