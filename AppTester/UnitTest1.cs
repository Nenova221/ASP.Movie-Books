using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Mvc;

using BookandFilmShop.Data;
using BookandFilmShop.Models;

namespace BookandFilmShop.Controllers
{
    [TestFixture]
    public class BookandFilmShopContextTests
    {
        private DbContextOptions<BookandFilmShopContext> GetDbContextOptions()
        {
            var serviceProvider = new ServiceCollection()
                .AddEntityFrameworkInMemoryDatabase()
                .BuildServiceProvider();

            var builder = new DbContextOptionsBuilder<BookandFilmShopContext>()
                .UseInMemoryDatabase("TestDatabase")
                .UseInternalServiceProvider(serviceProvider);

            return builder.Options;
        }

        [Test]
        public async Task Index_ReturnsViewWithListOfShoes()
        {
            var options = GetDbContextOptions();
            using (var context = new BookandFilmShopContext(options))
            {
                context.Movies.Add(new Movies { Id = 1, Title = "Scream", Genre = "horror", Director = "Matt Bettinelli-Olpin", Description = "Scream is an American slasher franchise that includes six films, a television series, merchandise, and games."});
                context.SaveChanges();
            }
            using (var context = new BookandFilmShopContext(options))
            {
                var controller = new MoviesController(context);
                var result = await controller.Index();
                // Assert
                Assert.IsInstanceOf<ViewResult>(result);
            }
        }
        [Test]
        public async Task Delete_ReturnsRedirectToActionResult()
        {
            var options = GetDbContextOptions();
            using (var context = new BookandFilmShopContext(options))
            {
                context.Movies.Add(new Movies { Id = 1, Title = "Scream", Genre = "horror", Director = "Matt Bettinelli-Olpin", Description = "Scream is an American slasher franchise that includes six films, a television series, merchandise, and games." });
                context.SaveChanges();
            }
            using (var context = new BookandFilmShopContext(options))
            {
                var controller = new MoviesController(context);
                var result = await controller.DeleteConfirmed(1);
                // Assert
                Assert.IsInstanceOf<RedirectToActionResult>(result);
            }
        }
        [Test]
        public async Task Edit_ReturnsRedirectToActrionResult()
        {
            var options = GetDbContextOptions();
            using (var context = new BookandFilmShopContext(options))
            {
                context.Movies.Add(new Movies { Id = 1, Title = "Scream", Genre = "horror", Director = "Matt Bettinelli-Olpin", Description = "Scream is an American slasher franchise that includes six films, a television series, merchandise, and games." });
                context.SaveChanges();
            }
            using (var context = new BookandFilmShopContext(options))
            {
                var controller = new MoviesController(context);
                var result = await controller.Edit(1);
                // Assert
                Assert.IsInstanceOf<ViewResult>(result);
            }
        }
        [Test]
        public async Task Create_ReturnsRedirectToActrionResult()
        {
            var options = GetDbContextOptions();
            var shoe = new  Movies { Id = 1, Title = "Scream", Genre = "horror", Director = "Matt Bettinelli-Olpin", Description = "Scream is an American slasher franchise that includes six films, a television series, merchandise, and games." };
            using (var context = new BookandFilmShopContext(options))
            {
                var controller = new MoviesController(context);
                var result = await controller.Create(shoe);
                // Assert
                Assert.IsInstanceOf<RedirectToActionResult>(result);
            }
        }
        [Test]
        public async Task Details_ReturnsRedirectToActrionResult()
        {
            var options = GetDbContextOptions();
            using (var context = new BookandFilmShopContext(options))
            {
                context.Movies.Add(new Movies { Id = 1, Title = "Scream", Genre = "horror", Director = "Matt Bettinelli-Olpin", Description = "Scream is an American slasher franchise that includes six films, a television series, merchandise, and games." });
                context.SaveChanges();
            }
            using (var context = new BookandFilmShopContext(options))
            {
                var controller = new MoviesController(context);
                var result = await controller.Details(1);
                // Assert
                Assert.IsInstanceOf<ViewResult>(result);
            }
        }
    }
}