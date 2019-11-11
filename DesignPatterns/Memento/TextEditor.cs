using System.Text;

namespace Memento
{
    class EditorMemento
    {
        public EditorMemento(string content)
        {
            Content = content;
        }

        public string Content { get; }
    }

    class Editor
    {
        private readonly StringBuilder editorContent = new StringBuilder();

        public void Type(string words)
        {
            editorContent.Append(words);
        }

        public string Content => editorContent.ToString();

        public EditorMemento Save()
        {
            return new EditorMemento(Content); // or with new StringBuilder
        }

        public void Restore(EditorMemento editorMemento)
        {
            editorContent.Clear();
            editorContent.Append(editorMemento.Content);
        }
    }
}
