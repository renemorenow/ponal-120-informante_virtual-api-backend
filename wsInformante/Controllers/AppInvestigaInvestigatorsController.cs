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
    public class AppInvestigaInvestigatorsController : Controller
    {
        private EntitiesInformante db = new EntitiesInformante();

        // GET: AppInvestigaInvestigators
        public async Task<ActionResult> Index()
        {
            var aPP_VI_INVESTIGA_INVESTIGATORS = db.APP_VI_INVESTIGA_INVESTIGATORS.Include(a => a.APP_VI_INVESTIGATORS).Include(a => a.APP_VI_INVESTIGATIONS);
            return View(await aPP_VI_INVESTIGA_INVESTIGATORS.ToListAsync());
        }

        // GET: AppInvestigaInvestigators/Details/5
        public async Task<ActionResult> Details(decimal id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            APP_VI_INVESTIGA_INVESTIGATORS aPP_VI_INVESTIGA_INVESTIGATORS = await db.APP_VI_INVESTIGA_INVESTIGATORS.FindAsync(id);
            if (aPP_VI_INVESTIGA_INVESTIGATORS == null)
            {
                return HttpNotFound();
            }
            return View(aPP_VI_INVESTIGA_INVESTIGATORS);
        }

        // GET: AppInvestigaInvestigators/Create
        public ActionResult Create()
        {
            ViewBag.INVESTIGATOR_ID = new SelectList(db.APP_VI_INVESTIGATORS, "INVESTIGATOR_ID", "FIRST_NAME");
            ViewBag.INVESTIGATION_ID = new SelectList(db.APP_VI_INVESTIGATIONS, "INVESTIGATION_ID", "NUNC");
            return View();
        }

        // POST: AppInvestigaInvestigators/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "INVESTIGATION_INVESTIGATOR_ID,INVESTIGATION_ID,INVESTIGATOR_ID,IS_ACTIVE")] APP_VI_INVESTIGA_INVESTIGATORS aPP_VI_INVESTIGA_INVESTIGATORS)
        {
            if (ModelState.IsValid)
            {
                db.APP_VI_INVESTIGA_INVESTIGATORS.Add(aPP_VI_INVESTIGA_INVESTIGATORS);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.INVESTIGATOR_ID = new SelectList(db.APP_VI_INVESTIGATORS, "INVESTIGATOR_ID", "FIRST_NAME", aPP_VI_INVESTIGA_INVESTIGATORS.INVESTIGATOR_ID);
            ViewBag.INVESTIGATION_ID = new SelectList(db.APP_VI_INVESTIGATIONS, "INVESTIGATION_ID", "NUNC", aPP_VI_INVESTIGA_INVESTIGATORS.INVESTIGATION_ID);
            return View(aPP_VI_INVESTIGA_INVESTIGATORS);
        }

        // GET: AppInvestigaInvestigators/Edit/5
        public async Task<ActionResult> Edit(decimal id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            APP_VI_INVESTIGA_INVESTIGATORS aPP_VI_INVESTIGA_INVESTIGATORS = await db.APP_VI_INVESTIGA_INVESTIGATORS.FindAsync(id);
            if (aPP_VI_INVESTIGA_INVESTIGATORS == null)
            {
                return HttpNotFound();
            }
            ViewBag.INVESTIGATOR_ID = new SelectList(db.APP_VI_INVESTIGATORS, "INVESTIGATOR_ID", "FIRST_NAME", aPP_VI_INVESTIGA_INVESTIGATORS.INVESTIGATOR_ID);
            ViewBag.INVESTIGATION_ID = new SelectList(db.APP_VI_INVESTIGATIONS, "INVESTIGATION_ID", "NUNC", aPP_VI_INVESTIGA_INVESTIGATORS.INVESTIGATION_ID);
            return View(aPP_VI_INVESTIGA_INVESTIGATORS);
        }

        // POST: AppInvestigaInvestigators/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "INVESTIGATION_INVESTIGATOR_ID,INVESTIGATION_ID,INVESTIGATOR_ID,IS_ACTIVE")] APP_VI_INVESTIGA_INVESTIGATORS aPP_VI_INVESTIGA_INVESTIGATORS)
        {
            if (ModelState.IsValid)
            {
                db.Entry(aPP_VI_INVESTIGA_INVESTIGATORS).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.INVESTIGATOR_ID = new SelectList(db.APP_VI_INVESTIGATORS, "INVESTIGATOR_ID", "FIRST_NAME", aPP_VI_INVESTIGA_INVESTIGATORS.INVESTIGATOR_ID);
            ViewBag.INVESTIGATION_ID = new SelectList(db.APP_VI_INVESTIGATIONS, "INVESTIGATION_ID", "NUNC", aPP_VI_INVESTIGA_INVESTIGATORS.INVESTIGATION_ID);
            return View(aPP_VI_INVESTIGA_INVESTIGATORS);
        }

        // GET: AppInvestigaInvestigators/Delete/5
        public async Task<ActionResult> Delete(decimal id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            APP_VI_INVESTIGA_INVESTIGATORS aPP_VI_INVESTIGA_INVESTIGATORS = await db.APP_VI_INVESTIGA_INVESTIGATORS.FindAsync(id);
            if (aPP_VI_INVESTIGA_INVESTIGATORS == null)
            {
                return HttpNotFound();
            }
            return View(aPP_VI_INVESTIGA_INVESTIGATORS);
        }

        // POST: AppInvestigaInvestigators/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(decimal id)
        {
            APP_VI_INVESTIGA_INVESTIGATORS aPP_VI_INVESTIGA_INVESTIGATORS = await db.APP_VI_INVESTIGA_INVESTIGATORS.FindAsync(id);
            db.APP_VI_INVESTIGA_INVESTIGATORS.Remove(aPP_VI_INVESTIGA_INVESTIGATORS);
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
