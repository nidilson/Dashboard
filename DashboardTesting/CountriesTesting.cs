using Dashboard.Models;
using Dashboard.Servicios;
using Microsoft.VisualStudio.TestPlatform.Utilities;
using Moq;
using System.Drawing;

namespace DashboardTesting
{
	public class CountriesTesting
	{
		public Mock<IHttpClientFactory> factory;
		public CountriesService service;
		private readonly ITestOutputHelper _output;
		public CountriesTesting(ITestOutputHelper output) {
			_output = output;
			factory = new Mock<IHttpClientFactory>();
			// HttpClient "fake" para el test
			var httpClient = new HttpClient();

			factory
				.Setup(f => f.CreateClient(It.IsAny<string>()))
				.Returns(httpClient);
			service = new CountriesService(factory.Object);
		}
		[Fact]
		public async Task GetAllCountriesTest()
		{
			//Arrange
			List<Country> list = new List<Country>();

			//Act
			list = await service.GetAll();

			string output = "";
			list.ForEach(i =>  output += $"{i.Name.Official} - {i.Area.ToString()}\n");

			_output.WriteLine(output);
			
			//Assert
			Assert.True(list.Count > 0);
		}

	}
}
