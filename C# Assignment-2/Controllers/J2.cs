using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace C__Assignment_2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class J2 : ControllerBase
    {
        /// Question-3

        /// <summary>
        /// It will calculates the total spiciness in SHU (Scoville Heat Units) based on the list of peppers.
        /// </summary>
        /// <returns>
        /// It will returns the total spiciness in SHU (Scoville Heat Units) as an integer.
        /// </returns>
        /// <param name="Ingredients">List of pepper names</param>
        /// <remarks>
        ///These are the SHU of peppers.
        /// Poblano = 1500
        /// Mirasol = 6000
        /// Serrano = 15500
        /// Cayenne = 40000
        /// Thai = 75000
        /// Habanero = 125000
        /// </remarks>
        /// <example>
        /// GET : api/J2/ChiliPeppers&Ingredients=Poblano,Cayenne,Thai,Poblano -> 118000
        /// GET : api/J2/ChiliPeppers&Ingredients=Habanero,Habanero,Habanero,Habanero,Habanero -> 625000
        /// GET : api/J2/ChiliPeppers&Ingredients=Poblano,Mirasol,Serrano,Cayenne,Thai,Habanero,Serrano -> 278500
        /// </example>

        [HttpGet(template: "ChiliPeppers")]
        public int ChiliPeppers(string Ingredients)
        {
            int Poblano = 1500;
            int Mirasol = 6000;
            int Serrano = 15500;
            int Cayenne = 40000;
            int Thai = 75000;
            int Habanero = 125000;

            int total_spice = 0;
            string[] list_of_peppers = Ingredients.Split(',');

            foreach (string pepper in list_of_peppers)
            {
                string trim_the_pepper = pepper.Trim();
                if (trim_the_pepper == "Poblano")
                {
                    total_spice += Poblano;
                }
                else if (trim_the_pepper == "Mirasol")
                {
                    total_spice += Mirasol;
                }
                else if (trim_the_pepper == "Serrano")
                {
                    total_spice += Serrano;
                }
                else if (trim_the_pepper == "Cayenne")
                {
                    total_spice += Cayenne;
                }
                else if (trim_the_pepper == "Thai")
                {
                    total_spice += Thai;
                }
                else
                {
                    total_spice += Habanero;
                }
            }
            return total_spice;
        }


        /// Question-4

        /// <summary>
        /// It will calculates the number of players with star rating grater than 40 and checks if the team is a gold team.
        /// </summary>
        /// <returns>
        /// it will give the number of players that have a star rating greater than 40, immediately followed by a plus sign if the team is considered a gold team.
        /// </returns>
        /// <param name="scored">number of scores made by player </param>
        /// <param name="fouls">number of fouls made by player</param>
        /// <example>
        /// GET : api/J2/starating?score=12&score=9&score=5score=3&foul=4&foul=0&foul=2foul=0 -> Players who has been rated above 40 stars: 2 ,gold team is: False
        /// GET : api/J2/starating?score=9&score=10&foul=0&foul=1 -> Players who has been rated above 40 stars: 2 ,Team is gold team: True
        /// </example>

        [HttpGet(template: "starating")]
        public string starating([FromQuery] List<int> scored, [FromQuery] List<int> fouls)
        {
            int team_gold = 0;
            int total_players = scored.Count;
            int threshold = 40;

            for (int i = 0; i < total_players; i++)
            {
                int ratings = (5 * scored[i]) - (3 * fouls[i]);

                if (ratings >= threshold)
                {

                    team_gold++;
                }
            }
            bool in_team_gold = team_gold == total_players;
            return "Players who has been rate above 4o stars are: " + team_gold + " ,gold team is: " + in_team_gold;
        }
    }
}