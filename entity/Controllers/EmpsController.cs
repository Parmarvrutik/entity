using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using entity.Models;

namespace entity.Controllers
{
    public class EmpsController : Controller
    {
        private EmpEntities1 db = new EmpEntities1();

        // GET: Emps
        public async Task<ActionResult> Index()
        {
            return View(await db.Emps.ToListAsync());
        }

        // GET: Emps/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Emp emp = await db.Emps.FindAsync(id);
            if (emp == null)
            {
                return HttpNotFound();
            }
            return View(emp);
        }

        // GET: Emps/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Emps/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "Emp_Id,Emp_Name")] Emp emp)
        {
            if (ModelState.IsValid)
            {
                db.Emps.Add(emp);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(emp);
        }

        // GET: Emps/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Emp emp = await db.Emps.FindAsync(id);
            if (emp == null)
            {
                return HttpNotFound();
            }
            return View(emp);
        }

        // POST: Emps/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "Emp_Id,Emp_Name")] Emp emp)
        {
            if (ModelState.IsValid)
            {
                db.Entry(emp).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(emp);
        }

        // GET: Emps/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Emp emp = await db.Emps.FindAsync(id);
            if (emp == null)
            {
                return HttpNotFound();
            }
            return View(emp);
        }

        // POST: Emps/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Emp emp = await db.Emps.FindAsync(id);
            db.Emps.Remove(emp);
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
