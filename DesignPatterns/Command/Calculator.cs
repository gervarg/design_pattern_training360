using System;
using System.Collections.Generic;

namespace Command
{
    abstract class Command
    {
        public abstract void Execute();
        public abstract void UnExecute();
    }

    class CalculatorCommand : Command
    {
        private readonly char @operator;
        private readonly int operand;
        private readonly Calculator calculator;

        public CalculatorCommand(Calculator calculator, char @operator, int operand)
        {
            this.calculator = calculator;
            this.@operator = @operator;
            this.operand = operand;
        }    

        public override void Execute()
        {
            calculator.Operation(@operator, operand);

        }

        public override void UnExecute()
        {
            calculator.Operation(Undo(@operator), operand);
        }


        // Returns opposite operator for given operator
        private char Undo(char @operator)
        {
            switch (@operator)
            {
                case '+': return '-';
                case '-': return '+';
                case '*': return '/';
                case '/': return '*';
                default:
                    throw new ArgumentException($"Invalid {nameof(@operator)}: {@operator}");
            }
        }
    }


    // The 'Receiver' class
    class Calculator
    {
        private int currentValue = 0;

        public void Operation(char @operator, int operand)
        {
            int oldValue = currentValue;

            switch (@operator)
            {
                case '+': currentValue += operand; break;
                case '-': currentValue -= operand; break;
                case '*': currentValue *= operand; break;
                case '/': currentValue /= operand; break;
            }

            Console.WriteLine($"{oldValue, -4} {@operator} {operand,-4} = {currentValue}");
        }
    }


    // The 'Invoker' class
    class User
    {
        private readonly Calculator calculator = new Calculator();
        private readonly List<Command> commands = new List<Command>();
        private int currentCommandIndex = 0;


        public void Redo(int levels)
        {
            Console.WriteLine("\n---- Redo {0} levels ", levels);

            // Perform redo operations
            for (int i = 0; i < levels; i++)
            {
                if (currentCommandIndex < commands.Count - 1)
                {
                    Command command = commands[currentCommandIndex++];
                    command.Execute();
                }
            }
        }


        public void Undo(int levels)
        {
            Console.WriteLine("\n---- Undo {0} levels ", levels);

            // Perform undo operations
            for (int i = 0; i < levels; i++)
            {
                if (currentCommandIndex > 0)
                {
                    Command command = commands[--currentCommandIndex] as Command;
                    command.UnExecute();
                }
            }
        }


        public void Compute(char @operator, int operand)
        {
            // Create command operation and execute it
            Command command = new CalculatorCommand(calculator, @operator, operand);
            command.Execute();

            // Add command to undo list
            commands.Add(command);

            currentCommandIndex++;
        }
    }
}