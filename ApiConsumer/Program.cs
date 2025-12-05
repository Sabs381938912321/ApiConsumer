using System;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

// Este programa consume una API REST completamente
// Puedes ejecutar GET, POST, PUT y DELETE

class Program
{
    static async Task Main(string[] args)
    {
        // Cambia esta URL si quieres consumir tu API
        string baseUrl = "https://api.telepatia.ai/api/public-docs#/";

        using var client = new HttpClient();
        client.BaseAddress = new Uri(baseUrl);

        Console.WriteLine("=== Programa que consume una API ===\n");

        // ========================
        //         GET
        // ========================
        Console.WriteLine("🔵 GET /posts/1\n");

        var dato = await client.GetFromJsonAsync<Post>("posts/1");
        Console.WriteLine($"ID: {dato.Id}");
        Console.WriteLine($"Título: {dato.Title}");
        Console.WriteLine($"Contenido: {dato.Body}\n");

        // ========================
        //         POST
        // ========================
        Console.WriteLine("🟢 POST /posts\n");

        var nuevoPost = new Post
        {
            UserId = 99,
            Title = "Título creado desde C#",
            Body = "Mensaje enviado al servidor"
        };

        var postResponse = await client.PostAsJsonAsync("posts", nuevoPost);
        var creado = await postResponse.Content.ReadFromJsonAsync<Post>();

        Console.WriteLine($"Creado ID: {creado.Id}");
        Console.WriteLine($"Título: {creado.Title}\n");

        // ========================
        //         PUT
        // ========================
        Console.WriteLine("🟡 PUT /posts/1\n");

        var actualizar = new Post
        {
            Id = 1,
            UserId = 1,
            Title = "Título actualizado",
            Body = "Contenido actualizado"
        };

        var putResponse = await client.PutAsJsonAsync("posts/1", actualizar);
        Console.WriteLine($"PUT Status: {putResponse.StatusCode}\n");

        // ========================
        //       DELETE
        // ========================
        Console.WriteLine("🔴 DELETE /posts/1\n");

        var deleteResponse = await client.DeleteAsync("posts/1");
        Console.WriteLine($"DELETE Status: {deleteResponse.StatusCode}\n");

        Console.WriteLine("=== FIN DEL PROGRAMA ===");
    }
}

// Modelo para mapear la respuesta de la API
public class Post
{
    public int UserId { get; set; }
    public int Id { get; set; }
    public string Title { get; set; }
    public string Body { get; set; }
}
