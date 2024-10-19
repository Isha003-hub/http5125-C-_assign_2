using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace C__Assignment_2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class J3 : ControllerBase
    {
        /// <summary>
        /// Decodes a list of five-digit sequences into instructions, including direction from the first two digits and steps from the last three digits.
        /// </summary>
        /// <param name="instructionCodes">A list of five-digit string sequences representing the instructions.</param>
        /// <returns>list of decoded instructions along with direction and steps.</returns>
        /// <method>
        /// As an input it will take a list of strings called `instructionCodes`. 
        /// The process first checks if the first sequence in the list is "STOP"; 
        ///if it is, the loop halts immediately, and no further processing occurs. Each sequence is checked to ensure it contains exactly five alphanumeric characters.
        /// If a sequence does not meet this condition, an error message "Invalid instruction format" is returned.
        /// For valid sequences, the first three characters are extracted and interpreted as a code for movement direction:
        /// - If the sum of their ASCII values is even, the direction is "right."
        /// - If the sum is odd, the direction is "left."
        /// - If all three characters are identical, the direction repeats the last valid one.
        /// The last two characters represent the steps, which are extracted using `.Substring(3)`.
        /// Finally, the direction and the number of steps are returned as the decoded instruction.
        /// </method>
        /// <example>
        /// GET: api/J3/codes?instructionCodes=45715&instructionCodes=54821&instructionCodes=00861&instructionCodes=99999 
        /// left 715
        /// left 821
        /// left 861
        /// </example>

        [HttpGet(template: "codes")]
        public string codes([FromQuery] List<string> instructionCodes)
        {
            string final_result = "";
            string predirection = "";
            foreach (var num in instructionCodes)
            {
                if (num == "99999")
                {
                    break;
                }
                if (num.Length != 5)
                {
                    final_result += "Please enter five digits only.\n";
                    continue;
                }
                int f_digit = int.Parse(num.Substring(0, 1));
                int s_digit = int.Parse(num.Substring(1, 1));
                int sum = f_digit + s_digit;
                string total_steps = num.Substring(2);
                string final_direction = "";

                if (sum == 0)
                {
                    final_direction = predirection;
                }
                else if ((sum % 2) != 0)
                {
                    final_direction = "left";
                }
                else
                {
                    final_direction = "right";
                }
                final_result += $"{final_direction} {total_steps}\n";
                predirection = final_direction;
            }
            return final_result;
        }
    }
}


           
