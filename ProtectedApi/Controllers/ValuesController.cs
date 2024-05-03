namespace ProtectedApi
{
    using Microsoft.AspNetCore.Mvc;
    using System;

    [ApiController]
    [Route("[controller]")]
    public class ValueController : ControllerBase
    {
        private readonly string _owner = "Meliza Bande";

        [HttpGet("about/me")]
        public IActionResult AboutMe()
        {
            var random = new Random();
            var thingsAboutOwner = new[]
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
            var thing = thingsAboutOwner[random.Next(thingsAboutOwner.Length)];

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