using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Atividade01.Services
{
    public class ClienteService : IClienteService
    {
        private ClienteDAO _clienteDAO;
        public ClienteService(string connectionString)
        {
            _clienteDAO = new ClienteDAO(connectionString);
        }
    }
}
