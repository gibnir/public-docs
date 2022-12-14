using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebAPI.Models;

namespace WebAPI.Controllers
{
    // [EnableCors("CorsPolicy")]
    [Route("api/[controller]")]
    [EnableCors]
    [ApiController]
    public class PaymentDetailController : ControllerBase
    {
        // readonly Can change only in the constractor 
        private readonly PaymentDetailsContext _context;

        public PaymentDetailController(PaymentDetailsContext context)
        {
            _context = context;
        }

        // GET: api/PaymentDetail
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PaymentDetail>>>  GetPaymentDetails()
        {
            return await _context.PaymentDetails.ToListAsync();
        }

        // GET: api/PaymentDetail/5
        [HttpGet("{id}")]
        public async Task<ActionResult<PaymentDetail>> GetPaymentDetail(int id)
        {
            var paymentDetail = await _context.PaymentDetails.FindAsync(id);

            if (paymentDetail == null)
            {
                return NotFound();
            }

            return paymentDetail;
        }
        
        // PUT: api/PaymentDetail/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPaymentDetail(int id, PaymentDetail paymentDetail)
        {
            if (id != paymentDetail.PMId)
            {
                return BadRequest();
            }

            _context.Entry(paymentDetail).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PaymentDetailExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/PaymentDetail
        // [EnableCors("CorsPolicy")]
        [EnableCors]
        [HttpPost]
        public async Task<ActionResult<PaymentDetail>> PostPaymentDetail(PaymentDetail paymentDetail)
        {


            _context.PaymentDetails.Add(paymentDetail);
            await _context.SaveChangesAsync();

            return CreatedAtAction(
                "GetPaymentDetail",
                new { id = paymentDetail.PMId },
                paymentDetail);
        }

        // DELETE: api/PaymentDetail/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<PaymentDetail>> DeletePaymentDetail(int id)
        {
            var paymentDetail = await _context.PaymentDetails.FindAsync(id);
            if (paymentDetail == null)
            {
                return NotFound();
            }

            _context.PaymentDetails.Remove(paymentDetail);
            await _context.SaveChangesAsync();

            return paymentDetail;
        }

        private bool PaymentDetailExists(int id)
        {
            return _context.PaymentDetails.Any(e => e.PMId == id);
        }
    }
}

/*
        // GET: api/PaymentDetail
        [HttpGet]
        public IEnumerable<PaymentDetail> GetPaymentDetails()
        {
            return _context.PaymentDetails;
        }
        */
/*
// GET: api/PaymentDetail/5
[HttpGet("{id}")]
public async Task<IActionResult> GetPaymentDetail([FromRoute] int id)
{
    if (!ModelState.IsValid)
    {
        return BadRequest(ModelState);
    }

    var paymentDetail = await _context.PaymentDetails.FindAsync(id);

    if (paymentDetail == null)
    {
        return NotFound();
    }

    return Ok(paymentDetail);
}
*/
/*
// PUT: api/PaymentDetail/5
[HttpPut("{id}")]
public async Task<IActionResult> PutPaymentDetail([FromRoute] int id, [FromBody] PaymentDetail paymentDetail)
{
    if (!ModelState.IsValid)
    {
        return BadRequest(ModelState);
    }

    if (id != paymentDetail.PMId)
    {
        return BadRequest();
    }

    _context.Entry(paymentDetail).State = EntityState.Modified;

    try
    {
        await _context.SaveChangesAsync();
    }
    catch (DbUpdateConcurrencyException)
    {
        if (!PaymentDetailExists(id))
        {
            return NotFound();
        }
        else
        {
            throw;
        }
    }

    return NoContent();
}
*/