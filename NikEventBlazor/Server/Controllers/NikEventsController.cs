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
        private readonly ApplicationDbContext m_context;
        private readonly ILogger<NikEventController> m_logger;
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };



        public NikEventController(ApplicationDbContext context, ILogger<NikEventController> logger)
        {
            m_context = context;
            m_logger = logger;
        }

        //public NikEventController(ILogger<NikEventController> logger)
        //{
        //    m_logger = logger;
        //}

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

        [HttpPost]
        public async Task<ActionResult<int>> Post(NikEvent nikEvent)
        {
            m_context.Add(nikEvent);
            await m_context.SaveChangesAsync();
            return nikEvent.Id;
        }
    }
}
