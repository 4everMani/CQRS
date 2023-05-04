using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Repositories
{
    public interface IImageRepo
    {
        Task AddNewAsync(Image image);

        Task DeleteAsync(Image image);

        Task UpdateAsync(Image image);

        Task<List<Image>> GetAllAsync();

        Task<Image> GetByIdAsync(int id);


    }
}
