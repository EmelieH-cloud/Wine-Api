namespace Wine_Api.Controllers;
using Microsoft.AspNetCore.Mvc;
using Wine_Api.Models;

[ApiController]
/* [ApiController]: Markerar klassen som en API-controller och ger den några förinställda beteenden för API:er*/

[Route("[controller]")]
/* [Route("[controller]")]: Anger att routen för denna controller kommer att vara "/Wine", där "Wine" härleds
 från namnet på controllerklassen. */

public class WineController : ControllerBase
{
    public static List<Wine> Wines { get; set; } = new List<Wine>
{
    new Wine { Id = 1, Name = "Chateau Margaux", Year = 2010, Color = "Red", Description = "Elegant and full-bodied." },
    new Wine { Id = 2, Name = "Domaine de la Romanee-Conti", Year = 2005, Color = "Red", Description = "Complex and velvety." },
    new Wine { Id = 3, Name = "Opus One", Year = 2012, Color = "Red", Description = "Harmonious blend with rich flavors." },
    new Wine { Id = 4, Name = "Cloudy Bay Sauvignon Blanc", Year = 2019, Color = "White", Description = "Crisp and refreshing." },
    new Wine { Id = 5, Name = "Barolo Riserva", Year = 2013, Color = "Red", Description = "Robust with a long finish." },
    new Wine { Id = 6, Name = "Rombauer Vineyards Chardonnay", Year = 2018, Color = "White", Description = "Buttery and smooth." },
    new Wine { Id = 7, Name = "Silver Oak Cabernet Sauvignon", Year = 2015, Color = "Red", Description = "Velvety texture with rich fruit." },
    new Wine { Id = 8, Name = "Sancerre", Year = 2020, Color = "White", Description = "Crisp acidity with citrus notes." },
    new Wine { Id = 9, Name = "Rioja Reserva", Year = 2014, Color = "Red", Description = "Smooth and well-balanced." },
    new Wine { Id = 10, Name = "Prosecco", Year = 2018, Color = "Sparkling", Description = "Light and effervescent." },
    new Wine { Id = 11, Name = "Malbec", Year = 2017, Color = "Red", Description = "Bold and fruity." },
    new Wine { Id = 12, Name = "Chardonnay", Year = 2019, Color = "White", Description = "Fresh and lively." },
    new Wine { Id = 13, Name = "Cabernet Franc", Year = 2016, Color = "Red", Description = "Herbaceous with dark fruit." },
    new Wine { Id = 14, Name = "Gewürztraminer", Year = 2018, Color = "White", Description = "Aromatic and floral." },
    new Wine { Id = 15, Name = "Zinfandel", Year = 2015, Color = "Red", Description = "Spicy and bold." },
    new Wine { Id = 16, Name = "Pinot Grigio", Year = 2021, Color = "White", Description = "Crisp and citrusy." },
    new Wine { Id = 17, Name = "Merlot", Year = 2014, Color = "Red", Description = "Soft and approachable." },
    new Wine { Id = 18, Name = "Champagne Brut", Year = 2017, Color = "Sparkling", Description = "Toasty and celebratory." },
    new Wine { Id = 19, Name = "Syrah/Shiraz", Year = 2017, Color = "Red", Description = "Full-bodied with dark fruit." },
    new Wine { Id = 20, Name = "Sauvignon Blanc", Year = 2020, Color = "White", Description = "Zesty and herbaceous." }
};

    // GET-metod: hämta alla viner
    [HttpGet]
    public ActionResult<List<Wine>> Get()
    {
        if (Wines != null && Wines.Any())
        {
            // success 
            return Ok(Wines);
        }

        // fail 
        return NotFound("Could not find wines");
    }

    // GET-metod: hämta ett specifikt vin 
    [HttpGet]
    [Route("{id}")]
    public ActionResult<Wine> Get(int id)
    {
        Wine? wine = Wines.FirstOrDefault(w => w.Id == id);

        if (wine == null)
        {
            // fail
            return NotFound("Could not find a wine with that ID");
        }

        // success 
        return Ok(wine);
    }


    [HttpPost]
    // POST-metod: lägg till ett nytt vin i "databasen" 
    public ActionResult Post(Wine? wine)
    {
        if (wine == null || string.IsNullOrEmpty(wine.Name))
        {
            return BadRequest("Could not add wine.");
        }
        else
        {
            Wines.Add(wine);

            return Ok("Wine added!");
        }

    }

    [HttpPut("{id}")]
    // PUT-metod: låt användaren uppdatera ett befintligt vin. 
    public ActionResult Put(int id, [FromBody] Wine updatedWine)
    // [FromBody] betyder att input från användaren ska tolkas som en in-parameter i metoden. 
    {
        // Finns det ett vin med detta id?... 
        var existingWine = Wines.FirstOrDefault(w => w.Id == id);

        // fail - vinet finns inte  
        if (existingWine == null)
        {
            return NotFound($"Wine with ID {id} not found");
        }

        // Success - uppdatera vinet 
        existingWine.Name = updatedWine.Name;
        existingWine.Color = updatedWine.Color;
        existingWine.Year = updatedWine.Year;
        existingWine.Description = updatedWine.Description;

        return Ok(existingWine);
    }

    [HttpDelete("{id}")]
    // DELETE-metod: låt användaren ta bort ett befintligt vin.
    public ActionResult Delete(int id)
    {
        // Finns det ett vin med detta id?...
        var existingWine = Wines.FirstOrDefault(w => w.Id == id);

        // fail - vinet finns inte
        if (existingWine == null)
        {
            return NotFound($"Wine with ID {id} not found");
        }

        // Success - ta bort vinet
        Wines.Remove(existingWine);

        return Ok($"Wine with ID {id} has been deleted");
    }
}




