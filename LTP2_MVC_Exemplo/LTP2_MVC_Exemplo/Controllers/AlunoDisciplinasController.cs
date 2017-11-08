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
    public class AlunoDisciplinasController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: AlunoDisciplinas
        public ActionResult Index()
        {
            var alunoDisciplinas = db.AlunoDisciplinas.Include(a => a.Aluno).Include(a => a.Disciplina);
            return View(alunoDisciplinas.ToList());
        }

        // GET: AlunoDisciplinas/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AlunoDisciplina alunoDisciplina = db.AlunoDisciplinas.Find(id);
            if (alunoDisciplina == null)
            {
                return HttpNotFound();
            }
            return View(alunoDisciplina);
        }

        // GET: AlunoDisciplinas/Create
        public ActionResult Create()
        {
            ViewBag.id_Aluno = new SelectList(db.Alunoes, "id_Aluno", "nome_Aluno");
            ViewBag.id_Disciplina = new SelectList(db.Disciplinas, "id_Disciplina", "nome_Disciplia");
            return View();
        }

        // POST: AlunoDisciplinas/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id_AlunoDisciplina,id_Aluno,id_Disciplina")] AlunoDisciplina alunoDisciplina)
        {
            if (ModelState.IsValid)
            {
                db.AlunoDisciplinas.Add(alunoDisciplina);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.id_Aluno = new SelectList(db.Alunoes, "id_Aluno", "nome_Aluno", alunoDisciplina.id_Aluno);
            ViewBag.id_Disciplina = new SelectList(db.Disciplinas, "id_Disciplina", "nome_Disciplia", alunoDisciplina.id_Disciplina);
            return View(alunoDisciplina);
        }

        // GET: AlunoDisciplinas/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AlunoDisciplina alunoDisciplina = db.AlunoDisciplinas.Find(id);
            if (alunoDisciplina == null)
            {
                return HttpNotFound();
            }
            ViewBag.id_Aluno = new SelectList(db.Alunoes, "id_Aluno", "nome_Aluno", alunoDisciplina.id_Aluno);
            ViewBag.id_Disciplina = new SelectList(db.Disciplinas, "id_Disciplina", "nome_Disciplia", alunoDisciplina.id_Disciplina);
            return View(alunoDisciplina);
        }

        // POST: AlunoDisciplinas/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id_AlunoDisciplina,id_Aluno,id_Disciplina")] AlunoDisciplina alunoDisciplina)
        {
            if (ModelState.IsValid)
            {
                db.Entry(alunoDisciplina).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.id_Aluno = new SelectList(db.Alunoes, "id_Aluno", "nome_Aluno", alunoDisciplina.id_Aluno);
            ViewBag.id_Disciplina = new SelectList(db.Disciplinas, "id_Disciplina", "nome_Disciplia", alunoDisciplina.id_Disciplina);
            return View(alunoDisciplina);
        }

        // GET: AlunoDisciplinas/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AlunoDisciplina alunoDisciplina = db.AlunoDisciplinas.Find(id);
            if (alunoDisciplina == null)
            {
                return HttpNotFound();
            }
            return View(alunoDisciplina);
        }

        // POST: AlunoDisciplinas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            AlunoDisciplina alunoDisciplina = db.AlunoDisciplinas.Find(id);
            db.AlunoDisciplinas.Remove(alunoDisciplina);
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
