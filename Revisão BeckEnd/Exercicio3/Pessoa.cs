using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Exercicio2
{
    public class Pessoa
    {
       
        public string Nome;
        public int Idade;
        
        public void ExibirDados()
        {
            if (Idade <= 0)
            {
                Console.WriteLine($"Não é possivel ter essa idade");
                
            }
            else
            {
                Console.WriteLine($"Seu nome é {Nome}, e sua idade é {Idade}");
                
            }
            
        }
    }


}