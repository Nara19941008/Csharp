﻿ using Domain.Models;
using Repository.Data;
using Repository.Exceptions;
using Repository.Repostories.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Repository.Repostories
{
    public class LibraryRepository : IRepository<Library>
    {
        public void Create(Library data)
        {
            try
            {
                if (data is null) throw new NotFoundException("Data not found");
                AppDbContext<Library>.datas.Add(data);
            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message);
            }
        }

        public void Delete(Library data)
        {
            AppDbContext<Library>.datas.Remove(data);
        }

        public List<Library> GetAll(Predicate<Library> predicate = null)
        {
            return predicate != null ? AppDbContext<Library>.datas.FindAll(predicate) : AppDbContext<Library>.datas;
        }

        public Library Get(Predicate<Library> predicate = null)
        {
            return predicate != null ? AppDbContext<Library>.datas.Find(predicate) : null;
        }

        public void Update(Library data)
        {
            Library library = Get(m => m.Id == data.Id);
            if (!string.IsNullOrEmpty(data.Name))
                library.Name = data.Name;
            if (data.SeatCount != null)
                library.SeatCount = data.SeatCount;

        }

        
    }
}
