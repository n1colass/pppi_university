using RestAPI.Models.DTO;

namespace RestAPI.Services.Books
{
    public class Books : IBooks
    {
        static private List<BookDTO> _books;
        public Books()
        {
            _books = new List<BookDTO>
            {
                new BookDTO {Title = "1984", Author = "Jorge Orwell", Language = "English", Publisher = "Sun Rise Studio",Pages = 328 },
                new BookDTO {Title = "To Kill a Mockingbird", Author = "Harper Lee", Language = "English", Publisher = "J. B. Lippincott & Co.", Pages = 281 },
                new BookDTO {Title = "Pride and Prejudice", Author = "Jane Austen", Language = "English", Publisher = "T. Egerton", Pages = 279 },
                new BookDTO {Title = "The Great Gatsby", Author = "F. Scott Fitzgerald", Language = "English", Publisher = "Charles Scribner's Sons", Pages = 180 },
                new BookDTO {Title = "Moby-Dick; or, The Whale", Author = "Herman Melville", Language = "English", Publisher = "Harper & Brothers", Pages = 635 },
                new BookDTO {Title = "Crime and Punishment", Author = "Fyodor Dostoevsky", Language = "Russian", Publisher = "The Russian Messenger", Pages = 551 },
                new BookDTO {Title = "The Brothers Karamazov", Author = "Fyodor Dostoevsky", Language = "Russian", Publisher = "The Russian Messenger", Pages = 824 },
                new BookDTO {Title = "One Hundred Years of Solitude", Author = "Gabriel García Márquez", Language = "Spanish", Publisher = "Harper & Row", Pages = 417 },
                new BookDTO {Title = "Don Quixote", Author = "Miguel de Cervantes", Language = "Spanish", Publisher = "Francisco de Robles", Pages = 863 },
                new BookDTO {Title = "The Count of Monte Cristo", Author = "Alexandre Dumas", Language = "French", Publisher = "Pétion", Pages = 464 }
            };
        }

        public async Task<T?> GetAsync<T>(object? param)
        {
            try
            {
                if (param == null)
                {
                    // return the entire list of books
                    var result = _books;
                    return await Task.FromResult(result != null ? (T)(object)result : default(T));
                }
                else
                {
                    // return the book(s) that match the provided param
                    var result = _books.Where(b => b.Title.Replace(" ", "").Equals(param)).FirstOrDefault();
                    return await Task.FromResult(result != null ? (T)(object)result : default(T));
                }
            }
            catch
            {
                throw new NewException("Something gone wrong"); ;
            }
        }

        public async Task<T?> PostAsync<T>(object param)
        {
            try
            {
                var newBook = (BookDTO)Convert.ChangeType(param, typeof(BookDTO));
                _books.Add(newBook);
                return await Task.FromResult((T)Convert.ChangeType(newBook, typeof(T)));
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
                var bookToUpdate = (BookDTO)Convert.ChangeType(param, typeof(BookDTO));
                var index = _books.FindIndex(b => b.Title.Replace(" ", "").Equals(bookToUpdate.Title.Replace(" ", "")));
                if (index == -1)
                    return default;
                _books[index] = bookToUpdate;
                return await Task.FromResult((T)Convert.ChangeType(bookToUpdate, typeof(T)));
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
                var bookToDelete = _books.Where(b => b.Title.Replace(" ", "").Equals(param)).FirstOrDefault();
                if (bookToDelete == null)
                    return default;
                _books.Remove(bookToDelete);
                return await Task.FromResult((T)Convert.ChangeType(bookToDelete, typeof(T)));
            }
            catch
            {
                return default;
            }
        }
    }
}