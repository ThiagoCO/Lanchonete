using System.Collections.Generic;

namespace ConsoleApplication3
{
    class Pedidos
    {
        List<Lanches> listaPedido = new List<Lanches>();
        public decimal ValorTotal { get; private set; }
        public string nomeClient { get; private set; }

        public Pedidos(List<Lanches> listaPedido,string nomeClient, decimal valorTotal)
        {
            this.listaPedido = listaPedido;
            this.nomeClient = nomeClient;
            this.ValorTotal = valorTotal;

        }
       

       
    }
}