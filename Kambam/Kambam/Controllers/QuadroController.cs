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
    public class QuadroController : Controller
    {
        private ProjetoServico pServico = new ProjetoServico();
        private QuadroServico qServico = new QuadroServico();
        // GET: Quadro
        public ActionResult Index()
        {
            return View();
        }

        private void PopularViewBag(Quadro quadro = null)
        {
            if (quadro == null)
            {
                ViewBag.ProjetoId = new SelectList(pServico.GetProjetos(), "ProjetoId", "Descricao");
            }
            else
            {
                ViewBag.ProjetoId = new SelectList(pServico.GetProjetos(), "ProjetoId", "Descricao", quadro.ProjetoId);
            }
        }

        // GET: Quadro/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Quadro/Create
        public ActionResult Create()
        {
            PopularViewBag();
            return View();
        }
        // POST: Quadro/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Quadro quadro)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    qServico.CriarQuadro(quadro);
                    return RedirectToAction("Index");
                }
                return View(quadro);
            }
            catch
            {
                return View(quadro);
            }
        }

        // GET: Quadro/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            QuadroServico pQuadro = new QuadroServico();
            Quadro quadro = pQuadro.ObterQuadroPorId(id);
            if (quadro == null)
            {
                return HttpNotFound();
            }
            return View(quadro);
        }

        // POST: Quadro/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Quadro quadro)
        {
            QuadroServico pQuadro = new QuadroServico();
            if (ModelState.IsValid) //testa se o modelo é válido, por exemplo se nenhum valor inválido foi inserido
            {

                pQuadro.EditarQuadro(quadro);
                return RedirectToAction("Index");
            }
            return View(quadro);
        }

        // GET: Quadro/Delete/5

        public ActionResult Delete(int? id) //long? significa que pode ser passado um valor nulo
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            QuadroServico pQuadro = new QuadroServico();
            Quadro quadro = pQuadro.RemoverQuadro(id);
            if (quadro == null)
            {
                return HttpNotFound();
            }
            return View(quadro);
        }

        // POST: Quadro
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id)
        {
            QuadroServico pQuadro = new QuadroServico();
            pQuadro.RemoverQuadro(id);
            return RedirectToAction("Index");
        }
    }
    }
