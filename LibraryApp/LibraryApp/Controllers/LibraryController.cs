using Domain.Models;
using Service.Services;
using Service.Services.Helpers;
using System;
using System.Collections.Generic;
using System.Text;

namespace LibraryApp.Controllers
{
    public class LibraryController
    {
        LibraryService libraryService = new LibraryService();
        public void Create()
        {
            Helper.WriteConsole(ConsoleColor.Yellow, "Add library name:");
                            string libraryName = Console.ReadLine();
                            Helper.WriteConsole(ConsoleColor.Yellow, "Add seat count:");
                            SeatCount: string librarySeatCount = Console.ReadLine();
                            int seatCount;
                            bool isSeatCount = int.TryParse(librarySeatCount, out seatCount);
                            if (isSeatCount)
                            {
                                Library library = new Library
                                {
                                    Name = libraryName,
                                    SeatCount = seatCount

                                };
                                var result = libraryService.Create(library);
                                Helper.WriteConsole(ConsoleColor.Green, $"Library Id: {result.Id}, Library name: {result.Name}, Library seat count: {result.SeatCount}");

                            }
                            else
                            {
                                Helper.WriteConsole(ConsoleColor.Red, "Add correct seat count:");
                                goto SeatCount;
                            }
        }
        public void GetLibraryById()
        {
            Helper.WriteConsole(ConsoleColor.Yellow, "Add library id:");
            LibraryId: string libraryId = Console.ReadLine();
            int id;
            bool isLibraryId = int.TryParse(libraryId, out id);
            if (isLibraryId)
            {
                Library library = libraryService.GetById(id);
                if (library != null)
                {
                    Helper.WriteConsole(ConsoleColor.Green, $"Library Id: {library.Id}, Library name: {library.Name}, Library seat count: {library.SeatCount}");
                }
                else
                {
                    Helper.WriteConsole(ConsoleColor.Red, "Library not found");
                    goto LibraryId;
                }
            }
            else
            {
                Helper.WriteConsole(ConsoleColor.Red, "Add correct id type:");
                goto LibraryId;
            }


        }
        public void GetAllLibraries()
        {
            List<Library> libraries = libraryService.GetAll();
            foreach (var item in libraries)
            {
                Helper.WriteConsole(ConsoleColor.Green, $"Library Id: {item.Id}, Library name: {item.Name}, Library seat count: {item.SeatCount}");
            }
        }
        public void Search()
        {
            Helper.WriteConsole(ConsoleColor.Yellow, "Add library search text:");
            SearchText: string search = Console.ReadLine();
            List<Library> resultLibraries = libraryService.Search(search);
            if (resultLibraries.Count != 0)
            {
                foreach (var item in resultLibraries)
                {
                    Helper.WriteConsole(ConsoleColor.Green, $"Library Id: {item.Id}, Library name: {item.Name}, Library seat count: {item.SeatCount}");
                }
            }
            else
            {
                Helper.WriteConsole(ConsoleColor.Red, "Library not found");
                goto SearchText;
            }
        }
        public void Delete()
        {
            Helper.WriteConsole(ConsoleColor.Yellow, "Add library id: ");
            LibraryId: string LibraryId = Console.ReadLine();
            int id;
            bool isLibraryId = int.TryParse(LibraryId, out id);
            if (isLibraryId)
            {

            }
            else
            {
                Helper.WriteConsole(ConsoleColor.Red, "Select correct id type");
                goto LibraryId;
            }
        }
        public void Update()
        {
            Helper.WriteConsole(ConsoleColor.Yellow, "Add library id : ");
            LibraryId: string updateLibraryId = Console.ReadLine();
            int libraryId;
            bool isLibraryId = int.TryParse(updateLibraryId, out libraryId);
            if (isLibraryId)
            {
                Helper.WriteConsole(ConsoleColor.Yellow, "Add library new name : ");
                string libraryNewName = Console.ReadLine(); 
                Helper.WriteConsole(ConsoleColor.Yellow, "Add library new seat count : ");
                SeatCount:  string libraryNewSeatCount = Console.ReadLine();
                int seatCount;
                bool isSeatCount = int.TryParse(libraryNewSeatCount, out seatCount);
                if (isSeatCount || libraryNewSeatCount == "")
                {
                    bool isSeatCountEmpty = string.IsNullOrEmpty(libraryNewSeatCount);
                    int? count = null;
                    if (isSeatCountEmpty)
                    {
                        count = null;
                    }
                    else
                    {
                        count = seatCount;
                    }
                    Library library = new Library()
                    {
                        Name = libraryNewName,
                        SeatCount = count
                    };
                    var resultLibrary =  libraryService.Update(libraryId, library);
                    if (resultLibrary == null)
                    {
                        Helper.WriteConsole(ConsoleColor.Red, "Library not found, please try again");
                        goto LibraryId;
                    }
                    else
                    {
                        Helper.WriteConsole(ConsoleColor.Green, $"Library Id: {resultLibrary.Id}, Library name: {resultLibrary.Name}, Library seat count: {resultLibrary.SeatCount}");
                    }
                }
                else
                {
                    Helper.WriteConsole(ConsoleColor.Red, "Add correct seat count");
                    goto SeatCount;
                }
                

            }
            else
            {
                Helper.WriteConsole(ConsoleColor.Red, "Select correct id type");
                goto LibraryId;
            }
        }
    }
}
