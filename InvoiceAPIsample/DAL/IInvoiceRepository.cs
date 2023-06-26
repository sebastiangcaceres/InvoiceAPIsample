using InvoiceAPIsample.Models;

namespace InvoiceAPIsample.DAL
{
    public interface IInvoiceRepository : IDisposable
    {
        List<Invoices> GetInvoices();
        Invoices GetInvoiceById(int id);
        void InsertInvoice(Invoices invoice);
        void DeleteInvoice(int id);
        void UpdateInvoice(Invoices invoice);
        void Save();
    }
}
