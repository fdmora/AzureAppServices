using System.Collections.Generic;
using System.IO;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using ListadoPaisesAPI.Models;

[ApiController]
[Route("[controller]")]
public class PaisesController : ControllerBase
{
    [HttpGet]
    public IActionResult GetPaises()
    {
        var filePath = Path.Combine(Directory.GetCurrentDirectory(), "Data", "paises.json");
        var jsonContent = System.IO.File.ReadAllText(filePath);
        var paises = JsonConvert.DeserializeObject<List<Pais>>(jsonContent);
        return Ok(paises);
    }
}
