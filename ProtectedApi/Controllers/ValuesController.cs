using Microsoft.AspNetCore.Mvc;
using System;

namespace ProtectedApi
{
    [ApiController]
    [Route("[controller]")]
    public class ValueController : ControllerBase
    {
        private readonly string _owner = "Meliza Bande";
        private readonly Random _random = new Random();
        private readonly string[] _thingsAboutOwner = new[]
        {
            "I love reading Wattpad books and app.",
            "I enjoy experimenting with new programming languages.",
            "I am passionate about machine learning and artificial intelligence.",
            "I like crocheting.",
            "I love sleeping.",
            "I love eating.",
            "I play on my phone when I have free time.",
            "I love iced coffee.",
            "I love watching K-drama.",
            "I enjoy cooking and trying out new recipes."
        };

        [HttpGet("about/me")]
        public IActionResult AboutMe()
        {
            var thing = _thingsAboutOwner[_random.Next(_thingsAboutOwner.Length)];
            return Ok(thing);
        }

        [HttpGet("about")]
        public IActionResult About()
        {
            return Ok(_owner);
        }

        [HttpPost("about")]
        public IActionResult About([FromBody] NameModel model)
        {
            return Ok($"Hi {model.Name} from {_owner}");
        }
    }

    public class NameModel
    {
        public string? Name { get; set; }
    }
}