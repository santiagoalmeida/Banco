using Banco.Web.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.WebUtilities;
using System.Net;
using System.Text;
using System.Text.Json;

namespace Banco.Web.Services
{
    public class Services<TEntity> : IServices<TEntity> where TEntity : class
    {
        private readonly HttpClient _httpClient;
        private readonly string _remoteServiceBaseUrl;

        public Services(HttpClient httpClient)
        {
            _httpClient = httpClient;
            _remoteServiceBaseUrl = _httpClient.BaseAddress.ToString();
        }

        public async Task DeleteAsync(int Id)
        {
            await _httpClient.DeleteAsync(_remoteServiceBaseUrl + Id);
        }

        public async Task<IEnumerable<TEntity>> GetAsync()
        {
            var responseString = await _httpClient.GetStringAsync(_remoteServiceBaseUrl);

            IEnumerable<TEntity> entity = JsonSerializer.Deserialize<IEnumerable<TEntity>>(responseString.ToString());
            return entity;
        }

        public async Task<TEntity> GetAsync(int Id)
        {
            var responseString = await _httpClient.GetStringAsync(_remoteServiceBaseUrl + Id);

            TEntity entity = JsonSerializer.Deserialize<TEntity>(responseString.ToString());
            return entity;
        }

        public async Task PostAsync(TEntity entity)
        {
            try
            {
                StringContent strJson = new StringContent(JsonSerializer.Serialize<TEntity>(entity), Encoding.UTF8, "application/json");
                var resp = await _httpClient.PostAsync(_remoteServiceBaseUrl, strJson);
                if (resp.StatusCode == HttpStatusCode.BadRequest)
                {

                    throw new System.Exception(resp.Content.ReadAsStringAsync().Result);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task PutAsync(TEntity entity)
        {
            StringContent strJson = new StringContent(System.Text.Json.JsonSerializer.Serialize<TEntity>(entity), Encoding.UTF8, "application/json");
            var resp = await _httpClient.PutAsync(_remoteServiceBaseUrl, strJson);
        }

        public async Task<IEnumerable<ConsultaMovimientos>> GetReporteMovimientosAsync(ParamsConsultaMovimientos paramsConsulta)
        {
            var urlConsulta = _remoteServiceBaseUrl + "Reportes/";
            var resp = await _httpClient.PostAsJsonAsync(urlConsulta, paramsConsulta);
            if (resp.StatusCode == HttpStatusCode.OK)
            {
                IEnumerable<ConsultaMovimientos> entity = JsonSerializer.Deserialize<IEnumerable<ConsultaMovimientos>>(resp.Content.ReadAsStringAsync().Result);
                return entity;
            }
            else
            {
                throw new System.Exception(resp.Content.ReadAsStringAsync().Result);
            }
        }
    }
}
