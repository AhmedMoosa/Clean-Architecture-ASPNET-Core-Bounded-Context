using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Demo.SharedKernel.Interfaces
{
    public interface IGetAllByFor<TResult,TKey> where TResult : class
    {
        IQueryable<TResult> GetAllByFor(TKey key);
    }
}
