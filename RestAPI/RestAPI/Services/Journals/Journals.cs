using RestAPI.Models.DTO;

namespace RestAPI.Services.Journals
{
    public class Journals : IJournals
    {
        static private List<JournalDTO> _journals;
        public  Journals()
        {
            _journals = new List<JournalDTO>
            {
                new JournalDTO {Title = "A compelling story of love and betrayal", Publisher = "Penguin Random House", Price = 15},
                new JournalDTO {Title = "A gripping tale of survival in the wilderness", Publisher = "HarperCollins", Price = 20},
                new JournalDTO {Title = "A heartwarming memoir of family and identity", Publisher = "Simon & Schuster", Price = 12},
                new JournalDTO {Title = "A chilling thriller that will keep you on the edge of your seat", Publisher = "Hachette Book Group", Price = 18},
                new JournalDTO {Title = "A funny and relatable coming-of-age story", Publisher = "Macmillan Publishers", Price = 14},
                new JournalDTO {Title = "A powerful exploration of race and injustice in America", Publisher = "Random House", Price = 22},
                new JournalDTO {Title = "A delightful collection of short stories", Publisher = "Penguin Classics", Price = 10},
                new JournalDTO {Title = "A fascinating look at the history of the universe", Publisher = "National Geographic", Price = 25},
                new JournalDTO {Title = "A beautifully illustrated book of poetry", Publisher = "HarperCollins Publishers", Price = 16},
                new JournalDTO {Title = "A thought-provoking analysis of contemporary politics", Publisher = "Oxford University Press", Price = 28}
            };
        }

        public async Task<T?> GetAsync<T>(object? param)
        {
            try
            {
                if (param == null)
                {
                    var result = _journals;
                    return await Task.FromResult(result != null ? (T)(object)result : default(T));
                }
                else
                {
                    var result = _journals.Where(j => j.Title.Replace(" ", "").Equals(param)).FirstOrDefault();
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
                var newJournal = (JournalDTO)Convert.ChangeType(param, typeof(JournalDTO));
                _journals.Add(newJournal);
                return await Task.FromResult((T)Convert.ChangeType(newJournal, typeof(T)));
            }
            catch 
            {
                throw new NewException("Error adding new journal");
            }
        }

        public async Task<T?> PutAsync<T>(object param)
        {
            try
            {
                var journalToUpdate = (JournalDTO)Convert.ChangeType(param, typeof(JournalDTO));
                var index = _journals.FindIndex(j => j.Title.Replace(" ", "").Equals(journalToUpdate.Title.Replace(" ", "")));
                if (index == -1)
                    return default;
                _journals[index] = journalToUpdate;
                return await Task.FromResult((T)Convert.ChangeType(journalToUpdate, typeof(T)));
            }
            catch
            {
                throw new NewException("Error updating journal");
            }
        }

        public async Task<T?> DeleteAsync<T>(object param)
        {
            try
            {
                var journalToDelete = _journals.Where(j => j.Title.Replace(" ", "").Equals(param)).FirstOrDefault();
                if (journalToDelete == null)
                    return default;
                _journals.Remove(journalToDelete);
                return await Task.FromResult((T)Convert.ChangeType(journalToDelete, typeof(T)));
            }
            catch
            {
                throw new NewException("Error deleting journal");
            }
        }
    }
}