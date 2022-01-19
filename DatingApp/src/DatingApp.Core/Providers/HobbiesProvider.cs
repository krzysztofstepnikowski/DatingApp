using DatingApp.Core.Models;

namespace DatingApp.Core.Providers
{
    public interface IHobbiesProvider
    {
        Hobby[] GetHobbies();
    }

    public class HobbiesProvider : IHobbiesProvider
    {
        public Hobby[] GetHobbies() => new Hobby[]
        {
            new Hobby { Name = "Movie", Hex = "#FF8383" },
            new Hobby { Name = "Photography", Hex = "#71CAFD" },
            new Hobby { Name = "Design", Hex = "#3269F8"},
            new Hobby { Name = "Reading Book", Hex = "#1AE99E" },
            new Hobby { Name = "Singing", Hex = "#F8C032"},
            new Hobby { Name = "Music", Hex = "#FF73D8" },
        };
    }
}
