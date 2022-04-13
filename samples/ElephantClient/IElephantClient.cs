using System.Collections.Generic;
using System.Threading.Tasks;

namespace ElephantClient
{
    public interface IElephantClient
    {
        Task<IEnumerable<Elephant>> GetElephants();
    }
}