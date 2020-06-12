using NikEventBlazor.Shared.Entries;
using System.Threading.Tasks;

namespace NikEventBlazor.Client.Repository
{
    public interface INikEventRepository
    {
        Task CreateEvent(NikEvent nikEvent);
    }
}
