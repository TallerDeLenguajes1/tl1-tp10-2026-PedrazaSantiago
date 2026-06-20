using System;
using System.Collections.Generic;
using System.Net.Http;
using System.IO;
using System.Text.Json;
using System.Threading.Tasks;
using EspacioUsuario;

HttpClient client = new HttpClient();
await GetUsuario();

async Task GetUsuario()
{
    string url = "https://jsonplaceholder.typicode.com/users";
    HttpResponseMessage response = await client.GetAsync(url);
    response.EnsureSuccessStatusCode();
    string responseBody = await response.Content.ReadAsStringAsync();
    List<Usuario> listUsuarios = JsonSerializer.Deserialize<List<Usuario>>(responseBody);
    Console.WriteLine("Datos de los primeros 5 usuarios:");
    for (int i = 0; i<5;i++)
    {
            Console.WriteLine("Nombre:"+listUsuarios[i].name+ "| Correo electronico:"+listUsuarios[i].email+"| Domicilio:"+listUsuarios[i].address.city);
    }
    string jsonString = JsonSerializer.Serialize(listUsuarios);
    File.WriteAllText("usuarios.json", jsonString);
}
