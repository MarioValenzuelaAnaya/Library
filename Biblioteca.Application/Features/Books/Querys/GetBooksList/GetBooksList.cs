﻿using Biblioteca.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteca.Application.Features.Books.Querys.GetBooksList
{
    public class GetBooksList: BaseModel
    {
     
        public string Title { get; set; }
        public string Author { get; set; }
        public int CopiesAvailable { get; set; }
    }
}
