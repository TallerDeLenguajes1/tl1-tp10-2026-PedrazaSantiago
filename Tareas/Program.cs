using System;
using System.Collections.Generic;
using System.Net.Http;
using System.IO;
using System.Text.Json;
using System.Threading.Tasks;
using EspacioTarea;

HttpClient client = new HttpClient();
await GetTarea();

async Task GetTarea()
{
    string url = "https://jsonplaceholder.typicode.com/todos/";
    HttpResponseMessage response = await client.GetAsync(url);
    response.EnsureSuccessStatusCode();
    string responseBody = await response.Content.ReadAsStringAsync();
    List<Tarea> listTareas = JsonSerializer.Deserialize<List<Tarea>>(responseBody);
    Console.WriteLine("TAREAS PENDIENTES:");
    foreach (Tarea tarea in listTareas)
    {
        if (!tarea.completed)
        {
            Console.WriteLine("Nombre:"+tarea.title+ "| Estado:pendiente");
        }
    }
        Console.WriteLine("TAREAS COMPLETADAS:");
    foreach (Tarea tarea in listTareas)
    {
        if (tarea.completed)
        {
            Console.WriteLine("Nombre:"+tarea.title+ "| Estado:completada");
        }
    }
    string jsonString = JsonSerializer.Serialize(listTareas);
    File.WriteAllText("tareas.json", jsonString);
}