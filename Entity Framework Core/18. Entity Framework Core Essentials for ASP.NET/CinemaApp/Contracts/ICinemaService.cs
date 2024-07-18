using CinemaApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CinemaApp.Contracts
{
    public interface ICinemaService
    {
        Task AddCinemaAsync(CinemaModel model);
    }
}
