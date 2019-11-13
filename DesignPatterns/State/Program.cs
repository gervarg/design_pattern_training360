using System;
using static System.Console;

namespace State
{
    // Summary:
    // * It lets you change the behavior of a class when the state changes.
    // * The state pattern implements a state machine in an object-oriented way. 
    // This state machine is implemented by implementing each individual state 
    // as a derived class of the state pattern interface, and implementing state transitions 
    // by invoking methods defined by the pattern's superclass. 
    // * This pattern is frequently used in game programming.
    // * Protocol implementations. 
    class Program
    {
        static void Main(string[] args)
        {
            //TextEditorExample();

            //BrushExample();

            //DbConnection();

            MarioExample();
        }

        private static void TextEditorExample()
        {
            var textEditor = new TextEditor();
            textEditor.Type("First line");

            textEditor.WritingState = new UpperCaseState();
            textEditor.Type("Second line");
            textEditor.Type("Third line");

            textEditor.WritingState = new LowerCaseState();
            textEditor.Type("Fourth line");
            textEditor.Type("Fifth line");
        }

        private static void BrushExample()
        {
            var brush = new Brush();
            brush.Draw("line");

            brush.ColoredBrush = new RedBrush();
            brush.Draw("circle");

            brush.ColoredBrush = new BlueBrush();
            brush.Draw("square");

            // Q: howto change state?
            //  * cache objects?
            //  * visibility?
        }

        private static void DbConnection()
        {
            try
            {
                var dbConnection = new DbConnection();
                dbConnection.Open();
                dbConnection.ExecuteQuery("SELECT * FROM Users");
                dbConnection.ExecuteQuery("SELECT * FROM Products");
                dbConnection.Close();
                dbConnection.ExecuteQuery("SELECT * FROM Users");
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception.Message);
            }

        }

        private static void MarioExample()
        {
            Mario mario = new Mario();
            WriteLine(mario);

            mario.GotMushroom();
            WriteLine(mario);

            mario.GotFireFlower();
            WriteLine(mario);

            mario.GotFeather();
            WriteLine(mario);

            mario.GotCoins(4800);
            WriteLine(mario);

            mario.MetMonster();
            WriteLine(mario);

            mario.MetMonster();
            WriteLine(mario);

            mario.MetMonster();
            WriteLine(mario);
        }
    }
}
