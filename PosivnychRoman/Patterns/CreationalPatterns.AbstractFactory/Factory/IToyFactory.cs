using CreationalPatterns.Toys;

namespace CreationalPatterns.Factory
{
    internal interface IToyFactory
    {
        Bear GetBear();
        Cat GetCat();
    }
}
