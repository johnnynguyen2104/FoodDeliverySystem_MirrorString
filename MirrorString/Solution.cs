using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MirrorString
{
    public class Solution
    {
        public string MirrorString(string input)
        {
            Queue<char> result = new Queue<char>();

            if (!ValidateInput(input)
                || input.Length == 1
                || input[0] != input[input.Length - 1]
                )
            {
                return "";
            }

            for (int i = 0; i < input.Length / 2; i++)
            {
                if (input[i] == input[input.Length - (i + 1)])
                {
                    result.Enqueue(input[i]);
                }
                else
                {
                    break;
                }
            }

            return string.Join("", result);
        }

        private bool ValidateInput(string input)
        {
            if (!string.IsNullOrEmpty(input) && input.Trim().Length > 0)
            {
                return true;
            }

            return false;
        }
    }
}
