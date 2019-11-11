using System;
using System.Collections.Generic;

namespace Interpreter
{
    // Summary:
    // Interpreter pattern provides a way to evaluate language grammar or expression. 
    // This pattern involves implementing an expression interface which tells to interpret a particular context. 
    // This pattern is used in SQL parsing, symbol processing engine etc.
    // Expression tree
    class Program
    {
        static void Main(string[] args)
        {
            //QuestionAnalyzerExample();
            BnfExample();
        }

        private static void QuestionAnalyzerExample()
        {
            IExpression isMale = GetMaleExpression();
            IExpression isMarriedWoman = GetMarriedWomanExpression();

            string question1 = "John is male?";
            Console.WriteLine($"{question1} {isMale.Interpret(question1)}");

            string question2 = "Julie is a married women?";
            Console.WriteLine($"{question2} {isMarriedWoman.Interpret(question2)}");

            #region Task
            string question3 = "Julie is not a married women?";
            Console.WriteLine($"{question3} {isMarriedWoman.Interpret(question3)}");
            #endregion



            //Rule: Robert and John are male
            IExpression GetMaleExpression()
            {
                IExpression robert = new TerminalExpression("Robert");
                IExpression john = new TerminalExpression("John");
                return new OrExpression(robert, john);
            }

            //Rule: Julie is a married women
            IExpression GetMarriedWomanExpression()
            {
                IExpression julie = new TerminalExpression("Julie");
                IExpression married = new TerminalExpression("Married");
                return new AndExpression(julie, married);
            }
        }        

        private static void BnfExample()
        {
            /*  A következő "Backus-Naur-Formula" (BNF) példa illusztrálja az interpreter mintát.
                https://hu.wikipedia.org/wiki/%C3%89rtelmez%C5%91_programtervez%C3%A9si_minta
                
                A nyelvtan:
                    expression ::= plus | minus | variable | number
                    plus ::= expression expression '+'
                    minus ::= expression expression '-'
                    variable  ::= 'a' | 'b' | 'c' | ... | 'z'
                    digit = '0' | '1' | ... | '9'
                    number ::= digit | digit number

                Definiál egy nyelvet, amellyel a fordított lengyel jelöléssel lehet kifejezéseket megadni. Például az alábbiakat:
                    a b +
                    a b c + -
                    a b + c a - -
            */

            string expression = "w x z - +";
            Evaluator sentence = new Evaluator(expression);
            var variables = new Dictionary<string, IBnfExpression>();
            variables.Add("w", new Number(5));
            variables.Add("x", new Number(10));
            variables.Add("z", new Number(42));
            int result = sentence.Interpret(variables);
            Console.WriteLine(result);
        }
    }
}
