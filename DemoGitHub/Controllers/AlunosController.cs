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
        #region 0 - Criando um objeto
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

        #region 1 - Criar o Aluno


        private static int contaId = 4;

        public static int AddId()
        {
            contaId = contaId + 1 ;
            return contaId;
        }

        public static int GetId()
        {
            return contaId;
        }

        public static void AddAluno(Aluno aluno)
        {
            alunoList.Add(aluno);
        }





        private static List<Aluno> alunoList = new List<Aluno>
        {
            new Aluno(){ AlunoId = 1, Nome = "Arthur", Campus = "São josé", Curso = "EDC", Sexo = "M"},
            new Aluno(){ AlunoId = 2, Nome = "Damaris", Campus = "São josé", Curso = "EDC", Sexo = "F"},
            new Aluno(){ AlunoId = 3, Nome = "Leonardo", Campus = "São josé", Curso = "EDC", Sexo = "M"},
        };

        private static List<Aluno> GetalunoList()
        {
            return alunoList;
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
            return View();
        }
        [HttpPost]
        public ActionResult Edit()
        {
            return View();
        }
        #endregion

        #region Methods Delete
        public ActionResult Delete(int id)
        {
            return View();
        }

        [HttpPost]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            return View();
        }
        #endregion

        #region Method Details
        public ActionResult Details(int id)
        {
            return View();
        }
        #endregion

        #region Methods Buscar
        public ActionResult Buscar(int id)
        {
            return View();
        }

        [HttpPost]
        public ActionResult Buscar(string pesquisa)
        {
            return View();
        }
        #endregion
        #endregion

    }
}
