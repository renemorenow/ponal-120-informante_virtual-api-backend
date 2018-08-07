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
    public class AppInvestigatorsController : Controller
    {
        private EntitiesInformante db = new EntitiesInformante();

        // GET: AppInvestigators
        public async Task<ActionResult> Index()
        {
            return View(await db.APP_VI_INVESTIGATORS.ToListAsync());
        }

        // GET: AppInvestigators/Details/5
        public async Task<ActionResult> Details(decimal id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            APP_VI_INVESTIGATORS aPP_VI_INVESTIGATORS = await db.APP_VI_INVESTIGATORS.FindAsync(id);
            if (aPP_VI_INVESTIGATORS == null)
            {
                return HttpNotFound();
            }
            return View(aPP_VI_INVESTIGATORS);
        }

        // GET: AppInvestigators/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: AppInvestigators/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "INVESTIGATOR_ID,FIRST_NAME,LAST_NAME,INSTITUTION")] APP_VI_INVESTIGATORS aPP_VI_INVESTIGATORS)
        {
            if (ModelState.IsValid)
            {
                db.APP_VI_INVESTIGATORS.Add(aPP_VI_INVESTIGATORS);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(aPP_VI_INVESTIGATORS);
        }

        // GET: AppInvestigators/Edit/5
        public async Task<ActionResult> Edit(decimal id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            APP_VI_INVESTIGATORS aPP_VI_INVESTIGATORS = await db.APP_VI_INVESTIGATORS.FindAsync(id);
            if (aPP_VI_INVESTIGATORS == null)
            {
                return HttpNotFound();
            }
            return View(aPP_VI_INVESTIGATORS);
        }

        // POST: AppInvestigators/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "INVESTIGATOR_ID,FIRST_NAME,LAST_NAME,INSTITUTION")] APP_VI_INVESTIGATORS aPP_VI_INVESTIGATORS)
        {
            if (ModelState.IsValid)
            {
                db.Entry(aPP_VI_INVESTIGATORS).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(aPP_VI_INVESTIGATORS);
        }

        // GET: AppInvestigators/Delete/5
        public async Task<ActionResult> Delete(decimal id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            APP_VI_INVESTIGATORS aPP_VI_INVESTIGATORS = await db.APP_VI_INVESTIGATORS.FindAsync(id);
            if (aPP_VI_INVESTIGATORS == null)
            {
                return HttpNotFound();
            }
            return View(aPP_VI_INVESTIGATORS);
        }

        // POST: AppInvestigators/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(decimal id)
        {
            APP_VI_INVESTIGATORS aPP_VI_INVESTIGATORS = await db.APP_VI_INVESTIGATORS.FindAsync(id);
            db.APP_VI_INVESTIGATORS.Remove(aPP_VI_INVESTIGATORS);
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
