using System.Reflection;
using System.Collections.Generic;
using System;

namespace Lab_4
{
    internal class Program
    {
        
        static void Main(string[] args)
        {
            Console.WriteLine("-----------------Type-----------------");

            Film film = new Film(120, "The Godfather", true, 245.1);
            Type type = film.GetType();
            Console.WriteLine(type.IsAbstract);

            Console.WriteLine("-----------------TypeInfo-----------------");

            TypeInfo filmTypeInfo = type.GetTypeInfo();

            Console.WriteLine(filmTypeInfo);

            Console.WriteLine("-----------------MemberInfo-----------------");

            MemberInfo[] filmMemberInfos = filmTypeInfo.GetMembers();

            Console.WriteLine("All members of the Film class:");

            foreach (var memberInfo in filmMemberInfos)
            {
                Console.WriteLine(memberInfo.Name);
            }



            Console.WriteLine("-----------------FieldInfo-----------------");

            FieldInfo[] filmFieldInfos = filmTypeInfo.GetFields(BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.Public);

            Console.WriteLine("All fields of the Film class:");

            foreach (var fieldInfo in filmFieldInfos)
            {
                Console.WriteLine(fieldInfo.Name);
            }
            FieldInfo revenueField = filmTypeInfo.GetField("minutes");
            revenueField.SetValue(film, 180);
     

            Console.WriteLine("-----------------MethodInfo-----------------");

            MethodInfo filmDurationMethod = filmTypeInfo.GetMethod("FilmDuration", BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.Public);
            filmDurationMethod.Invoke(film, null);

            MethodInfo addGenreMethod = filmTypeInfo.GetMethod("AddGenre");
            addGenreMethod.Invoke(film, new object[] { "Drama" });
            addGenreMethod.Invoke(film, new object[] { "Crime" });
            addGenreMethod.Invoke(film, new object[] { "Thriller" });
            Console.WriteLine(String.Join(" ", film.genres));
            
        }
    }
    public class Film
    {
        public int minutes;
        private readonly string title;
        internal List<string> genres;
        protected bool isLimit;
        private protected double revenue;

        public Film(int minutes, string title, bool isLimit, double revenue)
        {
            this.minutes = minutes;
            this.title = title;
            this.isLimit = isLimit;
            this.revenue = revenue;
            genres = new List<string>();
        }

        public void AddGenre(string genre)
        {
            genres.Add(genre);
        }

        public void FilmDistribution()
        {
            Console.WriteLine(title + " revenue: " + revenue + "$ millions!");
        }

        public void FilmDuration()
        {
            Console.WriteLine(title + " duration: " + minutes/60 + " hours!");
        }
    }
}
