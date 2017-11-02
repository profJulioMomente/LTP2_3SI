using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using LTP2_MVC_Exemplo.Models;

namespace LTP2_MVC_Exemplo.Controllers
{
    public class CoordenacoesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Coordenacoes
        public ActionResult Index()
        {
            var coordenacaos = db.Coordenacaos.Include(c => c.Curso);
            return View(coordenacaos.ToList());
        }

        // GET: Coordenacoes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Coordenacao coordenacao = db.Coordenacaos.Find(id);
            if (coordenacao == null)
            {
                return HttpNotFound();
            }
            return View(coordenacao);
        }

        // GET: Coordenacoes/Create
        public ActionResult Create()
        {
            ViewBag.id_Coordenacao = new SelectList(db.Cursoes, "id_curso", "codigo_curso");
            return View();
        }

        // POST: Coordenacoes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id_Coordenacao,nome_Coordenacao,atendimento_Coordenacao")] Coordenacao coordenacao)
        {
            if (ModelState.IsValid)
            {
                db.Coordenacaos.Add(coordenacao);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.id_Coordenacao = new SelectList(db.Cursoes, "id_curso", "codigo_curso", coordenacao.id_Coordenacao);
            return View(coordenacao);
        }

        // GET: Coordenacoes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Coordenacao coordenacao = db.Coordenacaos.Find(id);
            if (coordenacao == null)
            {
                return HttpNotFound();
            }
            ViewBag.id_Coordenacao = new SelectList(db.Cursoes, "id_curso", "codigo_curso", coordenacao.id_Coordenacao);
            return View(coordenacao);
        }

        // POST: Coordenacoes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id_Coordenacao,nome_Coordenacao,atendimento_Coordenacao")] Coordenacao coordenacao)
        {
            if (ModelState.IsValid)
            {
                db.Entry(coordenacao).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.id_Coordenacao = new SelectList(db.Cursoes, "id_curso", "codigo_curso", coordenacao.id_Coordenacao);
            return View(coordenacao);
        }

        // GET: Coordenacoes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Coordenacao coordenacao = db.Coordenacaos.Find(id);
            if (coordenacao == null)
            {
                return HttpNotFound();
            }
            return View(coordenacao);
        }

        // POST: Coordenacoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Coordenacao coordenacao = db.Coordenacaos.Find(id);
            db.Coordenacaos.Remove(coordenacao);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
