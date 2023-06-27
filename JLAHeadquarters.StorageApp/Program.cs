using JLAHeadquarters.StorageApp.Data;
using JLAHeadquarters.StorageApp.Entities;
using JLAHeadquarters.StorageApp.Repositories;

namespace JLAHeadquarters.StorageApp
{
    class Program
    {
        static void Main(string[] args)
        {
            var heroRepository = new SqlRepository<Hero>(new StorageAppDbContext());
            heroRepository.ItemAdded += HeroRepository_ItemAdded;

            AddHeroes(heroRepository);
            AddMentors(heroRepository);
            GetHeroById(heroRepository);
            WriteAllToConsole(heroRepository);

            var villianRepository = new ListRepository<Villian>();
            AddVillians(villianRepository);
            WriteAllToConsole(villianRepository);

            Console.ReadLine();
        }

        private static void HeroRepository_ItemAdded(object? sender, Hero h)
        {
            Console.WriteLine($"Hero added => {h.HeroName}");
        }

        private static void AddMentors(IWriteRepository<Mentor> mentorRepository)
        {
            var aquamanMentor = new Mentor { HeroName = "Aquaman" };
            var aquamanMentorCopy = aquamanMentor.Copy();
            mentorRepository.Add(aquamanMentor);

            if(aquamanMentorCopy is not null)
            {
                aquamanMentorCopy.HeroName += "_Copy";
                mentorRepository.Add(aquamanMentorCopy);
            }
            mentorRepository.Add(new Mentor { HeroName = "Green Arrow" });
            mentorRepository.Save();
        }

        private static void WriteAllToConsole(IReadRepository<IEntity> repository)
        {
            var items = repository.GetAll();
            foreach (var item in items)
            {
                Console.WriteLine(item);
            }
        }

        private static void GetHeroById(IRepository<Hero> heroRepository)
        {
            var hero = heroRepository.GetById(1);
            Console.WriteLine($"Employee with Id 1: {hero.HeroName}");
        }

        private static void AddHeroes(IRepository<Hero> heroRepository)
        {
            var heroes = new[]
            {
                new Hero { HeroName = "Superman" },
                new Hero { HeroName = "Wonderwoman" },
                new Hero { HeroName = "Batman" }
            };

            heroRepository.AddBatch(heroes);
        }

        private static void AddVillians(IRepository<Villian> villianRepository)
        {
            var villians = new[]
            {
                new Villian { VillianName = "Joker" },
                new Villian { VillianName = "Lex Luthor" }
             };

            villianRepository.AddBatch(villians);
        }
    }
}
