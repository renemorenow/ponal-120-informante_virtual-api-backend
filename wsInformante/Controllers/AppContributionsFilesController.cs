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
    public class AppContributionsFilesController : Controller
    {
        private EntitiesInformante db = new EntitiesInformante();

        // GET: AppContributionsFiles
        public async Task<ActionResult> Index()
        {
            var aPP_VI_CONTRIBUTIONS_FILES = db.APP_VI_CONTRIBUTIONS_FILES.Include(a => a.APP_VI_CONTRIBUTIONS);
            return View(await aPP_VI_CONTRIBUTIONS_FILES.ToListAsync());
        }

        // GET: AppContributionsFiles/Details/5
        public async Task<ActionResult> Details(decimal id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            APP_VI_CONTRIBUTIONS_FILES aPP_VI_CONTRIBUTIONS_FILES = await db.APP_VI_CONTRIBUTIONS_FILES.FindAsync(id);
            if (aPP_VI_CONTRIBUTIONS_FILES == null)
            {
                return HttpNotFound();
            }
            return View(aPP_VI_CONTRIBUTIONS_FILES);
        }

        // GET: AppContributionsFiles/Create
        public ActionResult Create()
        {
            ViewBag.CONTRIBUTION_ID = new SelectList(db.APP_VI_CONTRIBUTIONS, "CONTRIBUTION_ID", "DESCRIPTION");
            return View();
        }

        // POST: AppContributionsFiles/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "CONTRIBUTION_FILE_ID,CONTRIBUTION_ID,PATH,CONTENT_TYPE")] APP_VI_CONTRIBUTIONS_FILES aPP_VI_CONTRIBUTIONS_FILES)
        {
            if (ModelState.IsValid)
            {
                db.APP_VI_CONTRIBUTIONS_FILES.Add(aPP_VI_CONTRIBUTIONS_FILES);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.CONTRIBUTION_ID = new SelectList(db.APP_VI_CONTRIBUTIONS, "CONTRIBUTION_ID", "DESCRIPTION", aPP_VI_CONTRIBUTIONS_FILES.CONTRIBUTION_ID);
            return View(aPP_VI_CONTRIBUTIONS_FILES);
        }

        // GET: AppContributionsFiles/Edit/5
        public async Task<ActionResult> Edit(decimal id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            APP_VI_CONTRIBUTIONS_FILES aPP_VI_CONTRIBUTIONS_FILES = await db.APP_VI_CONTRIBUTIONS_FILES.FindAsync(id);
            if (aPP_VI_CONTRIBUTIONS_FILES == null)
            {
                return HttpNotFound();
            }
            ViewBag.CONTRIBUTION_ID = new SelectList(db.APP_VI_CONTRIBUTIONS, "CONTRIBUTION_ID", "DESCRIPTION", aPP_VI_CONTRIBUTIONS_FILES.CONTRIBUTION_ID);
            return View(aPP_VI_CONTRIBUTIONS_FILES);
        }

        // POST: AppContributionsFiles/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "CONTRIBUTION_FILE_ID,CONTRIBUTION_ID,PATH,CONTENT_TYPE")] APP_VI_CONTRIBUTIONS_FILES aPP_VI_CONTRIBUTIONS_FILES)
        {
            if (ModelState.IsValid)
            {
                db.Entry(aPP_VI_CONTRIBUTIONS_FILES).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.CONTRIBUTION_ID = new SelectList(db.APP_VI_CONTRIBUTIONS, "CONTRIBUTION_ID", "DESCRIPTION", aPP_VI_CONTRIBUTIONS_FILES.CONTRIBUTION_ID);
            return View(aPP_VI_CONTRIBUTIONS_FILES);
        }

        // GET: AppContributionsFiles/Delete/5
        public async Task<ActionResult> Delete(decimal id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            APP_VI_CONTRIBUTIONS_FILES aPP_VI_CONTRIBUTIONS_FILES = await db.APP_VI_CONTRIBUTIONS_FILES.FindAsync(id);
            if (aPP_VI_CONTRIBUTIONS_FILES == null)
            {
                return HttpNotFound();
            }
            return View(aPP_VI_CONTRIBUTIONS_FILES);
        }

        // POST: AppContributionsFiles/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(decimal id)
        {
            APP_VI_CONTRIBUTIONS_FILES aPP_VI_CONTRIBUTIONS_FILES = await db.APP_VI_CONTRIBUTIONS_FILES.FindAsync(id);
            db.APP_VI_CONTRIBUTIONS_FILES.Remove(aPP_VI_CONTRIBUTIONS_FILES);
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
