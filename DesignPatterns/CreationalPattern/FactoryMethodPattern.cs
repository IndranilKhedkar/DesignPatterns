using System;

namespace CreationalPatterns
{
    public class FactoryMethodPattern
    {
        public void Execute()
        {
            F16Factory f16Factory = new F16Factory();

            F16 f16A = f16Factory.MakeF16("A");
            f16A.Fly();

            F16 f16B = f16Factory.MakeF16("B");
            f16B.Fly();
        }

        private class F16Factory
        {
            public F16 MakeF16(string variant)
            {

                return variant switch
                {
                    "A" => new F16A(),
                    "B" => new F16B(),
                    _ => new F16()
                };
            }
        }

        private class F16
        {
            public IEngine engine;
            public ICockpit cockpit;

            public virtual F16 MakeF16()
            {
                engine = new F16Engine();
                cockpit = new F16Cockpit();
                return this;
            }

            public void Taxi()
            {
                Console.WriteLine("F16 is taxing on the runway !");
            }

            public void Fly()
            {
                // Note here carefully, the superclass F16 doesn't know
                // what type of F-16 variant it was returned.
                F16 f16 = MakeF16();
                f16.Taxi();
                Console.WriteLine("F16 is in the air !");
            }
        }

        private class F16A : F16
        {
            public override F16 MakeF16()
            {
                base.MakeF16();
                engine = new F16AEngine();
                return this;
            }
        }

        private class F16B : F16
        {
            public override F16 MakeF16()
            {
                base.MakeF16();
                engine = new F16BEngine();
                return this;
            }
        }

        private class F16Cockpit : ICockpit
        { }

        private class F16Engine : IEngine
        { }

        private class F16AEngine : F16Engine
        { }

        private class F16BEngine : F16Engine
        { }

        private interface IEngine
        { }

        private interface ICockpit
        { }
    }
}
