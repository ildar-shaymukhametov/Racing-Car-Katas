namespace TDDMicroExercises.TirePressureMonitoringSystem
{
    public class Alarm
    {
        public Alarm(ISensor sensor, double lowPressureThreshold)
        {
            _sensor = sensor;
            _lowPressureThreshold = lowPressureThreshold;
        }

        private readonly double _lowPressureThreshold;
        private const double HighPressureThreshold = 21;

        private readonly ISensor _sensor;

        bool _alarmOn = false;
        private long _alarmCount = 0;


        public void Check()
        {
            double psiPressureValue = _sensor.PopNextPressurePsiValue();

            if (psiPressureValue < _lowPressureThreshold || HighPressureThreshold < psiPressureValue)
            {
                _alarmOn = true;
                _alarmCount += 1;
            }
        }

        public bool AlarmOn
        {
            get { return _alarmOn; }
        }
    }
}
