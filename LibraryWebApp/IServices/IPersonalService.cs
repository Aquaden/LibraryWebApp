using LibraryWebApp.Dtos;
using LibraryWebApp.Entities;
using LibraryWebApp.Models;

namespace LibraryWebApp.IServices
{
    public interface IPersonalService
    {
        public Task<ResponseModel<Personal>> GetAll();

        public Task<ResponseModel<PersonalDto>> Add(PersonalDto person);

        public Task<ResponseModel<Personal>> GetById(int id);
        public Task<ResponseModel<bool>> Update(PersonalDto personal, int id);
        public Task<ResponseModel<bool>> Delete(int id);
    }
}
