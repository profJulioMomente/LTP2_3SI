using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using LTP2DatabaseFirst.Models;

namespace LTP2DatabaseFirst.Controllers
{
    public class produtosController : Controller
    {
        private LTP2MVCDatabaseFirst2018Entities db = new LTP2MVCDatabaseFirst2018Entities();

        // GET: produtos
        public ActionResult Index()
        {
            var produtoes = db.produtoes.Include(p => p.categoria);
            return View(produtoes.ToList());
        }

        // GET: produtos/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            produto produto = db.produtoes.Find(id);
            if (produto == null)
            {
                return HttpNotFound();
            }
            return View(produto);
        }

        // GET: produtos/Create
        public ActionResult Create()
        {
            ViewBag.idCategoria = new SelectList(db.categorias, "idCategoria", "nomeCategoria");
            return View();
        }

        // POST: produtos/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "idProduo,nomeProduto,descricaoProduto,precoProduto,idCategoria")] produto produto)
        {
            if (ModelState.IsValid)
            {
                db.produtoes.Add(produto);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.idCategoria = new SelectList(db.categorias, "idCategoria", "nomeCategoria", produto.idCategoria);
            return View(produto);
        }

        // GET: produtos/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            produto produto = db.produtoes.Find(id);
            if (produto == null)
            {
                return HttpNotFound();
            }
            ViewBag.idCategoria = new SelectList(db.categorias, "idCategoria", "nomeCategoria", produto.idCategoria);
            return View(produto);
        }

        // POST: produtos/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "idProduo,nomeProduto,descricaoProduto,precoProduto,idCategoria")] produto produto)
        {
            if (ModelState.IsValid)
            {
                db.Entry(produto).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.idCategoria = new SelectList(db.categorias, "idCategoria", "nomeCategoria", produto.idCategoria);
            return View(produto);
        }

        // GET: produtos/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            produto produto = db.produtoes.Find(id);
            if (produto == null)
            {
                return HttpNotFound();
            }
            return View(produto);
        }

        // POST: produtos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            produto produto = db.produtoes.Find(id);
            db.produtoes.Remove(produto);
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
