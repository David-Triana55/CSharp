using POO.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POO
{
    class ImprimirInfo
    {
    public void ImprimirSuperHeroe(ISuperHeroe superHeroe)
    {
      Console.WriteLine(superHeroe.GetSuperHeroe());
    }
  }
}
