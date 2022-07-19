using Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Repository.Repostories.Interfaces
{
    public interface IBookService
    {
        Book Creat(int libraryId, Book book);
    }
}
