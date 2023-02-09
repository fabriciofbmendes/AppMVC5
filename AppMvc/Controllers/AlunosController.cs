using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using AppMvc.Models;

namespace AppMvc.Controllers
{
    public class AlunosController : Controller
    {
        private readonly ApplicationDbContext db = new ApplicationDbContext();

        // GET: Alunos
        [HttpGet]
        [Route("listar-alunos")]
        public async Task<ActionResult> Index()
        {
            return View(await db.Alunos.ToListAsync());
        }

        // GET: Alunos/Details/5
        [HttpGet]
        [Route("aluno-detalhe/{id:int}")]
        public async Task<ActionResult> Details(int id)
        {

            var aluno = await db.Alunos.FindAsync(id);

            if (aluno == null)
            {
                return HttpNotFound();
            }
            return View(aluno);
        }

        // GET: Alunos/Create
        [HttpGet]
        [Route("novo-aluno")]
        public ActionResult Create()
        {
            return View();
        }

        // POST: Alunos/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Route("novo-aluno")]
        public async Task<ActionResult> Create([Bind(Include = "Id,Nome,Email,Descricao,CPF,Ativo")] Aluno aluno)
        {
            if (ModelState.IsValid)
            {
                aluno.DataMatricula = DateTime.Now;
                db.Alunos.Add(aluno);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(aluno);
        }

        // GET: Alunos/Edit/5
        [HttpGet]
        [Route("editar-aluno/{id:int}")]
        public async Task<ActionResult> Edit(int id)
        {
     
            var aluno = await db.Alunos.FindAsync(id);

            if (aluno == null)
            {
                return HttpNotFound();
            }
            return View(aluno);
        }

        // POST: Alunos/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Route("editar-aluno/{id:int}")]
        public async Task<ActionResult> Edit([Bind(Include = "Id,Nome,Email,Descricao,CPF,Ativo")] Aluno aluno)
        {
            if (ModelState.IsValid)
            {
                db.Entry(aluno).State = EntityState.Modified;
                db.Entry(aluno).Property(a => a.DataMatricula).IsModified = false;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(aluno);
        }

        [HttpGet]
        [Route("excluir-aluno/{id:int}")]
        public async Task<ActionResult> Delete(int id)
        {
            Aluno aluno = await db.Alunos.FindAsync(id);
            if (aluno == null)
            {
                return HttpNotFound();
            }
            return View(aluno);
        }

        // POST: Alunos/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Route("excluir-aluno/{id:int}")]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Aluno aluno = await db.Alunos.FindAsync(id);
            db.Alunos.Remove(aluno);
            await db.SaveChangesAsync();
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
