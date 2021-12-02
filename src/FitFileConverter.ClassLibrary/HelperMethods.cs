using System;
using System.IO;
using System.Text.Json;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace FitFileConverter.Libs
{
    public static class HelperMethods
    {
        /// <summary>
        /// Converts string to camelCase
        /// </summary>
        /// <param name="str">The string to convert</param>
        /// <returns>Returns the camelCased <see cref="string"/></returns>
        public static string ToCamelCase(this string str)
        {
            if (!string.IsNullOrEmpty(str) && str.Length > 1)
            {
                return char.ToLowerInvariant(str[0]) + str[1..];
            }
            return str;
        }

        /// <summary>
        /// Converts string to Capital first letter
        /// </summary>
        /// <param name="str">The string to convert</param>
        /// <returns>Returns the <see cref="string"/> with Capital letter</returns>
        public static string ToFirstUpper(this string str)
        {
            if (string.IsNullOrEmpty(str))
            {
                return string.Empty;
            }
            char[] a = str.ToCharArray();
            a[0] = char.ToUpper(a[0]);
            return new string(a);
        }

        public async static Task<T?> DeserializeJsonFileAsync<T>(string filePath)
        {
            using var fileStream = File.OpenRead(filePath);

            return await JsonSerializer.DeserializeAsync<T>(fileStream, JsonSerializerOptions);
        }

        public static T? DeserializeJsonString<T>(string jsonString)
        {
            return JsonSerializer.Deserialize<T>(jsonString, JsonSerializerOptions);
        }

        /// <summary>
        /// Sanitizes file names
        /// </summary>
        /// <param name="name">The file name to be sanitize</param>
        /// <returns>Returns the file name without any invalid character</returns>
        public static string SanitizeFileName(this string name) => Regex.Replace(name, @"[^\w\.@-]", "_");

        //TODO: this helper method debug purposes delete this
        /// <summary>
        /// Write json stringify text to Console output as a new line the
        /// </summary>
        /// <param name="data">The object to be written to console</param>
        public static T ToConsole<T>(this T data)
        {
            Console.WriteLine(JsonSerializer.Serialize(data, JsonSerializerOptions));
            return data;
        }

        public static readonly JsonSerializerOptions JsonSerializerOptions = new()
        {
            WriteIndented = true,
            PropertyNameCaseInsensitive = true,
            IgnoreNullValues = true,
            DictionaryKeyPolicy = JsonNamingPolicy.CamelCase,
            PropertyNamingPolicy = JsonNamingPolicy.CamelCase
        };
    }
}