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
    public class AppContributionsController : Controller
    {
        private EntitiesInformante db = new EntitiesInformante();

        // GET: AppContributions
        public async Task<ActionResult> Index()
        {
            var aPP_VI_CONTRIBUTIONS = db.APP_VI_CONTRIBUTIONS.Include(a => a.APP_VI_INFORMANTS).Include(a => a.APP_VI_INVESTIGATIONS);
            return View(await aPP_VI_CONTRIBUTIONS.ToListAsync());
        }

        // GET: AppContributions/Details/5
        public async Task<ActionResult> Details(decimal id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            APP_VI_CONTRIBUTIONS aPP_VI_CONTRIBUTIONS = await db.APP_VI_CONTRIBUTIONS.FindAsync(id);
            if (aPP_VI_CONTRIBUTIONS == null)
            {
                return HttpNotFound();
            }
            return View(aPP_VI_CONTRIBUTIONS);
        }

        // GET: AppContributions/Create
        public ActionResult Create()
        {
            ViewBag.INFORMANT_ID = new SelectList(db.APP_VI_INFORMANTS, "INFORMANT_ID", "FIRST_NAME");
            ViewBag.INVESTIGATION_ID = new SelectList(db.APP_VI_INVESTIGATIONS, "INVESTIGATION_ID", "NUNC");
            return View();
        }

        // POST: AppContributions/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "CONTRIBUTION_ID,INVESTIGATION_ID,DESCRIPTION,INFORMANT_ID")] APP_VI_CONTRIBUTIONS aPP_VI_CONTRIBUTIONS)
        {
            if (ModelState.IsValid)
            {
                db.APP_VI_CONTRIBUTIONS.Add(aPP_VI_CONTRIBUTIONS);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.INFORMANT_ID = new SelectList(db.APP_VI_INFORMANTS, "INFORMANT_ID", "FIRST_NAME", aPP_VI_CONTRIBUTIONS.INFORMANT_ID);
            ViewBag.INVESTIGATION_ID = new SelectList(db.APP_VI_INVESTIGATIONS, "INVESTIGATION_ID", "NUNC", aPP_VI_CONTRIBUTIONS.INVESTIGATION_ID);
            return View(aPP_VI_CONTRIBUTIONS);
        }

        // GET: AppContributions/Edit/5
        public async Task<ActionResult> Edit(decimal id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            APP_VI_CONTRIBUTIONS aPP_VI_CONTRIBUTIONS = await db.APP_VI_CONTRIBUTIONS.FindAsync(id);
            if (aPP_VI_CONTRIBUTIONS == null)
            {
                return HttpNotFound();
            }
            ViewBag.INFORMANT_ID = new SelectList(db.APP_VI_INFORMANTS, "INFORMANT_ID", "FIRST_NAME", aPP_VI_CONTRIBUTIONS.INFORMANT_ID);
            ViewBag.INVESTIGATION_ID = new SelectList(db.APP_VI_INVESTIGATIONS, "INVESTIGATION_ID", "NUNC", aPP_VI_CONTRIBUTIONS.INVESTIGATION_ID);
            return View(aPP_VI_CONTRIBUTIONS);
        }

        // POST: AppContributions/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "CONTRIBUTION_ID,INVESTIGATION_ID,DESCRIPTION,INFORMANT_ID")] APP_VI_CONTRIBUTIONS aPP_VI_CONTRIBUTIONS)
        {
            if (ModelState.IsValid)
            {
                db.Entry(aPP_VI_CONTRIBUTIONS).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.INFORMANT_ID = new SelectList(db.APP_VI_INFORMANTS, "INFORMANT_ID", "FIRST_NAME", aPP_VI_CONTRIBUTIONS.INFORMANT_ID);
            ViewBag.INVESTIGATION_ID = new SelectList(db.APP_VI_INVESTIGATIONS, "INVESTIGATION_ID", "NUNC", aPP_VI_CONTRIBUTIONS.INVESTIGATION_ID);
            return View(aPP_VI_CONTRIBUTIONS);
        }

        // GET: AppContributions/Delete/5
        public async Task<ActionResult> Delete(decimal id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            APP_VI_CONTRIBUTIONS aPP_VI_CONTRIBUTIONS = await db.APP_VI_CONTRIBUTIONS.FindAsync(id);
            if (aPP_VI_CONTRIBUTIONS == null)
            {
                return HttpNotFound();
            }
            return View(aPP_VI_CONTRIBUTIONS);
        }

        // POST: AppContributions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(decimal id)
        {
            APP_VI_CONTRIBUTIONS aPP_VI_CONTRIBUTIONS = await db.APP_VI_CONTRIBUTIONS.FindAsync(id);
            db.APP_VI_CONTRIBUTIONS.Remove(aPP_VI_CONTRIBUTIONS);
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
