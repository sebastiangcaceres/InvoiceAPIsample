using InvoiceAPIsample.DAL;
using InvoiceAPIsample.Models;
using InvoiceAPIsample.Validators;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace InvoiceAPIsample.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InvoicesController : ControllerBase
    {
        private IInvoiceRepository invoiceRepository;

        public InvoicesController(InvoiceDbContext invoiceDbContext)
        {
            this.invoiceRepository= new InvoiceRepository(invoiceDbContext);
        }

        [HttpGet]
        [Route("")]
        public ActionResult<List<Invoices>> GetInvoices()
        {
            var invoices = invoiceRepository.GetInvoices();
            if (invoices == null)
            {
                return NotFound();
            }
            return invoices;
        }

        [HttpGet] 
        [Route("GetInvoice")]
        public ActionResult<Invoices> GetInvoice(int id)
        {
            var invoice = invoiceRepository.GetInvoiceById(id);
            if (invoice == null)
            {
                return NotFound();
            }
            return invoice;
        }

        [HttpPost]
        [Route("AddInvoice")]
        public ActionResult<Invoices> AddInvoice(Invoices invoice)
        {
            string response = string.Empty;

            var invoiceValidator = new InvoiceValidator();
            var result = invoiceValidator.Validate(invoice);
            if (result.IsValid)
            {
                invoiceRepository.InsertInvoice(invoice);
                invoiceRepository.Save();
                //invoiceDbContext.Invoices.Add(invoice);
                //invoiceDbContext.SaveChanges();
                return CreatedAtAction(nameof(GetInvoice), new { id = invoice.Id }, invoice);
            }

            var errorMessages = result.Errors.Select(x => x.ErrorMessage).ToList();
            return BadRequest(errorMessages);         
        }
        /// <summary>
        /// Return if an invoice id Exists
        /// </summary>
        /// <param name="id">invoice id</param>
        /// <returns>true or false</returns>
        private bool InvoiceExists(int id)
        {
            ActionResult<Invoices> result = this.GetInvoice(id);

            if (result.Value==null)
            {
                return false;
            }
            return true;
        }

        [HttpPut] //[HttpPut("{id}")]
        [Route("UpdateInvoice")]
        public IActionResult UpdateInvoice(Invoices invoice)
        {
            var invoiceValidator = new InvoiceValidator();
            var result = invoiceValidator.Validate(invoice);
            if (result.IsValid)
            {
                invoiceRepository.UpdateInvoice(invoice);
                try
                {
                    invoiceRepository.Save();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!InvoiceExists(invoice.Id))
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
            var errorMessages = result.Errors.Select(x => x.ErrorMessage).ToList();
            return BadRequest(errorMessages);
        }

        [HttpDelete]
        [Route("DeleteInvoice")]
        public IActionResult DeleteInvoice(int id)
        {
            Invoices invoice = invoiceRepository.GetInvoiceById(id);
            if (invoice == null)
            {
                return NotFound();
            }
            invoiceRepository.DeleteInvoice(id);
            invoiceRepository.Save();

            return NoContent();
        }
    }
}
