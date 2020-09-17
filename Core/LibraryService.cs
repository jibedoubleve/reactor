using Probel.Reactor.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading.Tasks;

namespace Probel.Reactor.Core
{
    public class LibraryService : ILibraryService
    {
        #region Fields

        private static readonly Random _random = new Random();

        #endregion Fields

        #region Methods

        public async Task<IEnumerable<BookModel>> SearchBookAsync(string criteria)
        {
            Debug.WriteLine($"Executing search for '{criteria}'");

            var result = new List<BookModel>();
            if (string.IsNullOrEmpty(criteria)) { return result; }
            else
            {
                for (int i = 0; i < _random.Next(0, 60); i++)
                {
                    result.Add(new BookModel
                    {
                        Author = Guid.NewGuid().ToString(),
                        Title = $"{criteria} - Random: {i}"
                    });
                }
                await Task.Delay(_random.Next(150, 500));
                return await Task.FromResult(result);
            }
        }

        #endregion Methods
    }
}