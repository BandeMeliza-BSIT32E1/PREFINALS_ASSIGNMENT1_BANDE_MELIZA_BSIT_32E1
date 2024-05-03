using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace ProtectedApi.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        private readonly string _ownerName = "Meliza Bande";

        [HttpGet("about/me")]
        public IActionResult GetAboutMe()
        {
            var randomFacts = new List<string>
            {
                "I love reading wattpad books and app.",
                "I enjoy experimenting with new programming languages.",
                "I am passionate about machine learning and artificial intelligence.",
                "I like crocheting.",
                "I love sleeping.",
                "I love eating.",
                "I play in my phone when I have free time",
                "I love iced coffee.",
                "I love watching kdrama",
                "I enjoy cooking and trying out new recipes."
            };

            var random = new Random();
            var randomFactIndex = random.Next(randomFacts.Count);

            return Ok(randomFacts[randomFactIndex]);
        }

        [HttpGet("about")]
        public IActionResult GetCreatorName()
        {
            return Ok(_ownerName);
        }

        [HttpPost("about")]
        public IActionResult PostName([FromBody] string name)
        {
            return Ok($"Hi {name} from {_ownerName}");
        }

        [HttpGet("userinfo")]
        public IActionResult GetUserInfo()
        {
            // Retrieve user information from claims
            var username = User.Identity.Name; // Example: retrieve username from claims
            var section = "BSIT32E1"; // Example: retrieve section from claims
            var course = "BSIT"; // Example: retrieve course from claims

            // Fun facts about the API creator
            var funFacts = new List<string>
            {
                "I love reading wattpad books and app.",
                "I enjoy experimenting with new programming languages.",
                "I am passionate about machine learning and artificial intelligence.",
                "I like crocheting.",
                "I love sleeping.",
                "I love eating.",
                "I play in my phone when I have free time",
                "I love iced coffee.",
                "I love watching kdrama",
                "I enjoy cooking and trying out new recipes."
            };

            var random = new Random();
            var randomFunFactIndex = random.Next(funFacts.Count);

            var userInfo = new
            {
                Name = username,
                Section = section,
                Course = course,
                FunFact = funFacts[randomFunFactIndex]
            };

            return Ok(userInfo);
        }
    }
}