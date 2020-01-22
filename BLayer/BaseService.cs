using Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace BLayer
{
    public class BaseService
    {
        protected IEnumerable<U> Map<T, U>(IMapper<T, U> mapper, IEnumerable<T> list)
        {
            IEnumerable<T> TList = list;
            var TListDTO = new List<U>();

            foreach (dynamic item in TList)
            {
                var itemDTO = mapper.Map(item);
                TListDTO.Add(itemDTO);
            }

            return TListDTO;
        }
    }
}
