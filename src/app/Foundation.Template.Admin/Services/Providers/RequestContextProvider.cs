using System;

using Foundation.Template.Admin.Models;
using Foundation.Template.Admin.Abstractions;

namespace Foundation.Template.Admin.Tools
{
    public class RequestContextProvider : IRequestContextProvider
    {
        public RequestContext Context { get; set; }
    }
}