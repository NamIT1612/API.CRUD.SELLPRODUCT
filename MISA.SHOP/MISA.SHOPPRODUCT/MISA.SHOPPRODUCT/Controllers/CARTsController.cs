using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using MISA.SHOPPRODUCT.Models;

namespace MISA.SHOPPRODUCT.Controllers
{
    public class CARTsController : ApiController
    {
        private SHOP db = new SHOP();

        // GET: api/CARTs
        public IQueryable<CART> GetCARTs()
        {
            return db.CARTs;
        }

        // GET: api/CARTs/5
        [ResponseType(typeof(CART))]
        public IHttpActionResult GetCART(int id)
        {
            CART cART = db.CARTs.Find(id);
            if (cART == null)
            {
                return NotFound();
            }

            return Ok(cART);
        }

        // PUT: api/CARTs/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutCART(int id, CART cART)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != cART.ID)
            {
                return BadRequest();
            }

            db.Entry(cART).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CARTExists(id))
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

        // POST: api/CARTs
        [ResponseType(typeof(CART))]
        public IHttpActionResult PostCART(CART cART)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.CARTs.Add(cART);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (CARTExists(cART.ID))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = cART.ID }, cART);
        }

        // DELETE: api/CARTs/5
        [ResponseType(typeof(CART))]
        public IHttpActionResult DeleteCART(int id)
        {
            CART cART = db.CARTs.Find(id);
            if (cART == null)
            {
                return NotFound();
            }

            db.CARTs.Remove(cART);
            db.SaveChanges();

            return Ok(cART);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool CARTExists(int id)
        {
            return db.CARTs.Count(e => e.ID == id) > 0;
        }
    }
}