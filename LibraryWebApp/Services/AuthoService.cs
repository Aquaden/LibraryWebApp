using AutoMapper;
using LibraryWebApp.Dtos;
using LibraryWebApp.Entities;
using LibraryWebApp.IServices;
using LibraryWebApp.Models;
using LibraryWebApp.MyContexts;

namespace LibraryWebApp.Services
{
    public class AuthoService : IAuthorService
    {
        private readonly IMapper _mapper;
        public AppDbContext _dbcontext;

        public AuthoService(IMapper mapper, AppDbContext appDbContext)
        {
            _mapper = mapper;
            _dbcontext = appDbContext;

        }
        public async Task<ResponseModel<AuthorDto>> Add(AuthorDto auth)
        {
            ResponseModel<AuthorDto> responseModel = new ResponseModel<AuthorDto> { Data = null, Status = 400 };
            var data = _mapper.Map<Authors>(auth);
            _dbcontext.Authors.Add(data);
            var rows = _dbcontext.SaveChanges();
            if (rows > 0)
            {
                responseModel.Status = 200;
                responseModel.Data = auth;

            }
            return responseModel;
        }

        public async Task<ResponseModel<bool>> Delete(int id)
        {
            ResponseModel<bool> responseModel = new ResponseModel<bool> { Data = false, Status = 400 };
            var data = _dbcontext.Authors.Where(x => x.id == id).FirstOrDefault();
            _dbcontext.Authors.Remove(data);
            var rows = _dbcontext.SaveChanges();
            if (rows > 0)
            {
                responseModel.Status = 200;
                responseModel.Data = true;

            }
            return responseModel;
        }

        public async Task<ResponseModel<Authors>> GetAll()
        {
            ResponseModel<Authors> responseModel = new ResponseModel<Authors> { Data = null, Status = 400 };
            var data = _dbcontext.Authors.ToList();
            var data2 = _mapper.Map<Authors>(data);
            responseModel.Data = data2;
            responseModel.Status = 200;

            return responseModel;
        }

        public async Task<ResponseModel<Authors>> GetById(int id)
        {
            ResponseModel<Authors> responseModel = new ResponseModel<Authors> { Data = null, Status = 400 };
            var data = _dbcontext.Authors.Where(x => x.id == id).FirstOrDefault();


            responseModel.Status = 200;
            responseModel.Data = data;


            return responseModel;
        }

        public async Task<ResponseModel<bool>> Update(AuthorDto author, int id)
        {
            ResponseModel<bool> responseModel = new ResponseModel<bool> { Data = false, Status = 400 };
            var data = _dbcontext.Authors.Where(x => x.id == id).FirstOrDefault();
            _mapper.Map<AuthorDto, Authors>(author, data);
            _dbcontext.Authors.Update(data);
            _dbcontext.SaveChanges();

            responseModel.Status = 200;
            responseModel.Data = true;


            return responseModel;
        }
    }
}
