using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using System.Collections.Generic;
using WebApp.Domain.Models;
using WebApp.Services.DataServices;

namespace epita_web_api_demo_1.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class UserProfileController : ControllerBase
    {
        private readonly IMemoryCache _memoryCache;

        public UserProfileController(IMemoryCache memoryCache)
        {
            _memoryCache = memoryCache;
        }

        [HttpGet]
        public async Task<List<UserProfile>> Get()
        {
            List<UserProfile> userProfiles;

            userProfiles = _memoryCache.Get<List<UserProfile>>("userProfiles");

            if (userProfiles is null)
            {
                userProfiles = await UserProfileService.Profiles();
                _memoryCache.Set("userProfiles", userProfiles,TimeSpan.FromSeconds(5));
            }

            return userProfiles;
        }
    }
}
