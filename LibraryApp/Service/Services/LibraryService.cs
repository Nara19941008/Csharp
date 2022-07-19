
using Domain.Models;
using Repository.Repostories;
using Service.Services.Interfaces;
using System.Collections.Generic;

namespace Service.Services
{
    public class LibraryService : ILibraryService
    {
        private LibraryRepository _libraryRepository;
        private int _count;
        public LibraryService()
        {
            _libraryRepository = new LibraryRepository();
        }
        public Library Create(Library library)
        {
            library.Id = _count;
            _libraryRepository.Create(library);
            _count++;
            return library;
        }

        public void Delete(int id)
        {
            Library library = GetById(id);
            _libraryRepository.Delete(library);
        }

        public List<Library> GetAll()
        {
            return _libraryRepository.GetAll();
        }

        public Library GetById(int Id)
        {
            var library = _libraryRepository.Get(m => m.Id == Id);
            if (library is null) return null;
            return library;
        }

        public List<Library> Search(string search)
        {
            return _libraryRepository.GetAll(m => m.Name.Trim().ToLower().StartsWith(search.Trim().ToLower()));
        }

        public Library Update(int Id, Library library)
        {
            Library dbLibrary = GetById(Id);
            if (dbLibrary is null) return null;
            library.Id = dbLibrary.Id;
            _libraryRepository.Update(library);
            return dbLibrary;
        }
    }
}
