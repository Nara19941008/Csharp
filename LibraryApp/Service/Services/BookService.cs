using Domain.Models;
using Repository.Repostories;
using Repository.Repostories.Interfaces;
using System;


namespace Service.Services
{
    public class BookService : IBookService
    {
        private BookRepository _bookRepository;
        private LibraryRepository _libraryRepository;
        private int _count;
        public BookService()
        {
            _bookRepository = new BookRepository();
            _libraryRepository = new LibraryRepository();
        }
        public Book Creat(int libraryId, Book book)
        {
            var library = _libraryRepository.Get(m => m.Id == libraryId);
            if (library is null) return null;
            book.Id = _count;
            book.Library = library;
            _bookRepository.Create(book);
            _count++;
            return book;

        }
    }
}
