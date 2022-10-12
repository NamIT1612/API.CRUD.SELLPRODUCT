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
    public class PRODUCTsController : ApiController
    {
        private SHOP db = new SHOP();

         //GET: api/PRODUCTs
        [HttpGet]
        public IQueryable<PRODUCT> GetCLIENTs()
        {
            return db.PRODUCTs;
        }

        // GET: api/PRODUCTs/5
        [ResponseType(typeof(PRODUCT))]
        public IHttpActionResult GetPRODUCT(int id)
        {
            PRODUCT pRODUCT = db.PRODUCTs.Find(id);
            if (pRODUCT == null)
            {
                return NotFound();
            }

            return Ok(pRODUCT);
        }

        // PUT: api/PRODUCTs/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutPRODUCT(int id, PRODUCT pRODUCT)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != pRODUCT.IDPD)
            {
                return BadRequest();
            }

            db.Entry(pRODUCT).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PRODUCTExists(id))
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

        // POST: api/PRODUCTs
        [ResponseType(typeof(PRODUCT))]
        public IHttpActionResult PostPRODUCT(PRODUCT pRODUCT)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.PRODUCTs.Add(pRODUCT);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (PRODUCTExists(pRODUCT.IDPD))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = pRODUCT.IDPD }, pRODUCT);
        }

        // DELETE: api/PRODUCTs/5
        [ResponseType(typeof(PRODUCT))]
        public IHttpActionResult DeletePRODUCT(int id)
        {
            PRODUCT pRODUCT = db.PRODUCTs.Find(id);
            if (pRODUCT == null)
            {
                return NotFound();
            }

            db.PRODUCTs.Remove(pRODUCT);
            db.SaveChanges();

            return Ok(pRODUCT);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool PRODUCTExists(int id)
        {
            return db.PRODUCTs.Count(e => e.IDPD == id) > 0;
        }
    }
}