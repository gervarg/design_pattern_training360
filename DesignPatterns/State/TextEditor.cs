using System;

namespace State
{
    interface IWritingState
    {
        void Write(string words);
    }

    class UpperCaseState : IWritingState
    {
        public void Write(string words)
        {
            Console.WriteLine(words.ToUpper());
        }
    }

    class LowerCaseState : IWritingState
    {
        public void Write(string words)
        {
            Console.WriteLine(words.ToLower());
        }
    }

    class DefaultState : IWritingState
    {
        public void Write(string words)
        {
            Console.WriteLine(words);
        }
    }

    class TextEditor
    {
        public IWritingState WritingState { get; set; } = new DefaultState();
       
        public void Type(string words)
        {
            WritingState.Write(words);
        }
    }
}
