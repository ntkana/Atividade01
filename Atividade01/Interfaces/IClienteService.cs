using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Atividade01.Interfaces
{
    public interface IClienteService
    {
        public void AdicionarCliente(string pNome, string pEmail);
        public void ListarClientes();
        public void AtualizarCliente(int pId, string pNome, string pEmail);
        public void RemoverCliente(int pId);
        public void CadastrarPedido(int pIdCliente, string pProduto, int pQuantidade);
        public void ListarPedidosPorCliente(int pIdCliente);

    }
}
