using InvoiceAPIsample.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace InvoiceAPIsample.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InvoicesController : ControllerBase
    {
        private readonly InvoiceDbContext invoiceDbContext;

        public InvoicesController(InvoiceDbContext invoiceDbContext)
        {
            this.invoiceDbContext = invoiceDbContext;
        }

        [HttpGet]
        [Route("GetInvoices")]
        public List<Invoices> GetInvoices()
        {
            return invoiceDbContext.Invoices.ToList();
        }

        [HttpGet]
        [Route("GetInvoice")]
        public Invoices GetInvoice(int id)
        {
            return invoiceDbContext.Invoices.Where(x => x.Id == id).FirstOrDefault();
        }

        [HttpPost]
        [Route("AddInvoice")]
        public string AddUser(Invoices invoice)
        {
            string response = string.Empty;
            invoiceDbContext.Invoices.Add(invoice);
            invoiceDbContext.SaveChanges();
            return "Invoice Added.";
        }

        [HttpPut]
        [Route("UpdateInvoice")]
        public string UpdateInvoice(Invoices invoice)
        {
            invoiceDbContext.Entry(invoice).State = Microsoft.EntityFrameworkCore.EntityState.Modified; ;
            invoiceDbContext.SaveChanges();

            return "Invoice Updated.";

        }

        [HttpDelete]
        [Route("DeleteInvoice")]
        public string DeleteInvoice(int id)
        {
            Invoices invoice = invoiceDbContext.Invoices.Where(x => x.Id == id).FirstOrDefault();
            if (invoice == null)
            {


                invoiceDbContext.Invoices.Remove(invoice);
                invoiceDbContext.SaveChanges();

                return "Invoice Deleted.";
            }
            else
            {
                return "Invoice Not Found.";
            }
        }
    }
}
