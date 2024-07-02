using AutoMapper;
using LibraryWebApp.Dtos;
using LibraryWebApp.Entities;
using LibraryWebApp.IServices;
using LibraryWebApp.Models;
using LibraryWebApp.MyContexts;

namespace LibraryWebApp.Services
{
    public class BooksService : IBooksService
    {
        private readonly IMapper _mapper;
        public AppDbContext _dbcontext;

        public BooksService(IMapper mapper, AppDbContext appDbContext)
        {
            _mapper = mapper;
            _dbcontext = appDbContext;
                
        }
        public async Task<ResponseModel<BooksDto>> Add(BooksDto bbook)
        {
            ResponseModel<BooksDto> responseModel = new ResponseModel<BooksDto> { Data = null , Status=400};  
            var data =   _mapper.Map<Books>(bbook);
            _dbcontext.Books.Add(data);
            var rows = _dbcontext.SaveChanges();
            if (rows > 0)
            {
                responseModel.Status= 200;
                responseModel.Data = bbook;

            }
            return responseModel;
        }

        public async Task<ResponseModel<bool>> Delete(int id)
        {
            ResponseModel<bool> responseModel = new ResponseModel<bool> { Data = false, Status = 400 };
            var data = _dbcontext.Books.Where(x => x.Id == id).FirstOrDefault();
            _dbcontext.Books.Remove(data);
            var rows = _dbcontext.SaveChanges();
            if (rows > 0)
            {
                responseModel.Status = 200;
                responseModel.Data = true;

            }
            return responseModel;

        }

        public async Task<ResponseModel<Books>> GetAll()
        {
            ResponseModel<Books> responseModel = new ResponseModel<Books> { Data = null, Status = 400 };
            var data = _dbcontext.Books.ToList();
            var data2 = _mapper.Map<Books>(data);
            responseModel.Data = data2;
            responseModel.Status = 200;

            return responseModel;
        }

        public async Task<ResponseModel<Books>> GetById(int id)
        {
            ResponseModel<Books> responseModel = new ResponseModel<Books> { Data = null, Status = 400 };
            var data = _dbcontext.Books.Where(x => x.Id == id).FirstOrDefault();
            
            
                responseModel.Status = 200;
                responseModel.Data = data;

            
            return responseModel;
        }

        public async Task<ResponseModel<bool>> Update(BooksDto book, int id)
        {
            ResponseModel<bool> responseModel = new ResponseModel<bool> { Data = false, Status = 400 };
            var data = _dbcontext.Books.Where(x => x.Id == id).FirstOrDefault();
            _mapper.Map<BooksDto,Books>(book,data);
            _dbcontext.Books.Update(data);
            _dbcontext.SaveChanges();
            
            responseModel.Status = 200;
            responseModel.Data = true;


            return responseModel;
        }
    }
}
