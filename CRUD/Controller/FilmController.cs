using Microsoft.AspNetCore.Mvc;

public class FilmController : Controller
{
    private static IList<Film> _films = new List<Film>
{
    new Film { Id = 1, Name = "Inception", Description = "A mind-bending thriller where dreams and reality collide.", Price = 12 },
    new Film { Id = 2, Name = "The Matrix", Description = "A hacker discovers a dystopian reality and joins a rebellion against machines.", Price = 10 },
    new Film { Id = 3, Name = "Interstellar", Description = "A journey across space to save humanity from extinction.", Price = 15 },
    new Film { Id = 4, Name = "The Godfather", Description = "A powerful mafia family struggles with power, betrayal, and family loyalty.", Price = 14 },
    new Film { Id = 5, Name = "Pulp Fiction", Description = "Interwoven tales of crime, humor, and redemption in Los Angeles.", Price = 9 },
    new Film { Id = 6, Name = "The Shawshank Redemption", Description = "The story of hope and friendship between two inmates.", Price = 11 },
    new Film { Id = 7, Name = "The Dark Knight", Description = "Batman battles the Joker to save Gotham City.", Price = 13 },
    new Film { Id = 8, Name = "Forrest Gump", Description = "The extraordinary journey of an ordinary man through decades of American history.", Price = 8 },
    new Film { Id = 9, Name = "Fight Club", Description = "An insomniac forms an underground club with an eccentric soap salesman.", Price = 10 }
};


    public IActionResult Index()
    {
        return View(_films);
    }

    public IActionResult Details(int id)
    {
        var selectedFilm = _films.FirstOrDefault(f => f.Id == id);
        return View(selectedFilm);
    }

    public IActionResult Create()
    {
        return View(new Film());
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Create(Film newFilm)
    {
        newFilm.Id = _films.Count + 1;
        _films.Add(newFilm);
        return RedirectToAction(nameof(Index));
    }

    public IActionResult Edit(int id)
    {
        var filmToEdit = _films.FirstOrDefault(f => f.Id == id);
        return View(filmToEdit);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Edit(int id, Film updatedFilm)
    {
        var existingFilm = _films.FirstOrDefault(f => f.Id == id);
        if (existingFilm != null)
        {
            existingFilm.Name = updatedFilm.Name;
            existingFilm.Description = updatedFilm.Description;
            existingFilm.Price = updatedFilm.Price;
        }
        return RedirectToAction(nameof(Index));
    }

    public IActionResult Delete(int id)
    {
        var filmToDelete = _films.FirstOrDefault(f => f.Id == id);
        return View(filmToDelete);
    }

    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public IActionResult ConfirmDelete(int id)
    {
        var filmToRemove = _films.FirstOrDefault(f => f.Id == id);
        if (filmToRemove != null)
        {
            _films.Remove(filmToRemove);
        }
        return RedirectToAction(nameof(Index));
    }
}
