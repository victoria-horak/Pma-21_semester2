
namespace Adapter
{
    class ChargerAdapter : ICharger
    {
        private Charger _charger;

        public ChargerAdapter(Charger charger)
        {
            _charger = charger;
        }

        public void Charge()
        {
            Console.WriteLine("Using adapter to charge!");
            this._charger.Charge();
        }
    }
}
