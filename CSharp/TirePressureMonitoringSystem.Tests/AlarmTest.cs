using NSubstitute;
using Xunit;

namespace TDDMicroExercises.TirePressureMonitoringSystem
{
    public class AlarmTest
    {
        [Fact]
        public void Alarm_is_not_initially_on()
        {
            Alarm alarm = CreateSut();
            Assert.False(alarm.AlarmOn);
        }

        [Fact]
        public void Sensor_value_passes_lower_threshold()
        {
            var lowPressureThreshold = 10;
            var sensor = Substitute.For<ISensor>();
            sensor.PopNextPressurePsiValue().Returns(lowPressureThreshold - 1);
            Alarm alarm = CreateSut(sensor, lowPressureThreshold);
            alarm.Check();
            Assert.True(alarm.AlarmOn);
        }

        private static Alarm CreateSut(ISensor sensor = null, double lowPressureThreshold = default)
        {
            return new Alarm(sensor ?? Substitute.For<ISensor>(), lowPressureThreshold);
        }
    }
}