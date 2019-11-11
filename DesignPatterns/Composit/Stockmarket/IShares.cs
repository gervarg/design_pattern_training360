namespace Composit
{
    // Részvénycsomag
    internal interface IShares : IShare
    {
        void Add(IShare share);
    }
}