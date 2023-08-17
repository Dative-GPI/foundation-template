using System;
using System.Linq;
using System.Net.Http;
using System.Threading;
using System.Text.Json;
using System.Threading.Tasks;
using System.Collections.Generic;

using Microsoft.AspNetCore.Http;
using Yarp.ReverseProxy.Forwarder;
using System.Net.Http.Json;

namespace Foundation.Template.Proxy.Extensions
{
    public static class HttpExtensions
    {
        public static async Task<HttpResponseMessage> SendAsync(this HttpClient client, HttpContext context, string destinationPrefix, string overridePath = null)
        {
            var request = new HttpRequestMessage()
            {
            };

            await HttpTransformer.Default.TransformRequestAsync(context, request, destinationPrefix, CancellationToken.None);

            request.RequestUri = new UriBuilder(request.RequestUri) { Path = overridePath ?? request.RequestUri.PathAndQuery }.Uri;

            HttpResponseMessage response;

            try
            {
                response = await client.SendAsync(request, HttpCompletionOption.ResponseHeadersRead, context.RequestAborted);
            }
            catch (System.Exception)
            {
                return null;
            }

            return response;
        }

        public static async Task<HttpResponseMessage> PostAsync<T>(this HttpClient client, HttpContext context, string destinationPrefix, string overridePath = null, T body = default)
        {
            var request = new HttpRequestMessage()
            {
                Method = HttpMethod.Post,
                Content = JsonContent.Create(body)
            };

            await HttpTransformer.Default.TransformRequestAsync(context, request, destinationPrefix, CancellationToken.None);

            request.RequestUri = new UriBuilder(request.RequestUri) { Path = overridePath ?? request.RequestUri.PathAndQuery }.Uri;

            HttpResponseMessage response;

            try
            {
                response = await client.SendAsync(request, HttpCompletionOption.ResponseHeadersRead, context.RequestAborted);
            }
            catch (System.Exception)
            {
                return null;
            }

            return response;
        }


        public static async Task<List<JsonElement>> Concat(params HttpResponseMessage[] responses)
        {
            var result = new List<JsonElement>();

            foreach (var response in responses)
            {
                if (response != null && response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();
                    var array = JsonSerializer.Deserialize<List<JsonElement>>(content);
                    result.AddRange(array);
                }
            }

            return result;
        }
    }
}