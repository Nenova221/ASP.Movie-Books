using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using BookandFilmShop.Controllers;
using BookandFilmShop.Models;

namespace BookandFilmShop.Data
{
    public class BookandFilmShopContext : DbContext
    {
        public BookandFilmShopContext (DbContextOptions<BookandFilmShopContext> options)
            : base(options)
        {
        }

        public DbSet<BookandFilmShop.Controllers.Book> Book { get; set; } = default!;

        public DbSet<BookandFilmShop.Models.Movies> Movies { get; set; } = default!;
    }
}
