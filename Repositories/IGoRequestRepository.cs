using GoldenGateAPI.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GoldenGateAPI.Repositories
{
    public interface IGoRequestRepository
    {
        Task<bool> InsertGoRequest(int id_funcionario,
                                        DateTime fecha,
                                        int id_estado,
                                        string razon_social,
                                        string ruc,
                                        string telefono1,
                                        string telefono2,
                                        string email,
                                        string direccion,
                                        string representante,
                                        string cargo,
                                        string tipo);
    }
}
