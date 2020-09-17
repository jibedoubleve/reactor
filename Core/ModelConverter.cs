using AutoMapper;
using Probel.Reactor.Models;
using Probel.Reactor.ViewModels;
using Splat;
using System.Collections.Generic;

namespace Probel.Reactor.Core
{
    public static class ModelConverter
    {
        #region Methods

        public static IEnumerable<BookViewModel> AsViewModel(this IEnumerable<BookModel> models)
        {
            var mapper = Locator.Current.GetService<IMapper>();
            var result = mapper.Map<IEnumerable<BookModel>, IEnumerable<BookViewModel>>(models);
            return result;
        }

        #endregion Methods
    }
}