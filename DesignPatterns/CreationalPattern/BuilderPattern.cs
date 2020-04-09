namespace CreationalPatterns
{
    public class BuilderPattern
    {
        public void Execute()
        {
            Boeing747Builder boeing747Builder = new Boeing747Builder();
            Director boing747Director = new Director(boeing747Builder);
            boing747Director.ConstructAircraft(true);
            IAircraft boeing747 = boeing747Builder.GetResult();

            F16Builder f16Builder = new F16Builder();
            Director f16Director = new Director(f16Builder);
            f16Director.ConstructAircraft(false);
            IAircraft f16 = f16Builder.GetResult();
        }
    }

    public interface IAircraft
    {
    }

    public class Boeing747 : IAircraft
    {
    }

    public class F16 : IAircraft
    {
    }

    public class Director
    {
        private readonly AircraftBuilder _aircraftBuilder;

        public Director(AircraftBuilder aircraftBuilder)
        {
            _aircraftBuilder = aircraftBuilder;
        }

        public void ConstructAircraft(bool isPassenger)
        {
            _aircraftBuilder.BuildCockpit();
            _aircraftBuilder.BuildEngine();
            _aircraftBuilder.BuildWings();

            if (isPassenger)
            {
                _aircraftBuilder.BuildBathrooms();
            }
        }
    }

    public abstract class AircraftBuilder
    {
        public virtual void BuildEngine()
        { }

        public virtual void BuildWings()
        { }

        public virtual void BuildCockpit()
        { }

        public virtual void BuildBathrooms()
        { }

        abstract public IAircraft GetResult();
    }

    public class Boeing747Builder : AircraftBuilder
    {
        private Boeing747 _boeing747;

        public override void BuildCockpit()
        { }

        public override void BuildEngine()
        { }

        public override void BuildBathrooms()
        { }

        public override void BuildWings()
        { }

        public override IAircraft GetResult()
        {
            return _boeing747;
        }
    }

    public class F16Builder : AircraftBuilder
    {
        private F16 f16;

        public override void BuildEngine()
        {
            // get F-16 an engine
            // f16.engine = new F16Engine();
        }

        public override void BuildWings()
        {
            // get F-16 wings
            // f16.wings = new F16Wings();
        }

        public override void BuildCockpit()
        {
            // f16 = new F16();
            // get F-16 a cockpit
            // f16.cockpit = new F16Cockpit();
        }

        public override IAircraft GetResult()
        {
            return f16;
        }
    }
}
