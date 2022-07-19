using Domain.Models;
using Repository.Repostories.Interfaces;
using Service.Services;
using Service.Services.Helpers;
using System;
using System.Collections.Generic;
using System.Text;

namespace LibraryApp.Controllers
{
    public class BookController
    {
        BookService bookService = new BookService();
        public void Create()
        {
            Helper.WriteConsole(ConsoleColor.Yellow, "Add library id:");
            LibraryId:  string libraryId = Console.ReadLine();
            int selectedLibraryId;
            bool isSelectedId = int.TryParse(libraryId, out selectedLibraryId);

            if (isSelectedId)
            {
                Helper.WriteConsole(ConsoleColor.Yellow, "Add book name: ");
                string bookName = Console.ReadLine();
                Helper.WriteConsole(ConsoleColor.Yellow, "Add book author: ");
                string author = Console.ReadLine();
                Book book = new Book()
                {
                    Name = bookName,
                    Author = author
                };

                var result = bookService.Creat(selectedLibraryId, book);
                if(result!= null)
                {
                    Helper.WriteConsole(ConsoleColor.Green, $"Book Id: {result.Id}, Library name: {result.Name}, Book Library: {result.Library.Name}");
                }
                else
                {
                    Helper.WriteConsole(ConsoleColor.Red, "Library not found, please add correct library id:");
                    goto LibraryId;
                }
            }
            else
            {
                Helper.WriteConsole(ConsoleColor.Red, "Add correct library id type:");
                goto LibraryId;
            }
            
        }
    }
}
