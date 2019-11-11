using System;

namespace Memento
{
    // Summary:
    // Memento pattern is about capturing and storing the current state of an object 
    // in a manner that it can be restored later on in a smooth manner.
    // Usually useful when you need to provide some sort of undo functionality.
    class Program
    {
        static void Main(string[] args)
        {
            TextEditorExample();
        }

        private static void TextEditorExample()
        {
            var editor = new Editor();

            editor.Type("This is the design patterns course. ");
            EditorMemento saveState1 = editor.Save();

            editor.Type("This is the memento pattern. ");
            EditorMemento saveState2 = editor.Save();

            editor.Type("Any question?");


            Console.WriteLine(editor.Content);
            editor.Restore(saveState2);
            Console.WriteLine(editor.Content);
            editor.Restore(saveState1);
            Console.WriteLine(editor.Content);
        }
    }
}
