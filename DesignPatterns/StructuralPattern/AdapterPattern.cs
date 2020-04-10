namespace StructuralPatterns
{
    public class AdapterPattern
    {
        public void Execute()
        {
            HotAirBalloon hotAirBalloon = new HotAirBalloon();
            Adapter adapter = new Adapter(hotAirBalloon);
            adapter.Fly();
        }

        private interface IAircraft
        {
            public void Fly();
        }

        private class HotAirBalloon
        {
            private readonly string _gasUsed = "Helium";

            public void Fly(string gasUsed)
            {
                // Take-off sequence based on the kind of feul
                // Followed by more code.  
            }

            // Function returns the gas used by the balloon for flight
            public string InflateWithGas()
            {
                return _gasUsed;
            }
        }

        private class Adapter : IAircraft
        {
            private readonly HotAirBalloon _hotAirBallon;

            public Adapter(HotAirBalloon hotAirBalloon)
            {
                _hotAirBallon = hotAirBalloon;
            }

            public void Fly()
            {
                var fuelUsed = _hotAirBallon.InflateWithGas();
                _hotAirBallon.Fly(fuelUsed);
            }
        }
    }
}
