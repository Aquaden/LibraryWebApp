using LibraryWebApp.Dtos;
using LibraryWebApp.Entities;
using LibraryWebApp.Models;

namespace LibraryWebApp.IServices
{
    public interface IBuyBooksService
    {
        public Task<ResponseModel<BuyBook>> GetAll();
        public Task<ResponseModel<BuyBooksDto>> Add(BuyBooksDto bbook);
        public Task<ResponseModel<BuyBook>> GetById(int id);
        public Task<ResponseModel<bool>> Update(BuyBooksDto author, int id);
        public Task<ResponseModel<bool>> Delete(int id);
    }
}
