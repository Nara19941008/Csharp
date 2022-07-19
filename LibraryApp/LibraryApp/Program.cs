using Domain.Models;
using LibraryApp.Controllers;
using Service.Services;
using Service.Services.Helpers;
using System;
using System.Collections.Generic;

namespace LibraryApp
{
    class Program
    {
        static void Main(string[] args)
        {
            LibraryController libraryController = new LibraryController();
            BookController bookController = new BookController();
            Helper.WriteConsole(ConsoleColor.Yellow, "Select one option:");
            GetMenus();
            

            while (true)
            {
                SelectOption: string SelectOption = Console.ReadLine();
                int selectTrueOption;
                bool isSelectOption = int.TryParse(SelectOption, out selectTrueOption);
                if (isSelectOption)
                {
                    switch (selectTrueOption)
                    {
                        case (int)Menues.CreateLibrary:
                            libraryController.Create();
                            break;
                        case (int)Menues.GetLibraryById:
                            libraryController.GetLibraryById();
                            break;
                        case (int)Menues.UpdateLibrary:
                            libraryController.Update();
                            break;
                        case (int)Menues.DeleteLibrary:
                            libraryController.Delete();
                            break;
                        case (int)Menues.GetAllLibraries:
                            libraryController.GetAllLibraries();
                            break;
                        case (int)Menues.SearchLibrary:
                            libraryController.Search();
                            break;
                        case (int)Menues.CreateBook:
                            bookController.Create();
                            break;
                        default:
                            Helper.WriteConsole(ConsoleColor.Red, "Select correct option number:");
                            goto SelectOption;
                            
                    }
                }
               
            }
        }
        private static void GetMenus()
        {
            Helper.WriteConsole(ConsoleColor.Green, "1 - Create library, 2 - Get library by Id, 3 - Update library, + " +
                "4 - Delete library, 5 - Get all libraries, 6 - Search By name libraries, 7- Create book");
        }
    }
}
