using Demo.SharedKernel.DTOs;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Demo.SharedKernel.Interfaces
{
    public interface IDeleteForAsync<TKey, TUserKey>
    {
        Task<OperationResult> DeleteForAsync(TKey key, TUserKey userKey);
    }
}
