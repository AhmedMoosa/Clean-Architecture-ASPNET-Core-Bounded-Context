using Demo.SharedKernel.DTOs;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Demo.SharedKernel.Interfaces
{
    public interface IUpdateForAsync<TInput, TKey> where TInput : class
    {
        Task<OperationResult> UpdateForAsync(TKey key, TInput entityToUpdate);
    }
}
