using System.Net.Http.Headers;
using System.Text;
using Microsoft.AspNetCore.Mvc;
using SkiaSharp;
namespace image_api.Controllers;

[ApiController]
[Route("[controller]")]
public class WeatherForecastController : ControllerBase
{



  private static readonly string[] Summaries = new[]
  {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    };

  private readonly ILogger<WeatherForecastController> _logger;
  private readonly IWebHostEnvironment _env;

  public WeatherForecastController(ILogger<WeatherForecastController> logger, IWebHostEnvironment env)
  {
    _logger = logger;
    _env = env;
  }


  /// <summary>
  /// image test
  /// </summary>
  /// <returns>image test</returns>
  [HttpGet("get-image")]
  public IActionResult GetImage()
  {
    var filePath = Path.Combine(
        _env.ContentRootPath, "MyStaticFiles", "photo.png");

    /* use scale 
    using Stream stream = System.IO.File.OpenRead(filePath);
    using var bitmap = SKBitmap.Decode(stream);
    var targetBitmap = new SKBitmap(100, 100, true);
    bool isScaled = bitmap.ScalePixels(targetBitmap, SKFilterQuality.High);
    var resultStream = new MemoryStream();
    bool isEncoded = targetBitmap.Encode(resultStream, SKEncodedImageFormat.Png, 100);
    return new FileContentResult(resultStream.ToArray(), "image/png");
    */

    // use draw api
    using var stream = System.IO.File.OpenRead(filePath);
    using var bitmap = SKBitmap.Decode(stream);
    using var targetBitmap = new SKBitmap(500, 500, true);
    using (SKCanvas canvas = new SKCanvas(targetBitmap))
    {
      canvas.DrawBitmap(bitmap, new SKRect(-100, -100, 300, 300));
    }
    var resultStream = new MemoryStream();
    bool isEncoded = targetBitmap.Encode(resultStream, SKEncodedImageFormat.Png, 100);
    return new FileContentResult(resultStream.ToArray(), "image/png");
  }



  [HttpGet(Name = "GetWeatherForecast")]
  public IEnumerable<WeatherForecast> Get()
  {
    return Enumerable.Range(1, 5).Select(index => new WeatherForecast
    {
      Date = DateTime.Now.AddDays(index),
      TemperatureC = Random.Shared.Next(-20, 55),
      Summary = Summaries[Random.Shared.Next(Summaries.Length)]
    })
    .ToArray();
  }
}
