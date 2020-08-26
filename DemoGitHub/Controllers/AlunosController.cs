using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using DemoGitHub.Models;
using Microsoft.AspNetCore.Http;
using DemoGitHub.Repository;

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


        #endregion

        #region 2 - Ações do Controlador

        #region Method Index -> GetAllAlunos - OK
        public ActionResult Index()
        {
            return View(AlunoRepository.GetalunoList());
        }

        #endregion

        #region Methods Create
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Aluno aluno) // Recolher dados do formulario
        {

            AlunoRepository.Create(aluno);

            return RedirectToAction("Index");
        }
        #endregion

        //#region Methods Edit
        //public ActionResult Edit(int id)
        //{
        //    return View(BuscarId(id));
        //}
        //[HttpPost]
        //public ActionResult Edit(int id, IFormCollection collection)
        //{
        //    try
        //    {
        //        Aluno aluno = new Aluno();
        //        aluno.Nome = collection["Nome"];
        //        aluno.Campus = collection["Campus"];
        //        aluno.Curso = collection["Curso"];
        //        aluno.Sexo = collection["Sexo"];
        //        // aluno.Idade = Convert.ToInt32(collection["Idade"]);

        //        EditAluno(id, aluno);
        //        return RedirectToAction(nameof(Index));

        //    }
        //    catch
        //    {
        //        return View();
        //    }
        //}
        //#endregion

        //#region Methods Delete
        //public ActionResult Delete(int id)
        //{

        //    return View(BuscarId(id));
        //}

        //[HttpPost]
        //public ActionResult Delete(int id, IFormCollection collection)
        //{
        //    try
        //    {
        //        DeleteAluno(id);

        //        return RedirectToAction(nameof(Index));
        //    }
        //    catch
        //    {
        //        return View();
        //    }
        //}
        //#endregion

        //#region Method Details
        //public ActionResult Details(int id)
        //{
        //    return View(BuscarId(id));
        //}
        //#endregion

        //#region Methods Buscar
        //public ActionResult Buscar()
        //{
        //    string pesquisa = "";
        //    return View(BuscarAluno(pesquisa));
        //}

        //[HttpPost]
        //public ActionResult Buscar(string pesquisa)
        //{
        //    try
        //    {
        //        return View(BuscarAluno(pesquisa));
        //    }
        //    catch
        //    {
        //        return View();

        //    }
        //}
        //#endregion
        #endregion

    }
}