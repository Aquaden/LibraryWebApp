using LibraryWebApp.Dtos;
using LibraryWebApp.Entities;
using LibraryWebApp.Models;

namespace LibraryWebApp.IServices
{
    public interface IBooksService
    {
        public Task<ResponseModel<Books>> GetAll();
        public Task<ResponseModel<BooksDto>> Add(BooksDto bbook);
        public Task<ResponseModel<Books>> GetById(int id);
        public Task<ResponseModel<bool>> Update(BooksDto book, int id);
        public Task<ResponseModel<bool>> Delete(int id);
    }
}
