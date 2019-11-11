namespace Composit
{
    internal interface ICompositItem : IItem
    {
        void Add(IItem item);
    }
}