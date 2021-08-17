using NSubstitute;
using Xunit;

namespace TDDMicroExercises.TirePressureMonitoringSystem
{
    public class AlarmTest
    {
        [Fact]
        public void Alarm_is_not_initially_on()
        {
            Alarm alarm = new Alarm(default, default);
            Assert.False(alarm.AlarmOn);
        }

        [Fact]
        public void Sensor_value_passes_lower_threshold()
        {
            var lowPressureThreshold = 10;
            var sensor = Substitute.For<ISensor>();
            sensor.PopNextPressurePsiValue().Returns(lowPressureThreshold - 1);
            Alarm alarm = new Alarm(sensor, lowPressureThreshold);
            alarm.Check();
            Assert.True(alarm.AlarmOn);
        }
    }
}