using System;

namespace CreationalPatterns
{
    public class PrototypePattern
    {
        public void Execute()
        {
            IAircraftPrototype aircraftPrototype = new F16();

            // Creating new object using prototype
            IAircraftPrototype f16A = aircraftPrototype.Clone();
            f16A.SetEngine(new F16AEngine());

            // Creating new object using prototype
            IAircraftPrototype f16B = aircraftPrototype.Clone();
            f16B.SetEngine(new F16BEngine());
        }

        private interface IAircraftPrototype
        {
            public void Fly();

            public void SetEngine(Engine engine);

            public IAircraftPrototype Clone();
        }

        private class F16 : IAircraftPrototype
        {
            private F16Engine f16Engine = new F16Engine();

            public IAircraftPrototype Clone()
            {
                return new F16();
            }

            public void Fly()
            {
                Console.WriteLine("F16 is flying....");
            }

            public void SetEngine(Engine engine)
            {
                this.f16Engine = (F16Engine)engine;
            }
        }

        private class Engine
        { }

        private class F16Engine : Engine
        { }

        private class F16BEngine : F16Engine
        { }

        private class F16AEngine : F16Engine
        { }
    }
}
