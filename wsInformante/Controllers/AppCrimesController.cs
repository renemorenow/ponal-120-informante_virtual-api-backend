using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using wsInformante.Models;

namespace wsInformante.Controllers
{
    public class AppCrimesController : Controller
    {
        private EntitiesInformante db = new EntitiesInformante();

        // GET: AppCrimes
        public async Task<ActionResult> Index()
        {
            return View(await db.APP_VI_CRIMES.ToListAsync());
        }

        // GET: AppCrimes/Details/5
        public async Task<ActionResult> Details(decimal id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            APP_VI_CRIMES aPP_VI_CRIMES = await db.APP_VI_CRIMES.FindAsync(id);
            if (aPP_VI_CRIMES == null)
            {
                return HttpNotFound();
            }
            return View(aPP_VI_CRIMES);
        }

        // GET: AppCrimes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: AppCrimes/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "CRIME_ID,DESCRIPTION,LEGAL_INFORMATION")] APP_VI_CRIMES aPP_VI_CRIMES)
        {
            if (ModelState.IsValid)
            {
                db.APP_VI_CRIMES.Add(aPP_VI_CRIMES);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(aPP_VI_CRIMES);
        }

        // GET: AppCrimes/Edit/5
        public async Task<ActionResult> Edit(decimal id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            APP_VI_CRIMES aPP_VI_CRIMES = await db.APP_VI_CRIMES.FindAsync(id);
            if (aPP_VI_CRIMES == null)
            {
                return HttpNotFound();
            }
            return View(aPP_VI_CRIMES);
        }

        // POST: AppCrimes/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "CRIME_ID,DESCRIPTION,LEGAL_INFORMATION")] APP_VI_CRIMES aPP_VI_CRIMES)
        {
            if (ModelState.IsValid)
            {
                db.Entry(aPP_VI_CRIMES).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(aPP_VI_CRIMES);
        }

        // GET: AppCrimes/Delete/5
        public async Task<ActionResult> Delete(decimal id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            APP_VI_CRIMES aPP_VI_CRIMES = await db.APP_VI_CRIMES.FindAsync(id);
            if (aPP_VI_CRIMES == null)
            {
                return HttpNotFound();
            }
            return View(aPP_VI_CRIMES);
        }

        // POST: AppCrimes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(decimal id)
        {
            APP_VI_CRIMES aPP_VI_CRIMES = await db.APP_VI_CRIMES.FindAsync(id);
            db.APP_VI_CRIMES.Remove(aPP_VI_CRIMES);
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
