using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using Servicos;
using Modelo.Classes;
using System.Net;

namespace Kambam.Controllers
{
    public class PainelController : Controller
    {
        private ProjetoServico pServico = new ProjetoServico();
        // GET: Painel
        public ActionResult Index()
        {
            return View(pServico.GetProjetos());
        }


        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Projeto projeto)
        {
            ProjetoServico pServico = new ProjetoServico();
            pServico.CriarProjeto(projeto);
            return RedirectToAction("Index");
        }

        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProjetoServico pServico = new ProjetoServico();
            Projeto projeto = pServico.ObterProjetoPorId(id);
            if (projeto == null)
            {
                return HttpNotFound();
            }
            return View(projeto);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Projeto projeto)
        {
            ProjetoServico pServico = new ProjetoServico();
            if (ModelState.IsValid) //testa se o modelo é válido, por exemplo se nenhum valor inválido foi inserido
            {

                pServico.EditarProjeto(projeto);
                return RedirectToAction("Index");
            }
            return View(projeto);
        }

        public ActionResult Delete(int? id) //long? significa que pode ser passado um valor nulo
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProjetoServico pServico = new ProjetoServico();
            Projeto projeto = pServico.ObterProjetoPorId(id);
            if (projeto == null)
            {
                return HttpNotFound();
            }
            return View(projeto);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id)
        {
            ProjetoServico pServico = new ProjetoServico();
            pServico.RemoverProjeto(id);
            return RedirectToAction("Index");
        }

        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProjetoServico pServico = new ProjetoServico();
            Projeto projeto = pServico.DetalhesProjeto(id);
            if (projeto == null)
            {
                return HttpNotFound();
            }
            return View(projeto);
        }


    }
}