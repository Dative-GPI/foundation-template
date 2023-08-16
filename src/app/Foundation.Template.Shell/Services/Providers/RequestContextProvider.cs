using System;
using Foundation.Template.Shell.Models;
using Foundation.Template.Shell.Abstractions;

namespace Foundation.Template.Shell.Tools
{
    public class RequestContextProvider : IRequestContextProvider
    {
        public RequestContext Context { get; set; }
    }
}