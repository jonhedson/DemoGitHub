using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using DemoGitHub.Models;
using Microsoft.AspNetCore.Http;

namespace DemoGitHub.Controllers
{
    public class AlunosController : Controller
    {
        #region 0 - Criando um objeto e enviando para a View()
        //public IActionResult Index()
        //{
        //    Aluno aluno = new Aluno()
        //    {
        //        AlunoId = 1,
        //        Nome = "Infnet",
        //        Campus = "Sao Jose",
        //        Curso = "EDC",
        //        Sexo = "Masculino"
        //    };
        //    return View(aluno);
        //}
        #endregion

        #region 1 - Criar, Editar, Deletar e Buscar o Aluno na Lista - Códigos não são pertecentes ao Controller

        // Contador inicial do Id
        private static int contaId = 4;

        // Método para incrementar o contador após a inserção do Aluno
        public static int AddId()
        {
            contaId = contaId + 1 ;
            return contaId;
        }
        
        //  Obter o Id para inserção no objeto que acontecerá na Action do Create
        public static int GetId()
        {
            return contaId;
        }

        // Adiciono o aluno criado a partir do Formulário da View na Lista
        public static void AddAluno(Aluno aluno)
        {
            alunoList.Add(aluno);
        }

        // Lista com alunos iniciais da Aplicação
        private static List<Aluno> alunoList = new List<Aluno>
        {
            new Aluno(){ AlunoId = 1, Nome = "Arthur", Campus = "São josé", Curso = "EDC", Sexo = "M"},
            new Aluno(){ AlunoId = 2, Nome = "Damaris", Campus = "São josé", Curso = "EDC", Sexo = "F"},
            new Aluno(){ AlunoId = 3, Nome = "Leonardo", Campus = "São josé", Curso = "EDC", Sexo = "M"},
        };

        // Listar todos os alunos, ele vai ser chamado pela Action Index.
        private static List<Aluno> GetalunoList()
        {
            return alunoList;
        }

        //Buscar o id do aluno
        public static Aluno BuscarId(int id)
        {
            Aluno resultado = new Aluno();
            foreach (Aluno a in alunoList)
            {
                if(a.AlunoId == id)
                {
                    resultado.AlunoId = a.AlunoId;
                    resultado.Nome = a.Nome;
                    resultado.Campus = a.Campus;
                    resultado.Curso = a.Curso;
                    resultado.Sexo = a.Sexo;
                    break;
                }
            }
            return resultado;
        }

        public static void EditAluno(int id, Aluno alunoUpdate)
        {
            foreach (Aluno a  in alunoList)
            {
                if (a.AlunoId == id)
                {
                    a.Nome = alunoUpdate.Nome;
                    a.Campus = alunoUpdate.Campus;
                    a.Curso = alunoUpdate.Curso;
                    a.Sexo = alunoUpdate.Sexo;
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
            foreach (Aluno  a in alunoList)
            {
                if (a.Nome.Contains(pesquisa))
                {
                    resultados.Add(a);
                }
                
            }
            return resultados;
        }
        #endregion

        #region 2 - Ações do Controlador

        #region Method Index -> GetAllAlunos - OK
        public ActionResult Index()
        {
            return View(GetalunoList());
        }

        #endregion

        #region Methods Create
        public ActionResult Create()
        {
            return View();
        }
        
        [HttpPost]
        public ActionResult Create(IFormCollection collection) // Recolher dados do formulario
        {
            Aluno aluno = new Aluno();
            aluno.AlunoId = GetId(); // Tenho que criar o método de obter o Id
            aluno.Nome = collection["Nome"];
            aluno.Campus = collection["Campus"];
            aluno.Curso = collection["Curso"];
            aluno.Sexo = collection["Sexo"];

            AddId();

            AddAluno(aluno);

            return RedirectToAction("Index");
        }
        #endregion

        #region Methods Edit
        public ActionResult Edit(int id)
        {
            return View(BuscarId(id));
        }
        [HttpPost]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                Aluno aluno = new Aluno();
                aluno.Nome = collection["Nome"];
                aluno.Campus = collection["Campus"];
                aluno.Curso = collection["Curso"];
                aluno.Sexo = collection["Sexo"];
                // aluno.Idade = Convert.ToInt32(collection["Idade"]);

                EditAluno(id, aluno);
                return RedirectToAction(nameof(Index));

            }
            catch
            {
                return View();
            }
        }
        #endregion

        #region Methods Delete
        public ActionResult Delete(int id)
        {
            
            return View(BuscarId(id));
        }

        [HttpPost]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                DeleteAluno(id);

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
        #endregion

        #region Method Details
        public ActionResult Details(int id)
        {
            return View(BuscarId(id));
        }
        #endregion

        #region Methods Buscar
        public ActionResult Buscar()
        {
            string pesquisa = "";
            return View(BuscarAluno(pesquisa));
        }

        [HttpPost]
        public ActionResult Buscar(string pesquisa)
        {
            try
            {
                return View(BuscarAluno(pesquisa));
            }
            catch
            {
                return View();

            }
        }
        #endregion
        #endregion

    }
}
