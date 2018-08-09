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
    public class AppInvestigationsController : Controller
    {
        private EntitiesInformante db = new EntitiesInformante();

        // GET: AppInvestigations
        public async Task<ActionResult> Index()
        {
            var aPP_VI_INVESTIGATIONS = db.APP_VI_INVESTIGATIONS.Include(a => a.APP_VI_CRIMES);
            return View(await aPP_VI_INVESTIGATIONS.ToListAsync());
        }

        // GET: AppInvestigations/Details/5
        public async Task<ActionResult> Details(decimal id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            APP_VI_INVESTIGATIONS aPP_VI_INVESTIGATIONS = await db.APP_VI_INVESTIGATIONS.FindAsync(id);
            if (aPP_VI_INVESTIGATIONS == null)
            {
                return HttpNotFound();
            }
            return View(aPP_VI_INVESTIGATIONS);
        }

        // GET: AppInvestigations/Create
        public ActionResult Create()
        {
            ViewBag.CRIME_ID = new SelectList(db.APP_VI_CRIMES, "CRIME_ID", "DESCRIPTION");
            return View();
        }

        // POST: AppInvestigations/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "INVESTIGATION_ID,CRIME_ID,NUNC,TITLE,DESCRIPTION,STATE,CITY")] APP_VI_INVESTIGATIONS aPP_VI_INVESTIGATIONS)
        {
            if (ModelState.IsValid)
            {
                db.APP_VI_INVESTIGATIONS.Add(aPP_VI_INVESTIGATIONS);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.CRIME_ID = new SelectList(db.APP_VI_CRIMES, "CRIME_ID", "DESCRIPTION", aPP_VI_INVESTIGATIONS.CRIME_ID);
            return View(aPP_VI_INVESTIGATIONS);
        }

        // GET: AppInvestigations/Edit/5
        public async Task<ActionResult> Edit(decimal id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            APP_VI_INVESTIGATIONS aPP_VI_INVESTIGATIONS = await db.APP_VI_INVESTIGATIONS.FindAsync(id);
            if (aPP_VI_INVESTIGATIONS == null)
            {
                return HttpNotFound();
            }
            ViewBag.CRIME_ID = new SelectList(db.APP_VI_CRIMES, "CRIME_ID", "DESCRIPTION", aPP_VI_INVESTIGATIONS.CRIME_ID);
            return View(aPP_VI_INVESTIGATIONS);
        }

        // POST: AppInvestigations/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "INVESTIGATION_ID,CRIME_ID,NUNC,TITLE,DESCRIPTION,STATE,CITY")] APP_VI_INVESTIGATIONS aPP_VI_INVESTIGATIONS)
        {
            if (ModelState.IsValid)
            {
                db.Entry(aPP_VI_INVESTIGATIONS).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.CRIME_ID = new SelectList(db.APP_VI_CRIMES, "CRIME_ID", "DESCRIPTION", aPP_VI_INVESTIGATIONS.CRIME_ID);
            return View(aPP_VI_INVESTIGATIONS);
        }

        // GET: AppInvestigations/Delete/5
        public async Task<ActionResult> Delete(decimal id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            APP_VI_INVESTIGATIONS aPP_VI_INVESTIGATIONS = await db.APP_VI_INVESTIGATIONS.FindAsync(id);
            if (aPP_VI_INVESTIGATIONS == null)
            {
                return HttpNotFound();
            }
            return View(aPP_VI_INVESTIGATIONS);
        }

        // POST: AppInvestigations/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(decimal id)
        {
            APP_VI_INVESTIGATIONS aPP_VI_INVESTIGATIONS = await db.APP_VI_INVESTIGATIONS.FindAsync(id);
            db.APP_VI_INVESTIGATIONS.Remove(aPP_VI_INVESTIGATIONS);
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
