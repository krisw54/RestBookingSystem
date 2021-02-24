using Carpenters.Kata.Angular.Models;
using System.Collections.Generic;

namespace Carpenters.Kata.Angular.Services.Interfaces
{
    public interface IDataService
    {
        IList<Booking> Initialize();
    }
}