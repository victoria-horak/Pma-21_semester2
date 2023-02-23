
namespace Lightweight
{
    public class LightShape : BaseShape
    {
        private IHeavyShape _heavyShape;

        public LightShape(int x, int y, int size, string color) : base(x, y, size)
        {
            _heavyShape = new HeavyShape(color);
        }

        public override void Draw()
        {
            base.Draw();
            _heavyShape.Draw(X, Y, Size);
        }
    }
}
