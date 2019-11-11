using System;

namespace Interpreter
{
    interface IExpression
    {
        public bool Interpret(string context);
    }

    public class TerminalExpression : IExpression
    {
        private readonly string data;

        public TerminalExpression(string data)
        {
            this.data = data;
        }

        public bool Interpret(string context)
        {
            return context.Contains(data, StringComparison.OrdinalIgnoreCase);
        }
    }

    class OrExpression : IExpression
    {
        private readonly IExpression expression1 = null;
        private readonly IExpression expression2 = null;

        public OrExpression(IExpression expression1, IExpression expression2)
        {
            this.expression1 = expression1;
            this.expression2 = expression2;
        }

        public bool Interpret(string context)
        {
            return expression1.Interpret(context) || expression2.Interpret(context);
        }
    }

    class AndExpression : IExpression
    {
        private readonly IExpression expression1 = null;
        private readonly IExpression expression2 = null;

        public AndExpression(IExpression expression1, IExpression expression2)
        {
            this.expression1 = expression1;
            this.expression2 = expression2;
        }

        public bool Interpret(string context)
        {
            return expression1.Interpret(context) && expression2.Interpret(context);
        }
    }
}
