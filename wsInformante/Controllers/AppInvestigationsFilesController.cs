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
    public class AppInvestigationsFilesController : Controller
    {
        private EntitiesInformante db = new EntitiesInformante();

        // GET: AppInvestigationsFiles
        public async Task<ActionResult> Index()
        {
            var aPP_VI_INVESTIGATION_FILES = db.APP_VI_INVESTIGATION_FILES.Include(a => a.APP_VI_INVESTIGATIONS);
            return View(await aPP_VI_INVESTIGATION_FILES.ToListAsync());
        }

        // GET: AppInvestigationsFiles/Details/5
        public async Task<ActionResult> Details(decimal id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            APP_VI_INVESTIGATION_FILES aPP_VI_INVESTIGATION_FILES = await db.APP_VI_INVESTIGATION_FILES.FindAsync(id);
            if (aPP_VI_INVESTIGATION_FILES == null)
            {
                return HttpNotFound();
            }
            return View(aPP_VI_INVESTIGATION_FILES);
        }

        // GET: AppInvestigationsFiles/Create
        public ActionResult Create()
        {
            ViewBag.INVESTIGATION_ID = new SelectList(db.APP_VI_INVESTIGATIONS, "INVESTIGATION_ID", "NUNC");
            return View();
        }

        // POST: AppInvestigationsFiles/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "INVESTIGATION_FILE_ID,INVESTIGATION_ID,PATH,CONTENT_TYPE")] APP_VI_INVESTIGATION_FILES aPP_VI_INVESTIGATION_FILES)
        {
            if (ModelState.IsValid)
            {
                db.APP_VI_INVESTIGATION_FILES.Add(aPP_VI_INVESTIGATION_FILES);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.INVESTIGATION_ID = new SelectList(db.APP_VI_INVESTIGATIONS, "INVESTIGATION_ID", "NUNC", aPP_VI_INVESTIGATION_FILES.INVESTIGATION_ID);
            return View(aPP_VI_INVESTIGATION_FILES);
        }

        // GET: AppInvestigationsFiles/Edit/5
        public async Task<ActionResult> Edit(decimal id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            APP_VI_INVESTIGATION_FILES aPP_VI_INVESTIGATION_FILES = await db.APP_VI_INVESTIGATION_FILES.FindAsync(id);
            if (aPP_VI_INVESTIGATION_FILES == null)
            {
                return HttpNotFound();
            }
            ViewBag.INVESTIGATION_ID = new SelectList(db.APP_VI_INVESTIGATIONS, "INVESTIGATION_ID", "NUNC", aPP_VI_INVESTIGATION_FILES.INVESTIGATION_ID);
            return View(aPP_VI_INVESTIGATION_FILES);
        }

        // POST: AppInvestigationsFiles/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "INVESTIGATION_FILE_ID,INVESTIGATION_ID,PATH,CONTENT_TYPE")] APP_VI_INVESTIGATION_FILES aPP_VI_INVESTIGATION_FILES)
        {
            if (ModelState.IsValid)
            {
                db.Entry(aPP_VI_INVESTIGATION_FILES).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.INVESTIGATION_ID = new SelectList(db.APP_VI_INVESTIGATIONS, "INVESTIGATION_ID", "NUNC", aPP_VI_INVESTIGATION_FILES.INVESTIGATION_ID);
            return View(aPP_VI_INVESTIGATION_FILES);
        }

        // GET: AppInvestigationsFiles/Delete/5
        public async Task<ActionResult> Delete(decimal id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            APP_VI_INVESTIGATION_FILES aPP_VI_INVESTIGATION_FILES = await db.APP_VI_INVESTIGATION_FILES.FindAsync(id);
            if (aPP_VI_INVESTIGATION_FILES == null)
            {
                return HttpNotFound();
            }
            return View(aPP_VI_INVESTIGATION_FILES);
        }

        // POST: AppInvestigationsFiles/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(decimal id)
        {
            APP_VI_INVESTIGATION_FILES aPP_VI_INVESTIGATION_FILES = await db.APP_VI_INVESTIGATION_FILES.FindAsync(id);
            db.APP_VI_INVESTIGATION_FILES.Remove(aPP_VI_INVESTIGATION_FILES);
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
