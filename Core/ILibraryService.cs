using Probel.Reactor.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Probel.Reactor.Core
{
    public interface ILibraryService
    {
        Task<IEnumerable<BookModel>> SearchBookAsync(string criteria);
    }
}