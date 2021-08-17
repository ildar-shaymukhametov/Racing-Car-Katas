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
            var sensorValue = lowPressureThreshold - 1;
            var sensor = StubSensor(sensorValue);
            Alarm alarm = CreateSut(sensor, lowPressureThreshold);

            alarm.Check();

            Assert.True(alarm.AlarmOn);
        }

        [Fact]
        public void Alarm_count_is_initially_0()
        {
            var expectedAlarmCount = 0;
            Alarm alarm = CreateSut();
            Assert.Equal(expectedAlarmCount, alarm.AlarmCount);
        }

        [Fact]
        public void Alarm_is_on_if_sensor_value_passes_upper_threshold()
        {
            var highPressureThreshold = 10;
            var sensorValue = highPressureThreshold + 1;
            var sensor = StubSensor(sensorValue);
            Alarm alarm = CreateSut(sensor, highPressureThreshold: highPressureThreshold);

            alarm.Check();

            Assert.True(alarm.AlarmOn);
        }

        private static Alarm CreateSut(ISensor sensor = null, double lowPressureThreshold = default, double highPressureThreshold = default)
        {
            return new Alarm(sensor ?? Substitute.For<ISensor>(), lowPressureThreshold, highPressureThreshold);
        }

        private static ISensor StubSensor(int sensorValue)
        {
            var sensor = Substitute.For<ISensor>();
            sensor.PopNextPressurePsiValue().Returns(sensorValue);
            return sensor;
        }
    }
}