using Demo.SharedKernel.DTOs;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Demo.SharedKernel.Interfaces
{
    public interface ICreateForAsync<TInput> where TInput : class
    {
        Task<OperationResult> CreateForAsync(TInput entityToCreate);
    }
}
