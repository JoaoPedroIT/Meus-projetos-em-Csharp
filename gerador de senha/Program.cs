using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gerador_de_senha
{
    internal class Program
    {
        static void Main(string[] args)
        {

            Console.WriteLine("seja bem-vindo ao gerador se senha");
            bool executando = true;

            while (executando)
            {
                Console.WriteLine("digite o tamanho da senha");
                int tamanho = Convert.ToInt32(Console.ReadLine());

                Console.WriteLine("tem letras minusculas  (S/N)");
                bool temLetrasMinusculas = Console.ReadLine().ToLower() == "S";

                Console.WriteLine("tem letras maiusculas  (S/N)");
                bool temletrasmaiusculas = Console.ReadLine().ToLower() == "S";

                Console.WriteLine("tem numeros  (S/N)");
                bool temnumeros = Console.ReadLine().ToLower() == "S";

                Console.WriteLine("tem caraceres especiais (S/N)");
                bool caractersespeciais = Console.ReadLine().ToLower() == "S";

                string senha = GerarSenha (tamanho, temLetrasMinusculas, temletrasmaiusculas, temnumeros, caractersespeciais);

                Console.WriteLine("senha gerada: " + senha);

                Console.WriteLine("deseja gerar outra senha? (S/N)");
                executando = Console.ReadLine().ToLower() == "s";

            }

            string GerarSenha(int tamanho, bool temLetrasMinusculas, bool temletrasmaiusculas, bool temnumeros, bool caractersespeciais)
            {
                const string letrasMinusculas = "abcdefghijklmnopqrstuvwxyz";
                const string letrasMaiusculas = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
                const string numeros = "0123456789";
                const string caracteresEspeciais = "!@#$%¨&*()_+";

                string caracterespermitidos = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789!@#$%^&*()";

                if (temLetrasMinusculas)
                {
                    caracterespermitidos += letrasMinusculas;
                }
                if (temletrasmaiusculas)
                {
                    caracterespermitidos += letrasMaiusculas;
                }
                if (temnumeros)
                {
                    caracterespermitidos += numeros;
                }
                if (caractersespeciais)
                {
                    caracterespermitidos += caracteresEspeciais;
                }
                
                byte[] randomBytes = new byte[tamanho];
                using (System.Security.Cryptography.RNGCryptoServiceProvider rng = new System.Security.Cryptography.RNGCryptoServiceProvider())
                {
                    rng.GetBytes(randomBytes);
                }

                StringBuilder senha = new StringBuilder(tamanho);
                foreach (byte b in randomBytes)
                {
                    senha.Append(caracterespermitidos[b % (caracterespermitidos.Length)]);
                }
                return senha.ToString();



            }

























        }
    }
}
