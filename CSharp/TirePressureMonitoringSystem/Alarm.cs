namespace TDDMicroExercises.TirePressureMonitoringSystem
{
    public class Alarm
    {
        public Alarm(ISensor sensor, double lowPressureThreshold, double highPressureThreshold)
        {
            _sensor = sensor;
            _lowPressureThreshold = lowPressureThreshold;
            _highPressureThreshold = highPressureThreshold;
        }

        private readonly double _lowPressureThreshold;
        private readonly double _highPressureThreshold;

        private readonly ISensor _sensor;

        bool _alarmOn = false;
        private long _alarmCount = 0;


        public void Check()
        {
            double psiPressureValue = _sensor.PopNextPressurePsiValue();

            if (psiPressureValue < _lowPressureThreshold || _highPressureThreshold < psiPressureValue)
            {
                _alarmOn = true;
                _alarmCount += 1;
            }
        }

        public bool AlarmOn
        {
            get { return _alarmOn; }
        }

        public long AlarmCount
        {
            get { return _alarmCount; }
        }
    }
}
