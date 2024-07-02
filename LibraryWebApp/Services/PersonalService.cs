using AutoMapper;
using LibraryWebApp.Dtos;
using LibraryWebApp.Entities;
using LibraryWebApp.IServices;
using LibraryWebApp.Models;
using LibraryWebApp.MyContexts;

namespace LibraryWebApp.Services
{
    public class PersonalService : IPersonalService
    {
        private readonly IMapper _mapper;
        public AppDbContext _dbcontext;

        public PersonalService(IMapper mapper, AppDbContext appDbContext)
        {
            _mapper = mapper;
            _dbcontext = appDbContext;

        }

        public async Task<ResponseModel<PersonalDto>> Add(PersonalDto person)
        {
            ResponseModel<PersonalDto> responseModel = new ResponseModel<PersonalDto> { Data = null, Status = 400 };
            var data = _mapper.Map<Personal>(person);
            _dbcontext.Personals.Add(data);
            var rows = _dbcontext.SaveChanges();
            if (rows > 0)
            {
                responseModel.Status = 200;
                responseModel.Data = person;

            }
            return responseModel;
        }

        public async Task<ResponseModel<bool>> Delete(int id)
        {
            ResponseModel<bool> responseModel = new ResponseModel<bool> { Data = false, Status = 400 };
            var data = _dbcontext.Personals.Where(x => x.Id == id).FirstOrDefault();
            _dbcontext.Personals.Remove(data);
            var rows = _dbcontext.SaveChanges();
            if (rows > 0)
            {
                responseModel.Status = 200;
                responseModel.Data = true;

            }
            return responseModel;
        }

        public async Task<ResponseModel<Personal>> GetAll()
        {
            ResponseModel<Personal> responseModel = new ResponseModel<Personal> { Data = null, Status = 400 };
            var data = _dbcontext.Personals.ToList();
            var data2 = _mapper.Map<Personal>(data);
            responseModel.Data = data2;
            responseModel.Status = 200;

            return responseModel;
        }

        public async Task<ResponseModel<Personal>> GetById(int id)
        {
            ResponseModel<Personal> responseModel = new ResponseModel<Personal> { Data = null, Status = 400 };
            var data = _dbcontext.Personals.Where(x => x.Id == id).FirstOrDefault();


            responseModel.Status = 200;
            responseModel.Data = data;


            return responseModel;
        }

        public async Task<ResponseModel<bool>> Update(PersonalDto personal, int id)
        {
            ResponseModel<bool> responseModel = new ResponseModel<bool> { Data = false, Status = 400 };
            var data = _dbcontext.Personals.Where(x => x.Id == id).FirstOrDefault();
            _mapper.Map<PersonalDto, Personal>(personal, data);
            _dbcontext.Personals.Update(data);
            _dbcontext.SaveChanges();

            responseModel.Status = 200;
            responseModel.Data = true;


            return responseModel;
        }
    }
}
