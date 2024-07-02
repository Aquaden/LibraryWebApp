using LibraryWebApp.Dtos;
using LibraryWebApp.Entities;
using LibraryWebApp.Models;

namespace LibraryWebApp.IServices
{
    public interface IGenreService
    {
        public Task<ResponseModel<Genres>> GetAll();
        public Task<ResponseModel<GenresDto>> Add(GenresDto genre);
        public Task<ResponseModel<Genres>> GetById(int id);
        public Task<ResponseModel<bool>> Update(Genres genre);
        public Task<ResponseModel<bool>> Delete(int id);
    }
}
