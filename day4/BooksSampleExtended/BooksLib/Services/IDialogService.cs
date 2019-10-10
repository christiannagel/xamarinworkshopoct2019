using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BooksLib.Services
{
    public interface IDialogService
    {
        Task ShowDialogAsync(string title, string message);
    }
}
