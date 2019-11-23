namespace RandomImageViewer.Interfaces
{
    /// <summary>
    /// Interface to implement some random generator
    /// </summary>
    public interface IRandomGenerator
    {
        int Next(int maxValue);
    }
}
