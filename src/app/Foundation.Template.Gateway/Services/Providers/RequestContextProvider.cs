using System;
using Foundation.Template.Gateway.Models;
using Foundation.Template.Gateway.Abstractions;

namespace Foundation.Template.Gateway.Providers
{
    public class RequestContextProvider : IRequestContextProvider
    {
        public RequestContext Context { get; set; }
    }
}