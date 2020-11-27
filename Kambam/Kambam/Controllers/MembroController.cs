using Modelo.Classes;
using Servicos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace Kambam.Controllers
{
    public class MembroController : Controller
    {
        private MembroServico pMembro = new MembroServico();
        // GET: Painel
        public ActionResult Index()
        {
            return View(pMembro.GetMembro());
        }


        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Membro membro)
        {
            MembroServico pMembro = new MembroServico();
            pMembro.CriarMembro(membro);
            return RedirectToAction("Index");
        }

        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MembroServico pMembro = new MembroServico();
            Membro membro = pMembro.ObterMembroPorId(id);
            if (membro == null)
            {
                return HttpNotFound();
            }
            return View(membro);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Membro membro)
        {
            MembroServico pMembro = new MembroServico();
            if (ModelState.IsValid) //testa se o modelo é válido, por exemplo se nenhum valor inválido foi inserido
            {

                pMembro.EditarMembro(membro);
                return RedirectToAction("Index");
            }
            return View(membro);
        }

        public ActionResult Delete(int? id) //long? significa que pode ser passado um valor nulo
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MembroServico pMembro = new MembroServico();
            Membro membro = pMembro.ObterMembroPorId(id);
            if (membro == null)
            {
                return HttpNotFound();
            }
            return View(membro);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id)
        {
            MembroServico pMembro = new MembroServico();
            pMembro.RemoverMembro(id);
            return RedirectToAction("Index");
        }

        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MembroServico pMembro = new MembroServico();
            Membro membro = pMembro.ObterMembroPorId(id);
            if (membro == null)
            {
                return HttpNotFound();
            }
            return View(membro);
        }
    }
}
