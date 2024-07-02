using LibraryWebApp.Dtos;
using LibraryWebApp.Entities;
using LibraryWebApp.Models;

namespace LibraryWebApp.IServices
{
    public interface IAuthorService
    {
        public  Task<ResponseModel<Authors>> GetAll();
        public Task<ResponseModel<AuthorDto>> Add(AuthorDto auth);
        public Task<ResponseModel<Authors>> GetById(int id);
        public Task<ResponseModel<bool>> Update(AuthorDto author,int id);
        public Task<ResponseModel<bool>> Delete(int id);
    }
}
