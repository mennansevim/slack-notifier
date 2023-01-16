using System.Collections.Generic;
using System.Text;
using Confluent.Kafka;

namespace SlackNotifier.Infrastructure.Utils
{
    public static class MessageExtensions
    {
        public static void SetHeaderValue(this Message<string, string> message, string key, string value)
        {
            message.Headers ??= new Headers();

            message.Headers.Remove(key);

            var bytes = Encoding.UTF8.GetBytes(value);
            var header = new Header(key, bytes);
            message.Headers.Add(header);
        }

        public static string? GetHeaderValue(this Message<string, string> message, string key)
        {
            if (message.Headers == null)
            {
                return null;
            }

            foreach (var header in message.Headers)
            {
                if (header.Key == key)
                {
                    var bytes = header.GetValueBytes();
                    return Encoding.UTF8.GetString(bytes);
                }
            }

            return null;
        }
        
        public static string ToQueryString(this List<KeyValuePair<string, string?>> queryParameters)
        {
            var queryString = string.Empty;

            if (queryParameters == null)
            {
                return queryString;
            }

            foreach (var queryParameter in queryParameters)
            {
                if (!string.IsNullOrEmpty(queryString))
                {
                    queryString += "&";
                }
                else
                {
                    queryString += "?";
                }

                queryString += HandleMultipleValue(queryParameter);
            }

            var bytes = Encoding.UTF8.GetBytes(queryString);
            return Encoding.UTF8.GetString(bytes, 0, bytes.Length);
        }

        private static string HandleMultipleValue(KeyValuePair<string, string?> queryStringParam)
        {
            var multipleValue = queryStringParam.Value.Split(',');
            var multipleKeyValue = new List<string>();
            foreach (var value in multipleValue)
            {
                var keyValue = (queryStringParam.Key + "=" + value);
                multipleKeyValue.Add(keyValue);
            }

            return string.Join("&", multipleKeyValue.ToArray());
        }
    }
}