using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Demo.SharedKernel.Interfaces
{
    public interface IFindForAsync<TResult, TKey> where TResult : class
    {
        Task<TResult> FindForAsync(TKey key);
    }
}
