using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.SpecFlowExample.Core
{
    public class BusinessLogicThingy
    {
        public string EnforceUppercaseRules(string inputText)
        {
            string output = string.Empty;
            inputText.Split(new []{ ' ' }).ToList().ForEach(word =>
                {
                    var tempWord = string.Empty;
                    for (var i = 0; i < word.Length; i++)
                        tempWord += (i == 0 && word.Length > 3) ? word[i].ToString().ToUpper() : word[i].ToString();

                    output += (output.Length == 0) ? tempWord : " " + tempWord;
                });
            return output;
        }
    }
}
