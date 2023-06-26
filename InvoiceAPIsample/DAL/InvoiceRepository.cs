using InvoiceAPIsample.Models;
using Microsoft.EntityFrameworkCore;

namespace InvoiceAPIsample.DAL
{
    public class InvoiceRepository: IInvoiceRepository,IDisposable
    {
        private InvoiceDbContext context;

        public InvoiceRepository(InvoiceDbContext context)
        {
            this.context= context;
        }

        void IInvoiceRepository.DeleteInvoice(int id)
        {
            Invoices invoice = context.Invoices.Find(id);
            context.Invoices.Remove(invoice);
        }

        List<Invoices> IInvoiceRepository.GetInvoices()
        {
            return context.Invoices.ToList();
        }

        Invoices IInvoiceRepository.GetInvoiceById(int id)
        {
            return context.Invoices.Where(x => x.Id == id).Include(b => b.InvoiceLines).FirstOrDefault();
        }

        void IInvoiceRepository.InsertInvoice(Invoices invoice)
        {
            context.Invoices.Add(invoice);
        }

        void IInvoiceRepository.Save()
        {
            context.SaveChanges();
        }

        void IInvoiceRepository.UpdateInvoice(Invoices invoice)
        {
            context.Entry(invoice).State = EntityState.Modified;
        }

        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    context.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
