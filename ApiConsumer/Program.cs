using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace ApiConsumer
{
    class Program
    {
        static async Task Main(string[] args)
        {
            using HttpClient client = new HttpClient();

            // ====== API KEY (si tu API la usa) ======
            // Si tu API usa "Bearer":
            client.DefaultRequestHeaders.Add("Authorization", "b9b5cdd9-9230-40a8-9a93-567b0134d4c8");

            // Si tu API usa "X-API-Key", usa este en cambio:
            // client.DefaultRequestHeaders.Add("X-API-Key", "TU_API_KEY");

            // ====== Headers básicos ======
            client.DefaultRequestHeaders.Add("User-Agent", "C# Console App");
            client.DefaultRequestHeaders.Add("Accept", "application/json");

            // ====== URL DE TU API ======
            string url = "https://api.telepatia.ai/api/public-docs#/Public%20API%20-%20Institutionals%20V1/PublicApiInstitutionalsController_listDoctors";

            try
            {
                var response = await client.GetAsync(url);

                // Lanza excepción si falla
                response.EnsureSuccessStatusCode();

                string result = await response.Content.ReadAsStringAsync();

                Console.WriteLine("Respuesta del servidor:");
                Console.WriteLine(result);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error:");
                Console.WriteLine(ex.Message);
            }
        }
    }
}
