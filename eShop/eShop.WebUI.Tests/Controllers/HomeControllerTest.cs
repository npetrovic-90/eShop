using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using eShop.WebUI;
using eShop.WebUI.Controllers;
using eShop.Core.Contracts;
using eShop.Core.Models;
using eShop.WebUI.Tests.Mocks;
using eShop.Core.ViewModels;

namespace eShop.WebUI.Tests.Controllers
{
	[TestClass]
	public class HomeControllerTest
	{
		[TestMethod]
		public void IndexPageDoesReturnProducts()
		{
			IRepository<Product> productContext = new Mocks.MockContext<Product>();
			IRepository<ProductCategory> productCategoryContext = new MockContext<ProductCategory>();

			productContext.Insert(new Product());

			HomeController controller = new HomeController(productContext,productCategoryContext);


			var result = controller.Index() as ViewResult;
			var viewModel = (ProductListViewModel)result.ViewData.Model;

			Assert.AreEqual(1, viewModel.Products.Count());
		}

		
	}
}
