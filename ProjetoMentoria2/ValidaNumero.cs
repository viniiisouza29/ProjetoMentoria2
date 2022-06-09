using System.Text.RegularExpressions;

namespace ProjetoMentoria2
{
    public class ValidaNumero
    {
        public static string ValorInicial { get; set; }
        public bool validanumero;

        public void EntradaValor()
        {
            Console.Clear();
            while (true)
            {
                Console.WriteLine("Insira os peso de cada uma das cargas separada por vírgula: ");
                Console.WriteLine("EX: 5,4,9,2,1,6");

                int[] pilha = null;
                string numeros = Console.ReadLine();

                if (String.IsNullOrEmpty(numeros))
                {
                    Console.WriteLine("Os valores dos pesos inseridos, não podem ser nulos.\n");
                    Console.WriteLine("Favor inserir um valor válido.\n");
                    continue;
                }

                numeros = numeros.Replace(" ", "");

                if (Regex.IsMatch(numeros.Replace(",", ""), @"^[0-9]+$"))
                {
                    pilha = numeros.Replace(" ", "").Split(",").Select(Int32.Parse).ToArray();

                    Console.WriteLine("Quantidade de trocas necessárias: " + OrganizaPilha(ref pilha));
                    Console.WriteLine("Resultado final: ");

                    pilha.ToList().ForEach(x => Console.Write("{0} ", x));

                    Console.WriteLine("Pressione qualquer tecla para reiniciar.");
                    Console.ReadKey();
                    Console.Clear();
                }
                else
                {
                    Console.WriteLine("Por conta da existência de caracteres não númerais, não foi possível terminar o procedimento!\n");
                    Console.WriteLine("Favor inserir um valor válido.\n");
                }
            }
        }

        public static int OrganizaPilha(ref int[] arr)
        {
            int maioridx = 0, menoridx = 0;
            int trocas = 0;

            for (int i = 0; i < arr.Length; i++)
                for (int j = 1; j < arr.Length; j++)
                {
                    if (arr[maioridx] < arr[j])
                    {
                        maioridx = j;
                    }
                    if (arr[menoridx] > arr[j])
                    {
                        menoridx = j;
                    }
                }

            int maxval = arr[maioridx];
            int minval = arr[menoridx];

            for (int i = maioridx; i < arr.Length - 1; i++)
            {
                int tempval = arr[i + 1];

                if (tempval == arr[menoridx])
                {
                    menoridx--;
                }

                arr[i + 1] = maxval;
                arr[i] = tempval;
                trocas++;
            }

            for (int i = menoridx; i > 0; i--)
            {
                int tempval = arr[i - 1];
                arr[i - 1] = minval;
                arr[i] = tempval;

                trocas++;
            }

            return trocas;
        }
    }
}

