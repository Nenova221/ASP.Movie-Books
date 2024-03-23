
using BookandFilmShop.Controllers;
using BookandFilmShop.Data;
using BookandFilmShop.Models;
using Humanizer.Localisation;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Moq;
using NUnit.Framework.Constraints;
using System.IO;

namespace AppTester
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public async Task Index_ReturnViewWithResult()
        {
            var mockContext = new Mock<BookandFilmShopContext>();
            var movies = new List<Movies>
            {
               new Movies  { Id=1, Title="Аргайл: Супершпионин", Genre="Екшън/Комедия", Director="Матю Вон", Description="Филма си заслужава"},
               new Movies { Id = 1, Title = "Аргайл: Супершпионин", Genre = "Екшън/Комедия", Director = "Матю Вон", Description ="Филма си заслужава" }
            }.AsQueryable();

            var mockSet = new Mock<DbSet<Movies>>();
            mockSet.As<IQueryable<Movies>>().Setup(m => m.Provider).Returns(movies.Provider);
            mockSet.As<IQueryable<Movies>>().Setup(m => m.Expression).Returns(movies.Expression);
            mockSet.As<IQueryable<Movies>>().Setup(m => m.ElementType).Returns(movies.ElementType);
            mockSet.As<IQueryable<Movies>>().Setup(m => m.GetEnumerator()).Returns(movies.GetEnumerator());

            mockContext.Setup(m=>m.Movies).Returns(mockSet.Object);
            var controller = new MoviesController(mockContext.Object);
            var result = await controller.Index();

            Assert.That(result,Is.TypeOf<ViewResult>());
            var viewResult = result as ViewResult;
            var model = viewResult.Model as IEnumerable<Movies>;
            Assert.That(model.Count, Is.EqualTo(1));
        }
    }
}
