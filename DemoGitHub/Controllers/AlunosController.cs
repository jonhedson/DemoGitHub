using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using DemoGitHub.Models;
using Microsoft.AspNetCore.Http;
using DemoGitHub.Repository;
using DemoGitHub.ViewModels;

namespace DemoGitHub.Controllers
{
    public class AlunosController : Controller
    {

        #region Ações do Controlador

        #region Method Index -> GetAllAlunos - OK
        public ActionResult Index()
        {
            //var alunoRepository = new AlunoRepository();
            //var alunos = new List<AlunoViewModel>();

            IEnumerable<Aluno> alunos = AlunoRepository.GetalunoList();

            IEnumerable<AlunoViewModel> alunosviewmodel = alunos.Select(x => new AlunoViewModel
            {
                AlunoId = x.AlunoId,
                Nome = x.Nome,
                Campus = x.Campus,
                Curso = x.Curso,
                Sexo =  x.Sexo
            });
            return View(alunosviewmodel);
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

        #region Methods Edit
        public ActionResult Edit(int id)
        {
            Aluno aluno = AlunoRepository.BuscarId(id);
            AlunoViewModel alunoviewmodel = new AlunoViewModel
            {
                Nome = aluno.Nome,
                Campus = aluno.Campus,
                Curso = aluno.Curso,
                Sexo = aluno.Sexo

            };
            return View(alunoviewmodel);
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
                

                AlunoRepository.EditAluno(id, aluno);
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
            Aluno aluno = AlunoRepository.BuscarId(id);
            AlunoViewModel alunoviewmodel = new AlunoViewModel
            {
                AlunoId = aluno.AlunoId,
                Nome = aluno.Nome,
                Campus = aluno.Campus,
                Curso = aluno.Curso,
                Sexo = aluno.Sexo

            };
            return View(alunoviewmodel);
        }

        [HttpPost]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                AlunoRepository.DeleteAluno(id);

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
            Aluno aluno = AlunoRepository.BuscarId(id);
            AlunoViewModel alunoviewmodel = new AlunoViewModel
            {
                AlunoId = aluno.AlunoId,
                Nome = aluno.Nome,
                Campus = aluno.Campus,
                Curso = aluno.Curso,
                Sexo = aluno.Sexo

            };
            return View(alunoviewmodel);
        }
        #endregion

        #region Methods Buscar
        public ActionResult Buscar(string pesquisa)
        {
            IEnumerable<Aluno> alunos = AlunoRepository.BuscarAluno(pesquisa);

            IEnumerable<AlunoViewModel> alunosviewmodel = alunos.Select(x => new AlunoViewModel
            {
                AlunoId = x.AlunoId,
                Nome = x.Nome,
                Campus = x.Campus,
                Curso = x.Curso,
                Sexo = x.Sexo
            });
            return View(alunosviewmodel);
        }

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
        #endregion

        #endregion
    }
}