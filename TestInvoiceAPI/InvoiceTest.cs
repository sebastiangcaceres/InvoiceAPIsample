using InvoiceAPIsample.Models;
using Microsoft.AspNetCore.Mvc.Testing;
using System.Text;
using System.Text.Json;

namespace TestInvoiceAPI
{
    public class InvoiceTest : IClassFixture<WebApplicationFactory<Program>>
    {
        private readonly WebApplicationFactory<Program> _factory;
        private HttpClient _httpClient;

        public InvoiceTest()
        {
            this._factory = new WebApplicationFactory<Program>();
            _httpClient = _factory.CreateDefaultClient();
        }

        [Fact]
        public async Task GetAllInvoices()
        {
            var response = await _httpClient.GetAsync("/Api/Invoices");
            var result = await response.Content.ReadAsStringAsync();
            
            response.EnsureSuccessStatusCode();
            Assert.True(!string.IsNullOrEmpty(result));
        }

        [Fact]
        public async Task InsertInvoice()
        {
            #region Invoice to Insert
            var newInvoice = new Invoices();
            newInvoice.Customer = "Juan Perez";
            newInvoice.Date = DateTime.Now;
            newInvoice.Currency = "EUR";
            newInvoice.Total = 10;
            var iLine = new InvoiceLines();
            iLine.Descripcion = "Product 1";
            iLine.Amount = 10;
            newInvoice.InvoiceLines.Add(iLine);
            #endregion

            var jInvoice = JsonSerializer.Serialize(newInvoice);
            var requestContent = new StringContent(jInvoice, Encoding.UTF8, "application/json");

            var response = await _httpClient.PostAsync("/Api/Invoices/AddInvoice", requestContent);
            var result = await response.Content.ReadAsStringAsync();

            response.EnsureSuccessStatusCode();
            Assert.True(!string.IsNullOrEmpty(result));
        }
    }
}