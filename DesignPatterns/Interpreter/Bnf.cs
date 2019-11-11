using System;
using System.Collections.Generic;

namespace Interpreter
{
    interface IBnfExpression
    {
        int Interpret(Dictionary<string, IBnfExpression> variables);
    }

    class Number : IBnfExpression
    {
        private readonly int number;
        public Number(int number) { this.number = number; }
        public int Interpret(Dictionary<string, IBnfExpression> variables) { return number; }
    }

    class Plus : IBnfExpression
    {
        private readonly IBnfExpression leftOperand;
        private readonly IBnfExpression rightOperand;

        public Plus(IBnfExpression left, IBnfExpression right)
        {
            leftOperand = left;
            rightOperand = right;
        }

        public int Interpret(Dictionary<string, IBnfExpression> variables)
        {
            return leftOperand.Interpret(variables) + rightOperand.Interpret(variables);
        }
    }

    class Minus : IBnfExpression
    {
        private readonly IBnfExpression leftOperand;
        private readonly IBnfExpression rightOperand;

        public Minus(IBnfExpression left, IBnfExpression right)
        {
            leftOperand = left;
            rightOperand = right;
        }

        public int Interpret(Dictionary<string, IBnfExpression> variables)
        {
            return leftOperand.Interpret(variables) - rightOperand.Interpret(variables);
        }
    }

    class Variable : IBnfExpression
    {
        private string name;
        public Variable(string name) { this.name = name; }
        public int Interpret(Dictionary<string, IBnfExpression> variables)
        {
            if (variables.ContainsKey(name))
            {
                return variables[name].Interpret(variables);
            }
            else
            {
                return 0; // Either return new Number(0).Interpret(variables)
            }
        }
    }

    // While the interpreter pattern does not address parsing, a parser is provided for completeness. 
    class Evaluator : IBnfExpression
    {
        private IBnfExpression syntaxTree;

        public Evaluator(string expression)
        {
            var expressionStack = new Stack<IBnfExpression>();
            
            string[] tokens = expression.Split(" ");
            
            foreach (string token in tokens)
            {
                if (token == "+")
                {
                    IBnfExpression subIBnfExpression = new Plus(expressionStack.Pop(), expressionStack.Pop());
                    expressionStack.Push(subIBnfExpression);
                }
                else if (token == "-")
                {
                    // it's necessary remove first the right operand from the stack
                    IBnfExpression right = expressionStack.Pop();
                    // ..and after the left one
                    IBnfExpression left = expressionStack.Pop();
                    IBnfExpression subIBnfExpression = new Minus(left, right);
                    expressionStack.Push(subIBnfExpression);
                }
                else
                {
                    expressionStack.Push(new Variable(token));
                }
            }
            syntaxTree = expressionStack.Pop();
        }

        public int Interpret(Dictionary<string, IBnfExpression> context)
        {
            return syntaxTree.Interpret(context);
        }
    }
}
