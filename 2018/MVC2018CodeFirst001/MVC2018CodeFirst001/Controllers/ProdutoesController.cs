using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MVC2018CodeFirst001.Models;

namespace MVC2018CodeFirst001.Controllers
{
    public class ProdutoesController : Controller
    {
        private MVC2018CodeFirst001Context db = new MVC2018CodeFirst001Context();

        // GET: Produtoes
        public ActionResult Index()
        {
            var produtoes = db.Produtoes.Include(p => p.categoria);
            return View(produtoes.ToList());
        }

        [HttpPost]
        public ActionResult Index(string campo, string pesquisa)
        {

            var produtoes = db.Produtoes.Include(p => p.categoria);

            if (!String.IsNullOrEmpty(pesquisa))
            {
                switch (campo)
                {
                    case "nome":
                        produtoes = produtoes.Where(p => p.nomeProduto.Contains(pesquisa));
                        break;
                    case "descrição":
                        produtoes = produtoes.Where(p => p.descricaoProduto.Contains(pesquisa));
                        break;
                }
                produtoes = produtoes.Where(p => p.nomeProduto.Contains(pesquisa));
            }
            return View(produtoes.ToList());
        }

        // GET: Produtoes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Produto produto = db.Produtoes.Find(id);
            if (produto == null)
            {
                return HttpNotFound();
            }
            return View(produto);
        }

        // GET: Produtoes/Create
        public ActionResult Create()
        {
            ViewBag.idCategoria = new SelectList(db.categorias, "idCategoria", "nomeCategoria");
            return View();
        }

        // POST: Produtoes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "idProduto,nomeProduto,descricaoProduto,preco,idCategoria")] Produto produto)
        {
            if (ModelState.IsValid)
            {
                db.Produtoes.Add(produto);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.idCategoria = new SelectList(db.categorias, "idCategoria", "nomeCategoria", produto.idCategoria);
            return View(produto);
        }

        // GET: Produtoes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Produto produto = db.Produtoes.Find(id);
            if (produto == null)
            {
                return HttpNotFound();
            }
            ViewBag.idCategoria = new SelectList(db.categorias, "idCategoria", "nomeCategoria", produto.idCategoria);
            return View(produto);
        }

        // POST: Produtoes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "idProduto,nomeProduto,descricaoProduto,preco,idCategoria")] Produto produto)
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

        // GET: Produtoes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Produto produto = db.Produtoes.Find(id);
            if (produto == null)
            {
                return HttpNotFound();
            }
            return View(produto);
        }

        // POST: Produtoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Produto produto = db.Produtoes.Find(id);
            db.Produtoes.Remove(produto);
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
