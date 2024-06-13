using Biblioteca.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteca.Domain
{
    public class Book:BaseModel
    {

        public int Id { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public int CopiesAvailable { get; set; }
    }
}
