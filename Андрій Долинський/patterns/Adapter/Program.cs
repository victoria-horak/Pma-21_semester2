using Adapter;
class Program
{
    static void Main(string[] args)
    {
        Charger charger = new Charger();

        ChargerAdapter adapter = new ChargerAdapter(charger);

        adapter.Charge();
    }
}