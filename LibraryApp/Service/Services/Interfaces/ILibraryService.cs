
using Domain.Models;
using System.Collections.Generic;

namespace Service.Services.Interfaces
{
    public interface ILibraryService
    {
        Library Create(Library library);
        Library Update(int Id, Library library);
        void Delete(int Id);
        Library GetById(int Id);
        List<Library> GetAll();
        List<Library> Search(string search);

    }
}
