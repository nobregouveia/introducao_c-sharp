using System;  
using System.Collections;  
using System.Linq;  

namespace Revisao
{
    class Program
    {
        static void Main(string[] args)
        {
            Aluno[] alunos = new Aluno[5];
            var indiceAluno = 0;
            var indiceAprovado = 0;
            var indiceReprovado = 0;
            string opcaoUsuario = ObterOpcaoUsuario();

            while (opcaoUsuario.ToUpper() != "X")
            {
                switch (opcaoUsuario)
                {
                    case "1":
                        Console.WriteLine("Informe o nome do aluno:");
                        Aluno aluno = new Aluno();
                        aluno.Nome = Console.ReadLine();

                        Console.WriteLine("Informe a nota do aluno:");

                        if (decimal.TryParse(Console.ReadLine(), out decimal nota))
                        {
                            aluno.Nota = nota;
                        }
                        else
                        {
                            throw new ArgumentException("O valor da nota deve ser decimal");
                        }

                        alunos[indiceAluno] = aluno;
                        indiceAluno++;

                        break;

                    case "2":
                        foreach (var a in alunos)
                        {
                            if (!string.IsNullOrEmpty(a.Nome))
                            {
                                Console.WriteLine($"Aluno: {a.Nome} - Nota: {a.Nota}");
                            }
                        }
                        break;
                    
                    case "3":
                        decimal notas = 0;
                        var nrAlunos = 0;
                        foreach (var a in alunos)
                        {
                            if (!string.IsNullOrEmpty(a.Nome))
                            {
                                notas += a.Nota;
                                nrAlunos++;
                            }
                        }
                        decimal media = (notas / nrAlunos);
                        Conceito conceitoGeral;

                        if (media < 2)
                        {
                            conceitoGeral = Conceito.E;
                        }
                        else if (media < 4)
                        {
                            conceitoGeral = Conceito.D;
                        }
                        else if (media < 6)
                        {
                            conceitoGeral = Conceito.C;
                        }
                        else if (media < 8)
                        {
                            conceitoGeral = Conceito.B;
                        }
                        else
                        {
                            conceitoGeral = Conceito.A;
                        }


                        Console.WriteLine($"A média geral é: {media} - Conceito {conceitoGeral}");
                        break;

                    case "4":
                        //TODO: LISTAR O REPROVADOS E APROVADOR

                        string[] reprovados = new string[5];
                        string[] aprovados = new string[5];
                
                        foreach (var a in alunos) {
                            if (!string.IsNullOrEmpty(a.Nome))
                            {
                                if (a.Nota >= 7) {
                                    aprovados[indiceAprovado] = a.Nome;
                                    indiceAprovado++;
                                } else {
                                    reprovados[indiceReprovado] = a.Nome;
                                    indiceReprovado++;
                                }
                            }
                        
                        }

                        Console.WriteLine("Lista de Reprovados:");
                        Console.WriteLine(String.Join("\n", reprovados));
                        Console.WriteLine("---------------------");
                        Console.WriteLine("Lista de Aprovados:");
                        Console.WriteLine(String.Join("\n", aprovados));

                        break;
                    default:
                        throw new ArgumentOutOfRangeException();
                }

                opcaoUsuario = ObterOpcaoUsuario();
            }
        }

        private static string ObterOpcaoUsuario()
        {
            Console.WriteLine();
            Console.WriteLine("Informe a opção desejada");
            Console.WriteLine("1- Inserir novo aluno");
            Console.WriteLine("2- Listar alunos");
            Console.WriteLine("3- Calcular média geral");
            Console.WriteLine("4- Relação de aprovados e reprovados");
            Console.WriteLine("X- Sair");
            Console.WriteLine();

            string opcaoUsuario = Console.ReadLine();
            Console.WriteLine();
            return opcaoUsuario;
        }
    }
}