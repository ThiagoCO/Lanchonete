using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication3
{
    class Progama
    {
        static void Main(string[] args)
        {
           
            List<Lanches> cadastroDeLanches = new List<Lanches>(10);
            List<Pedidos> cadastroDePedidos = new List<Pedidos>();
            string[] texto = new string[10];
            int aux = 0;
            int op = 0;
            do
                {
                try
                {
                    Console.WriteLine(Menu());
                    op = Convert.ToInt32(Console.ReadLine());

                    switch (op)
                    {
                        case 1:
                            RegistarLanche(cadastroDeLanches, aux);
                            aux++;
                            break;
                        case 2:

                            ListarProdutos(cadastroDeLanches);


                            List<Lanches> pedido = new List<Lanches>();
                            Console.WriteLine("Informe o nome do cliente");
                            string nome = Console.ReadLine();
                            int aux1 = 0;

                            do
                            {
                                Console.WriteLine("1.Incluir lanche no pedido\n2.Solicitar Conta\n3.Sair");
                                aux1 = Convert.ToInt32(Console.ReadLine());

                                switch (aux1)
                                {
                                    case 1:
                                        AtualizarPedido(cadastroDeLanches, pedido, texto);
                                        break;
                                    case 2:
                                        IncluirItem(cadastroDeLanches, pedido, cadastroDePedidos, nome, texto);
                                        break;
                                }
                            } while (aux1 != 3);


                            break;
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine("Ops!!! Aconteceu algum erro, por gentileza tentar novamente.");
                }
            } while (op != 3);
            
            
        }
        public static String Menu()
        {
            string aux = "Menu Principal\n";
            aux += "1. Cadastrar novo lanche\n";
            aux += "2. Realizar um pedido de compra\n";
            aux += "3. Sair";
            return aux;
        }
        public static void RegistarLanche(List<Lanches> cadastroDeLanches, int aux)
        {
            
            Console.WriteLine("Informe o nome do produto");
            String nome = Console.ReadLine();
            Console.WriteLine("Informe a Descrição do produto");
            String descricao = Console.ReadLine();
            Console.WriteLine("Informe o valor do produto");
            decimal valor = Convert.ToDecimal(Console.ReadLine());
            cadastroDeLanches.Add(new Lanches(nome, descricao, valor,(aux+1)));
            Console.WriteLine("Produto registrado: " + cadastroDeLanches[aux]);
            
        }
        public static void ListarProdutos(List<Lanches> cadastroDeLanches)
        {
            Console.WriteLine("Cardapio Lanchonete TOTVS");
            foreach (Lanches lanche in cadastroDeLanches)
            {
                
                    Console.WriteLine(lanche);
                    
                
            }
            
}
        public static void AtualizarPedido(List<Lanches> cadastroDeLanches, List<Lanches> pedido, string[] texto)
        {
            Console.WriteLine("Digite o ID do produto desejado");
            int lanche = int.Parse(Console.ReadLine());
            int aux = 0;
            int repetidor = 1;
            foreach (Lanches buscarLanche in cadastroDeLanches)
            {
                repetidor++;
                if (buscarLanche.nLanche == lanche)
                {
                    Console.WriteLine("Qual a quantidade você desja desse produto?");
                    int cont = Convert.ToInt32(Console.ReadLine());
                    for(int i= 0; i < cont; i++)
                    {
                        pedido.Add(buscarLanche);
                        texto[aux] = buscarLanche.ToString();
                    }
                    texto[aux] += " Quantidade: "+ Convert.ToString(cont);
                    Console.WriteLine("Pedido atualizado");
                    aux++;
                    break;
                }
                else if(repetidor >= cadastroDeLanches.Count()){
                    Console.WriteLine("Produto inexistente");
                }        
            }

        }
        public static void IncluirItem(List<Lanches> cadastroDeLanches, List<Lanches> pedido, List<Pedidos> cadastroDePedidos, String nome, String[] texto)
        {
            decimal total = 0;
            List<Lanches> Cont = pedido;
            int aux = 0;
            Console.WriteLine("Conta:" + nome);
            foreach (Lanches calculototal in pedido)
            {
                total =  total + calculototal.preco;                
                Console.WriteLine(texto[aux]);
                aux++;
            }
            cadastroDePedidos.Add(new Pedidos(pedido, nome, total));
            Console.WriteLine("Total da Consumido: " + total);
            Console.WriteLine("Taxa de juros: " + (total * (decimal)0.07));
        }
    }
}
