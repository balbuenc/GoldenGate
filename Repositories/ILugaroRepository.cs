using GoldenGateAPI.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GoldenGateAPI.Repositories
{
    public interface ILugaroRepository
    {
        Task<IEnumerable<Lugaro_Producto>> GetAllProductos();
    }
}
