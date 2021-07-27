using BookReader.Data.Models;
using BookReader.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookReader.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : ControllerBase
    {
        private readonly IBookRepository _bookRepository;
        public BookController(IBookRepository bookRepository)
        {
            //ProductCategory category = new ProductCategory();
            //category.Parent;
            //category.ProductCategories
            _bookRepository = bookRepository;
        }
    }
}
