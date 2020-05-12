using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using NikEventBlazor.Shared.Entries;

namespace NikEventBlazor.Server.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class NikEventController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly ILogger<NikEventController> logger;

        public NikEventController(ILogger<NikEventController> logger)
        {
            this.logger = logger;
        }

        [HttpGet]
        public IEnumerable<NikEvent> Get()
        {
            return new List<NikEvent>()
            {
                new NikEvent()
                {
                    Caption = "First event"
                },
                new NikEvent()
                {
                    Caption = "Second event"
                }
            };
        }
    }
}
