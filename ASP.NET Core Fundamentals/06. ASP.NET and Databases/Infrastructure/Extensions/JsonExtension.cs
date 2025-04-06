using System.Text.Encodings.Web;
using System.Text.Json;
using System.Text.Unicode;

namespace Infrastructure.Extensions
{
    /// <summary>
    /// Extension methods for JSON serialization.
    /// </summary>
    public static class JsonExtensions
    {
        /// <summary>
        /// JSON serialization standart options.
        /// </summary>
        private static readonly JsonSerializerOptions _jsonOptions = new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true,
            Encoder = JavaScriptEncoder.Create(UnicodeRanges.BasicLatin, UnicodeRanges.Cyrillic),
            PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
            WriteIndented = true
        };

        /// <summary>
        /// Deserializes JSON string to object.
        /// </summary>
        /// <typeparam name="T">Type of object</typeparam>
        /// <param name="json">JSON string</param>
        /// <returns></returns>
        public static T? FromJson<T>(this string json) =>
            JsonSerializer.Deserialize<T>(json, _jsonOptions);

        /// <summary>
        /// Serializes object to JSON string.
        /// </summary>
        /// <typeparam name="T">Type of object to serialize</typeparam>
        /// <param name="obj">Object to serialize</param>
        /// <returns></returns>
        public static string ToJson<T>(this T obj) =>
            JsonSerializer.Serialize<T>(obj, _jsonOptions);

        /// <summary>
        /// Deserializes JSON string to object.
        /// </summary>
        /// <typeparam name="T">Type of object</typeparam>
        /// <param name="json">JSON string</param>
        /// <param name="jsonOptions">Custom serializer options</param>
        /// <returns></returns>
        public static T? FromJson<T>(this string json, JsonSerializerOptions jsonOptions) =>
            JsonSerializer.Deserialize<T>(json, jsonOptions);

        /// <summary>
        /// Serializes object to JSON string.
        /// </summary>
        /// <typeparam name="T">Type of object</typeparam>
        /// <param name="obj">Object to serialize</param>
        /// <param name="jsonOptions">Custom serializer options</param>
        /// <returns></returns>
        public static string ToJson<T>(this T obj, JsonSerializerOptions jsonOptions) =>
            JsonSerializer.Serialize<T>(obj, jsonOptions);
    }
}
