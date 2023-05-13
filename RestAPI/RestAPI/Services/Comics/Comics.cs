using RestAPI.Models.DTO;

namespace RestAPI.Services.Comics
{
    public class Comics : IComics
    {
        static private List<ComicDTO> _comics;
        public Comics()
        {
            _comics = new List<ComicDTO>
            {
                new ComicDTO { Title = "The Sandman", Author = "Neil Gaiman", Language = "English", Verse = "Vertigo" },
                new ComicDTO { Title = "Watchmen", Author = "Alan Moore", Language = "English", Verse = "DC Comics" },
                new ComicDTO { Title = "V for Vendetta", Author = "Alan Moore", Language = "English", Verse = "Vertigo" },
                new ComicDTO { Title = "Batman: Year One", Author = "Frank Miller", Language = "English", Verse = "DC Comics" },
                new ComicDTO { Title = "Saga", Author = "Brian K. Vaughan", Language = "English", Verse = "Image Comics" },
                new ComicDTO { Title = "The Walking Dead", Author = "Robert Kirkman", Language = "English", Verse = "Image Comics" },
                new ComicDTO { Title = "Preacher", Author = "Garth Ennis", Language = "English", Verse = "Vertigo" },
                new ComicDTO { Title = "Fables", Author = "Bill Willingham", Language = "English", Verse = "Vertigo" },
                new ComicDTO { Title = "Maus", Author = "Art Spiegelman", Language = "English", Verse = "Pantheon Books" },
                new ComicDTO { Title = "Sin City", Author = "Frank Miller", Language = "English", Verse = "Dark Horse Comics" }
            };
        }

        public async Task<T?> GetAsync<T>(object? param)
        {
            try
            {
                if (param == null)
                {
                    var result = _comics;
                    return await Task.FromResult(result != null ? (T)(object)result : default(T));
                }
                else
                {
                    var result = _comics.Where(c => c.Title.Replace(" ", "").Equals(param)).FirstOrDefault();
                    return await Task.FromResult(result != null ? (T)(object)result : default(T));
                }
            }
            catch
            {
                throw new NewException("Something gone wrong");
            }
        }

        public async Task<T?> PostAsync<T>(object param)
        {
            try
            {
                var newComic = (ComicDTO)Convert.ChangeType(param, typeof(ComicDTO));
                _comics.Add(newComic);
                return await Task.FromResult((T)Convert.ChangeType(newComic, typeof(T)));
            }
            catch
            {
                return default;
            }
        }

        public async Task<T?> PutAsync<T>(object param)
        {
            try
            {
                var comicToUpdate = (ComicDTO)Convert.ChangeType(param, typeof(ComicDTO));
                var index = _comics.FindIndex(c => c.Title.Replace(" ", "").Equals(comicToUpdate.Title.Replace(" ", "")));
                if (index == -1)
                    return default;
                _comics[index] = comicToUpdate;
                return await Task.FromResult((T)Convert.ChangeType(comicToUpdate, typeof(T)));
            }
            catch
            {
                return default;
            }
        }

        public async Task<T?> DeleteAsync<T>(object param)
        {
            try
            {
                var bookToDelete = _comics.Where(b => b.Title.Replace(" ", "").Equals(param)).FirstOrDefault();
                if (bookToDelete == null)
                    return default;
                _comics.Remove(bookToDelete);
                return await Task.FromResult((T)Convert.ChangeType(bookToDelete, typeof(T)));
            }
            catch
            {
                return default;
            }
        }
    }
}
