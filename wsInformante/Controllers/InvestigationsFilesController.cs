using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using wsInformante.Models;

namespace wsInformante.Controllers
{
    public class InvestigationsFilesController : ApiController
    {
        private EntitiesInformante db = new EntitiesInformante();

        // GET: api/InvestigationsFiles
        public IQueryable<APP_VI_INVESTIGATION_FILES> GetAPP_VI_INVESTIGATION_FILES()
        {
            return db.APP_VI_INVESTIGATION_FILES;
        }

        // GET: api/InvestigationsFiles/5
        [ResponseType(typeof(APP_VI_INVESTIGATION_FILES))]
        public async Task<IHttpActionResult> GetAPP_VI_INVESTIGATION_FILES(decimal id)
        {
            APP_VI_INVESTIGATION_FILES aPP_VI_INVESTIGATION_FILES = await db.APP_VI_INVESTIGATION_FILES.FindAsync(id);
            if (aPP_VI_INVESTIGATION_FILES == null)
            {
                return NotFound();
            }

            return Ok(aPP_VI_INVESTIGATION_FILES);
        }

        // PUT: api/InvestigationsFiles/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutAPP_VI_INVESTIGATION_FILES(decimal id, APP_VI_INVESTIGATION_FILES aPP_VI_INVESTIGATION_FILES)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != aPP_VI_INVESTIGATION_FILES.INVESTIGATION_FILE_ID)
            {
                return BadRequest();
            }

            db.Entry(aPP_VI_INVESTIGATION_FILES).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!APP_VI_INVESTIGATION_FILESExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/InvestigationsFiles
        [ResponseType(typeof(APP_VI_INVESTIGATION_FILES))]
        public async Task<IHttpActionResult> PostAPP_VI_INVESTIGATION_FILES(APP_VI_INVESTIGATION_FILES aPP_VI_INVESTIGATION_FILES)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.APP_VI_INVESTIGATION_FILES.Add(aPP_VI_INVESTIGATION_FILES);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = aPP_VI_INVESTIGATION_FILES.INVESTIGATION_FILE_ID }, aPP_VI_INVESTIGATION_FILES);
        }

        // DELETE: api/InvestigationsFiles/5
        [ResponseType(typeof(APP_VI_INVESTIGATION_FILES))]
        public async Task<IHttpActionResult> DeleteAPP_VI_INVESTIGATION_FILES(decimal id)
        {
            APP_VI_INVESTIGATION_FILES aPP_VI_INVESTIGATION_FILES = await db.APP_VI_INVESTIGATION_FILES.FindAsync(id);
            if (aPP_VI_INVESTIGATION_FILES == null)
            {
                return NotFound();
            }

            db.APP_VI_INVESTIGATION_FILES.Remove(aPP_VI_INVESTIGATION_FILES);
            await db.SaveChangesAsync();

            return Ok(aPP_VI_INVESTIGATION_FILES);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool APP_VI_INVESTIGATION_FILESExists(decimal id)
        {
            return db.APP_VI_INVESTIGATION_FILES.Count(e => e.INVESTIGATION_FILE_ID == id) > 0;
        }
    }
}