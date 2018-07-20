using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication3
{
    class Lanches
    {
        private String nome;
        private String descricao;
        public decimal preco { get; set; }
        public int nLanche { get; set; }
        

       

    
        public Lanches(string nome, string descricao, decimal preco, int nLanche)
        {
            this.nome = nome;
            this.descricao = descricao;
            this.preco = preco; 
            this.nLanche = nLanche;

        }

        
        
        public String Descricao
        {
            get { return descricao; }
            set { descricao = value; }
        }

        public String Nome
        {
            get { return nome; }
            set { nome = value; }
        }
        public override string ToString()
        {
            return "ID: " + nLanche + ", Nome: " + nome + ", Descrição: " + descricao + ", Valor: R$ " + preco;
        }

        public override bool Equals(object obj)
        {
            Lanches outro = obj as Lanches;
            return this.nLanche == outro.nLanche;
        }
    }
}
