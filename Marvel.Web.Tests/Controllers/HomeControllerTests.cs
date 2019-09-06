using System.Web.Mvc;
using Marvel.Web.Controllers;
using Marvel.Web.Models;
using Marvel.Web.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Rhino.Mocks;

namespace Marvel.Web.Tests
{
    [TestClass]
    public class HomeControllerTests
    {
        private IMarvelService _marvelService;
        private HomeController _controller;

        [TestInitialize]
        public void TestInit()
        {
            _marvelService = MockRepository.GenerateMock<IMarvelService>();
            _controller = new HomeController(_marvelService);
        }

        [TestMethod]
        public void GivenHomeController_WhenIndexIsCalled_ReturnsViewResult()
        {
            //act
            var result = _controller.Index() as ViewResult;

            //arrange
            Assert.IsNotNull(result);
            Assert.IsTrue(string.IsNullOrEmpty(result.ViewName) || result.ViewName == "Index");
            Assert.IsInstanceOfType(result.Model, typeof(MarvelViewModel));
        }

        [TestMethod]
        public void GivenHomeController_WhenIndexIsCalled_WithCharacterName_ReturnsViewResult_WithListOfComics()
        {
            //arrange
            var model = GetMarvelViewModel();
            _marvelService.Stub(x => x.GetComics(Arg<string>.Is.Anything)).Return(model);

            //act
            var result = _controller.Index("thor") as ViewResult;
            var viewModel = (MarvelViewModel)result.Model;

            //arrange
            Assert.IsNotNull(viewModel);
            CollectionAssert.AreEqual(viewModel.Comics, model.Comics);
        }

        [TestMethod]
        public void GivenHomeController_WhenIndexIsCalled_WithInvalidCharacterName_ReturnsViewResult_WithMessage()
        {
            //arrange
            _marvelService.Stub(x => x.GetComics(Arg<string>.Is.Anything)).Return(new MarvelViewModel());

            //act
            var result = _controller.Index("thor1") as ViewResult;
            var viewModel = (MarvelViewModel)result.Model;

            //arrange
            Assert.IsNotNull(viewModel);
            Assert.AreEqual(viewModel.Comics,null);
            Assert.AreEqual(viewModel.Message, "Sorry no comics found try again!");
        }

        private MarvelViewModel GetMarvelViewModel()
        {
            return new MarvelViewModel()
            {
                Comics = TestData.GetListOfComicViewModels()
            };
        }
    }
}
