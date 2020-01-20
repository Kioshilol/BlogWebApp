using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Interfaces
{
    public interface IMapper<TIn, TOut>
    {
        TIn Map(TOut item);
        TOut Map(TIn item);
    }
}
