using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApp.Auth.Authentication
{
    public class ApiKeyMiddleware
    {
        private readonly IConfiguration _configuration;
        private readonly RequestDelegate _next;
        public ApiKeyMiddleware(IConfiguration config)
        {
            _configuration = config;
        }

        private bool IsValidApiKey(string? apiKey)
        {

            var validApiKey = _configuration.GetValue<string>(AuthConfig.AuthSection);

            return string.Equals(validApiKey, apiKey);
        }
    }
}
