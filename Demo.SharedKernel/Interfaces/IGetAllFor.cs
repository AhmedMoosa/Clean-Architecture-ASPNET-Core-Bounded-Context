using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Demo.SharedKernel.Interfaces
{
    public interface IGetAllFor<TResult> where TResult : class
    {
        IQueryable<TResult> GetAllFor();
    }
}
