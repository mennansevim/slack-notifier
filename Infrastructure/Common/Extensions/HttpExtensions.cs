using System;
using System.Net;
using Newtonsoft.Json;
using RestSharp;

namespace SlackNotifier.Infrastructure.Extensions
{
    public static class HttpExtensions
    {
        public static T ToGetResponse<T>(this IRestResponse response, Func<T> otherStatus, Func<T> notFound = null)
            where T : class, new()
        {
            if (response.StatusCode == HttpStatusCode.OK)
            {
                return JsonConvert.DeserializeObject<T>(response.Content);
            }
            if (response.StatusCode == HttpStatusCode.NotFound)
            {
                return notFound?.Invoke();
            }

            return otherStatus();
        }
    }
}
