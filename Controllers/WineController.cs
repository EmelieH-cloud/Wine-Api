namespace Wine_Api.Controllers;
using Microsoft.AspNetCore.Mvc;
using Wine_Api.Models;

[ApiController]
/* [ApiController]: Markerar klassen som en API-kontroller och ger den några förinställda konventioner för beteende. */

[Route("[controller]")]
/* [Route("[controller]")]: Anger att routen för denna controller kommer att vara "/Wine", där "Wine" härleds
 från namnet på controllerklassen. */

public class WineController : ControllerBase
{
    public static List<Wine> Wines { get; set; } = new List<Wine>
    {
        new Wine { Name = "Chateau Margaux", Year = 2010, Color = "Red", Description = "Elegant and full-bodied." },
        new Wine { Name = "Domaine de la Romanee-Conti", Year = 2005, Color = "Red", Description = "Complex and velvety." },
        new Wine { Name = "Opus One", Year = 2012, Color = "Red", Description = "Harmonious blend with rich flavors." },
        new Wine { Name = "Cloudy Bay Sauvignon Blanc", Year = 2019, Color = "White", Description = "Crisp and refreshing." },
        new Wine { Name = "Barolo Riserva", Year = 2013, Color = "Red", Description = "Robust with a long finish." },
        new Wine { Name = "Rombauer Vineyards Chardonnay", Year = 2018, Color = "White", Description = "Buttery and smooth." },
        new Wine { Name = "Silver Oak Cabernet Sauvignon", Year = 2015, Color = "Red", Description = "Velvety texture with rich fruit." },
        new Wine { Name = "Sancerre", Year = 2020, Color = "White", Description = "Crisp acidity with citrus notes." },
        new Wine { Name = "Rioja Reserva", Year = 2014, Color = "Red", Description = "Smooth and well-balanced." },
        new Wine { Name = "Prosecco", Year = 2018, Color = "Sparkling", Description = "Light and effervescent." },
        new Wine { Name = "Malbec", Year = 2017, Color = "Red", Description = "Bold and fruity." },
        new Wine { Name = "Chardonnay", Year = 2019, Color = "White", Description = "Fresh and lively." },
        new Wine { Name = "Cabernet Franc", Year = 2016, Color = "Red", Description = "Herbaceous with dark fruit." },
        new Wine { Name = "Gewürztraminer", Year = 2018, Color = "White", Description = "Aromatic and floral." },
        new Wine { Name = "Zinfandel", Year = 2015, Color = "Red", Description = "Spicy and bold." },
        new Wine { Name = "Pinot Grigio", Year = 2021, Color = "White", Description = "Crisp and citrusy." },
        new Wine { Name = "Merlot", Year = 2014, Color = "Red", Description = "Soft and approachable." },
        new Wine { Name = "Champagne Brut", Year = 2017, Color = "Sparkling", Description = "Toasty and celebratory." },
        new Wine { Name = "Syrah/Shiraz", Year = 2017, Color = "Red", Description = "Full-bodied with dark fruit." },
        new Wine { Name = "Sauvignon Blanc", Year = 2020, Color = "White", Description = "Zesty and herbaceous." }
    };

    // GET-metod: hämta alla viner
    [HttpGet]
    public ActionResult<List<Wine>> Get()
    {
        if (Wines != null && Wines.Any())
        {
            return Ok(Wines);
            // Returnera ett actionresult (OK) + vinlistan 
        }

        return NotFound("Could not find wines");
        // Returnera NotFound-objektet. 
    }

    // GET-metod: hämta ett specifikt vin 
    [HttpGet]
    [Route("{id}")]
    public ActionResult<Wine> Get(int id)
    {
        Wine? wine = Wines.FirstOrDefault(w => w.Id == id);

        if (wine == null)
        {
            return NotFound("Could not find a wine with that ID");
        }

        // Returnera ett actionresult (OK) + vinet 
        return Ok(wine); // 
    }

}
