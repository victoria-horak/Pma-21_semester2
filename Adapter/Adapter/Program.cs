using System;


namespace Adapter
{
    interface IScales
    {
        float GetWeight();
        void Adjust();
    }
    class EuropeanScales: IScales
    {
        float currentWeight; //private

        public EuropeanScales(float currentWeight)
        {
            this.currentWeight = currentWeight;
        }
        public void Adjust() => Console.WriteLine("Regulation of european scales!");
        public float GetWeight() => currentWeight;
    }

    class BritishScales
    {
        private float currentWeight;
        public BritishScales(float currentWeight)
        {
            this.currentWeight = currentWeight;
        }
        protected void Adjust() => Console.WriteLine("Regulation of British Scales!");
        public float GetWeight() => currentWeight;

    }

    class AdapterForBritishScales: BritishScales, IScales
    {
        public AdapterForBritishScales(float cw): base(cw) { }
        float IScales.GetWeight()
        {
            return base.GetWeight() * 0.453f;
        }
        void IScales.Adjust()
        {
            base.Adjust();
            Console.WriteLine(" in the adapter pattern Adjust() method");

        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            IScales EScales = new EuropeanScales(55.0f);
            IScales bScales = new AdapterForBritishScales(55.0f);

            Console.WriteLine(EScales.GetWeight());
            Console.WriteLine(bScales.GetWeight());

            EScales.Adjust();
            bScales.Adjust();
        }
    }
}
