using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Linq;

namespace PersonOfTheYear.Models
{
    public class Person
    {
        public int Year { get; set; }
        public string Honor { get; set; }
        public string Name { get; set; }
        public string Country { get; set; }

        [Display(Name = "Birth Year")]
        public int Birth_Year { get; set; }

        [Display(Name = "Death Year")]
        public int DeathYear { get; set; }
        public string Title { get; set; }
        public string Category { get; set; }
        public string Context { get; set; }

        /// <summary>
        /// Creates a list of people named 'person of the year' by TIME between the two given dates
        /// </summary>
        /// <param name="start">The lower limit of the search.</param>
        /// <param name="end">The upper limit of the search.</param>
        /// <returns>A list of people.</returns>
        public static List<Person> GetPeople(int start, int end)
        {
            List<Person> people = new List<Person>();

            string path = Path.GetFullPath(Path.Combine(
                Environment.CurrentDirectory, @"Data\personOfTheYear.csv"));

            foreach (string line in File.ReadAllLines(path))
            {
                string[] fields = line.Split(',');
                if (fields[0] == "Year") continue;

                people.Add(new Person
                {
                    Year = Convert.ToInt32(fields[0]),
                    Honor = fields[1],
                    Name = fields[2],
                    Country = fields[3],
                    Birth_Year = (fields[4] == "") ? 0 : Convert.ToInt32(fields[4]),
                    DeathYear = (fields[5] == "") ? 0 : Convert.ToInt32(fields[5]),
                    Title = fields[6],
                    Category = fields[7],
                    Context = fields[8]
                });
            }

            return people.Where(p => (p.Year >= start) && (p.Year <= end)).ToList();
        }
    }
}
