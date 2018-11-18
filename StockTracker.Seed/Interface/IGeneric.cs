using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockTracker.Seed.Interface
{
    public interface IGeneric<T>
    {
	    T[] All();
	    T One();
	    T One(int index);
    }
}
