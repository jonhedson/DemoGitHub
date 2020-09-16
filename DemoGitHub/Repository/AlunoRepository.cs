using System;
using System.Collections.Generic;
using DemoGitHub.Models;

namespace DemoGitHub.Repository
{
    public class AlunoRepository
    {
        // Contador inicial do Id
        private static int contaId = 4;

        // Método para incrementar o contador após a inserção do Aluno
        public static int AddId()
        {
            contaId = contaId + 1;
            return contaId;
        }

        //  Obter o Id para inserção no objeto que acontecerá na Action do Create
        public static int GetId()
        {
            return contaId;
        }

        // Lista com alunos iniciais da Aplicação
        private static List<Aluno> alunoList = new List<Aluno>
        {
            new Aluno(){ AlunoId = 1, Nome = "Arthur", Campus = "São josé", Curso = "EDC", Sexo = "M", Aniversario = new DateTime(2010,10,09)},
            new Aluno(){ AlunoId = 2, Nome = "Damaris", Campus = "São josé", Curso = "EDC", Sexo = "F", Aniversario=DateTime.Now},
            new Aluno(){ AlunoId = 3, Nome = "Leonardo", Campus = "São josé", Curso = "EDC", Sexo = "M", Aniversario=DateTime.Now},
        };

        // Adiciono o aluno criado a partir do Formulário da View na Lista
        public static void AddAluno(Aluno aluno)
        {
            alunoList.Add(aluno);
        }

        // Listar todos os alunos, ele vai ser chamado pela Action Index.
        public static List<Aluno> GetalunoList()
        {
            return alunoList;
        }

        public static void Create(Aluno aluno)
        {
            aluno.AlunoId = GetId();
            AddAluno(aluno);
            AddId();
            
        }

        //Buscar o id do aluno
        public static Aluno BuscarId(int id)
        {
            Aluno resultado = new Aluno();
            foreach (Aluno a in alunoList)
            {
                if (a.AlunoId == id)
                {
                    resultado.AlunoId = a.AlunoId;
                    resultado.Nome = a.Nome;
                    resultado.Campus = a.Campus;
                    resultado.Curso = a.Curso;
                    resultado.Sexo = a.Sexo;
                    resultado.Aniversario = a.Aniversario;
                    break;
                }
            }
            return resultado;
        }

        public static void EditAluno(int id, Aluno alunoUpdate)
        {
            foreach (Aluno a in alunoList)
            {
                if (a.AlunoId == id)
                {
                    a.Nome = alunoUpdate.Nome;
                    a.Campus = alunoUpdate.Campus;
                    a.Curso = alunoUpdate.Curso;
                    a.Sexo = alunoUpdate.Sexo;
                    a.Aniversario = alunoUpdate.Aniversario;
                    break;
                }
            }
        }

        public static void DeleteAluno(int id)
        {
            foreach (Aluno a in alunoList)
            {
                if (a.AlunoId == id)
                {
                    alunoList.Remove(a);
                    break;
                }
            }
        }

        public static List<Aluno> BuscarAluno(string pesquisa)
        {
            List<Aluno> resultados = new List<Aluno>();
            foreach (Aluno a in alunoList)
            {
                if (a.Nome.Contains(pesquisa))
                {
                    resultados.Add(a);
                }

            }
            return resultados;
        }
    }
}
