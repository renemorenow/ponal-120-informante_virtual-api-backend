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
    public class AppInformantsController : Controller
    {
        private EntitiesInformante db = new EntitiesInformante();

        // GET: AppInformants
        public async Task<ActionResult> Index()
        {
            return View(await db.APP_VI_INFORMANTS.ToListAsync());
        }

        // GET: AppInformants/Details/5
        public async Task<ActionResult> Details(decimal id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            APP_VI_INFORMANTS aPP_VI_INFORMANTS = await db.APP_VI_INFORMANTS.FindAsync(id);
            if (aPP_VI_INFORMANTS == null)
            {
                return HttpNotFound();
            }
            return View(aPP_VI_INFORMANTS);
        }

        // GET: AppInformants/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: AppInformants/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "INFORMANT_ID,FIRST_NAME,LAST_NAME,EMAIL,PHONE_NUMBER")] APP_VI_INFORMANTS aPP_VI_INFORMANTS)
        {
            if (ModelState.IsValid)
            {
                db.APP_VI_INFORMANTS.Add(aPP_VI_INFORMANTS);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(aPP_VI_INFORMANTS);
        }

        // GET: AppInformants/Edit/5
        public async Task<ActionResult> Edit(decimal id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            APP_VI_INFORMANTS aPP_VI_INFORMANTS = await db.APP_VI_INFORMANTS.FindAsync(id);
            if (aPP_VI_INFORMANTS == null)
            {
                return HttpNotFound();
            }
            return View(aPP_VI_INFORMANTS);
        }

        // POST: AppInformants/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "INFORMANT_ID,FIRST_NAME,LAST_NAME,EMAIL,PHONE_NUMBER")] APP_VI_INFORMANTS aPP_VI_INFORMANTS)
        {
            if (ModelState.IsValid)
            {
                db.Entry(aPP_VI_INFORMANTS).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(aPP_VI_INFORMANTS);
        }

        // GET: AppInformants/Delete/5
        public async Task<ActionResult> Delete(decimal id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            APP_VI_INFORMANTS aPP_VI_INFORMANTS = await db.APP_VI_INFORMANTS.FindAsync(id);
            if (aPP_VI_INFORMANTS == null)
            {
                return HttpNotFound();
            }
            return View(aPP_VI_INFORMANTS);
        }

        // POST: AppInformants/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(decimal id)
        {
            APP_VI_INFORMANTS aPP_VI_INFORMANTS = await db.APP_VI_INFORMANTS.FindAsync(id);
            db.APP_VI_INFORMANTS.Remove(aPP_VI_INFORMANTS);
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
