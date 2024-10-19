using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace C__Assignment_2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class J1 : ControllerBase
    {
        /// Question-1
 
        /// <summary>
        /// It will calculates the final score in the game based on the number of collisions and deliveries.
        /// </summary>
        /// <returns>
        /// It will returns the final score in the game.
        /// </returns>
        /// <param name="Collisions">number of collisions with an obstacle. </param>
        /// <param name="Deliveries">number of packages delivered. </param>
        /// <remarks>
        /// Content-Type: application/x-www-form-urlencoded
        /// </remarks>
        /// <example>
        /// POST : api/J1/Delivedroid ->(Request Body: Collisions=5&Deliveries=10)  -> 950 
        /// POST : api/J1/Delivedroid ->(Request Body: Collisions=20&Deliveries=10) -> 300 
        /// POST : api/J1/Delivedroid ->(Request Body: Collisions=20&Deliveries=0)  -> -200 
        /// </example>

        [HttpPost(template: "Delivedroid")]
        public int Delivedroid([FromForm] int Collisions, [FromForm] int Deliveries)
        {
            int collisions_score = 10 * Collisions;
            int deliveries_score = 50 * Deliveries;
            int bonus_score = 500;
            int final_score;

            if (Deliveries > Collisions)
            {
                final_score = deliveries_score - collisions_score + bonus_score;
            }
            else
            {
                final_score = deliveries_score - collisions_score;
            }
            return final_score;
        }


        /// Question-2

        /// <summary>
        /// It will Calculates the number of cupcakes left based on the number of regular and small boxes.
        /// </summary>
        /// <returns>
        /// The number of cupcakes left.
        /// </returns>
        /// <param name="regularBoxes">The number of regular boxes.</param>
        /// <param name="smallBoxes">The number of small boxes.</param>
        /// <remarks>
        /// Each type of box can hold a specific number of cupcakes:
        /// regularbox of cupcake hold = 8 cupcake
        /// smallbox of cupcake hold = 3 cupcake
        /// </remarks>
        /// <example>
        /// POST : api/J1/cupcakeparty?regularbox=2&smallbox=5 ->  3 
        /// POST : api/J1/cupcakeparty?regularbox=2&smallbox=4 ->  0 
        /// POST : api/J1/cupcakeparty?regularbox=5&smallbox=3 ->  21 
        /// </example>

        [HttpPost(template: "cupcakeparty")]
        public int cupcakeparty([FromForm] int regularbox, [FromForm] int smallbox)
        {
            int cupcakeparty_regularbox = 8 * regularbox;
            int cupcakeparty_smallbox = 3 * smallbox;
            int total_students = 28;

            int total_cupcake_left = (cupcakeparty_regularbox + cupcakeparty_smallbox) - total_students;
            return total_cupcake_left;
        }

    }
}
