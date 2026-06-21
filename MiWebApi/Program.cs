using System;
using System.Collections.Generic;
using System.Net.Http;
using System.IO;
using System.Text.Json;
using System.Threading.Tasks;
using EspacioChiste;

HttpClient client = new HttpClient();
await GetChiste();

async Task GetChiste()
{
    string url = "https://official-joke-api.appspot.com/jokes/programming/ten";
    HttpResponseMessage response = await client.GetAsync(url);
    response.EnsureSuccessStatusCode();
    string responseBody = await response.Content.ReadAsStringAsync();
    List<Chiste> listChistes = JsonSerializer.Deserialize<List<Chiste>>(responseBody);
    Console.WriteLine("Lista de chistes:");
    foreach (Chiste chiste in listChistes)
    {
        Console.WriteLine("Pregunta: " + chiste.setup);
        Console.WriteLine("Respuesta: " + chiste.punchline);
        Console.WriteLine("----------------------------------------");
    }
    string jsonString = JsonSerializer.Serialize(listChistes);
    File.WriteAllText("tareas.json", jsonString);
}
