using Domain.Models;
using Repository.Data;
using Repository.Exceptions;
using Repository.Repostories.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Repository.Repostories
{
    public class BookRepository : IRepository<Book>
    {
        public void Create(Book data)
        {

            try
            {
                if (data is null) throw new NotFoundException("Data not found");
                AppDbContext<Book>.datas.Add(data);
            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message);
            }
        }

        public void Delete(Book data)
        {
            throw new NotImplementedException();
        }

        public Book Get(Predicate<Book> predicate)
        {
            throw new NotImplementedException();
        }

        public List<Book> GetAll(Predicate<Book> predicate)
        {
            throw new NotImplementedException();
        }

        public void Update(Book data)
        {
            throw new NotImplementedException();
        }
    }
}
