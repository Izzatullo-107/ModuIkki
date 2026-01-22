using Dars2_5_Abstarakshin.Models;
using Dars2_5_Abstarakshin.Services;
using Dars2_5_Abstarakshin.Services.Interfaces;

namespace Dars2_5_Abstarakshin
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //ICountryService countryService = new CountryService();
            //Country country1 = new Country
            //{
            //    Name = "USA",
            //    Area = 50000.34,
            //    IpAddress = 123456,
            //    Population = 1000000
            //};
            //Country country2 = new Country
            //{
            //    Name = "UK",
            //    Area = 75000.34,
            //    IpAddress = 654321,
            //    Population = 2000000
            //};
            //Guid country1Id = countryService.AddCountry(country1);
            //Guid country2Id = countryService.AddCountry(country2);
            //List<Country> countries = countryService.GetAllCountries();

            //Console.WriteLine(country1Id);
            //Console.WriteLine(country2Id);

            IBlackBoard blackBoardService = new BlackBoardService();
            BlackBoard board1 = new BlackBoard
            {
                Name = "Sonik",
                Color = "blak",
                Width = 5000.00,
                Height = 1500.00,
                Length = 12000.00
            };  
            BlackBoard board2 = new BlackBoard
            {
                Name = "Sonik2",
                Color = "blak",
                Width = 2000.00,
                Height = 1900.00,
                Length = 15000.00
            };
            Guid board1Id = blackBoardService.AddBlackBoard(board1);
            Guid board2Id = blackBoardService.AddBlackBoard(board2);

            foreach (var board in blackBoardService.GetAllBlackBoards())
            {
                Console.WriteLine(board);
            }


        }
    }
}
