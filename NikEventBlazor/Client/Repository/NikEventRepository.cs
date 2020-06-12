using NikEventBlazor.Client.Helpers;
using NikEventBlazor.Shared.Entries;
using System;
using System.Threading.Tasks;

namespace NikEventBlazor.Client.Repository
{
    public class NikEventRepository: INikEventRepository
    {
        private readonly IHttpService httpService;
        private readonly string url = "api/NikEvent";

        public NikEventRepository(IHttpService service)
        {
            httpService = service;
        }

        public async Task CreateEvent(NikEvent nikEvent)
        {
            var response = await httpService.Post(url, nikEvent);
            if(!response.Success)
                throw new ApplicationException(await response.GetBody());
        }
    }
}
