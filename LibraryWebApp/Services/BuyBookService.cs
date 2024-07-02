using AutoMapper;
using LibraryWebApp.Dtos;
using LibraryWebApp.Entities;
using LibraryWebApp.IServices;
using LibraryWebApp.Models;
using LibraryWebApp.MyContexts;

namespace LibraryWebApp.Services
{
    public class BuyBookService : IBuyBooksService
    {
        private readonly IMapper _mapper;
        public AppDbContext _dbcontext;

        public BuyBookService(IMapper mapper, AppDbContext appDbContext)
        {
            _mapper = mapper;
            _dbcontext = appDbContext;

        }

        public async Task<ResponseModel<BuyBooksDto>> Add(BuyBooksDto bbook)
        {
            ResponseModel<BuyBooksDto> responseModel = new ResponseModel<BuyBooksDto> { Data = null, Status = 400 };
            var data = _mapper.Map<BuyBook>(bbook);
            _dbcontext.BuyBooks.Add(data);
            var rows = _dbcontext.SaveChanges();
            if (rows > 0)
            {
                var data2 = _dbcontext.Books.Where(x => x.Id == bbook.BookId).FirstOrDefault();
                data2.Count = data2.Count - 1;
                _dbcontext.SaveChanges();
                responseModel.Status = 200;
                responseModel.Data = bbook;

            }
            return responseModel;
        }

        public async Task<ResponseModel<bool>> Delete(int id)
        {
            ResponseModel<bool> responseModel = new ResponseModel<bool> { Data = false, Status = 400 };
            var data = _dbcontext.BuyBooks.Where(x => x.Id == id).FirstOrDefault();
            _dbcontext.BuyBooks.Remove(data);
            var rows = _dbcontext.SaveChanges();
            if (rows > 0)
            {
                responseModel.Status = 200;
                responseModel.Data = true;

            }
            return responseModel;
        }
            public async Task<ResponseModel<BuyBook>> GetAll()
            {
                ResponseModel<BuyBook> responseModel = new ResponseModel<BuyBook> { Data = null, Status = 400 };
                var data = _dbcontext.BuyBooks.ToList();
                var data2 = _mapper.Map<BuyBook>(data);
                responseModel.Data = data2;
                responseModel.Status = 200;

                return responseModel;
            }

            public async Task<ResponseModel<BuyBook>> GetById(int id)
            {
            ResponseModel<BuyBook> responseModel = new ResponseModel<BuyBook> { Data = null, Status = 400 };
            var data = _dbcontext.BuyBooks.Where(x => x.Id == id).FirstOrDefault();


            responseModel.Status = 200;
            responseModel.Data = data;


            return responseModel;
        }

            public async Task<ResponseModel<bool>> Update(BuyBooksDto bookpers, int id)
            {
            ResponseModel<bool> responseModel = new ResponseModel<bool> { Data = false, Status = 400 };
            var data = _dbcontext.BuyBooks.Where(x => x.Id == id).FirstOrDefault();
            _mapper.Map<BuyBooksDto, BuyBook>(bookpers, data);
            _dbcontext.BuyBooks.Update(data);
            _dbcontext.SaveChanges();

            responseModel.Status = 200;
            responseModel.Data = true;


            return responseModel;
        }
        }
   }

