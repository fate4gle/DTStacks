using DTStacks.DataType.Templates;
using DTStacks.DataType.ROS.Messages.std_msgs;

namespace DTStacks.DataType.ROS.Messages.sensor_msgs
{
    [System.Serializable]
    public class BatteryState : Message
    {
        public int POWER_SUPPLY_STATUS_UNKNOWN = 0;
        public int POWER_SUPPLY_STATUS_CHARGING = 1;
        public int POWER_SUPPLY_STATUS_DISCHARGING = 2;
        public int POWER_SUPPLY_STATUS_NOT_CHARGING = 3;
        public int POWER_SUPPLY_STATUS_FULL = 4;
        public int POWER_SUPPLY_HEALTH_UNKNOWN = 0;
        public int POWER_SUPPLY_HEALTH_GOOD = 1;
        public int POWER_SUPPLY_HEALTH_OVERHEAT = 2;
        public int POWER_SUPPLY_HEALTH_DEAD = 3;
        public int POWER_SUPPLY_HEALTH_OVERVOLTAGE = 4;
        public int POWER_SUPPLY_HEALTH_UNSPEC_FAILURE = 5;
        public int POWER_SUPPLY_HEALTH_COLD = 6;
        public int POWER_SUPPLY_HEALTH_WATCHDOG_TIMER_EXPIRE = 7;
        public int POWER_SUPPLY_HEALTH_SAFETY_TIMER_EXPIRE = 8;
        public int POWER_SUPPLY_TECHNOLOGY_UNKNOWN = 0;
        public int POWER_SUPPLY_TECHNOLOGY_NIMH = 1;
        public int POWER_SUPPLY_TECHNOLOGY_LION = 2;
        public int POWER_SUPPLY_TECHNOLOGY_LIPO = 3;
        public int POWER_SUPPLY_TECHNOLOGY_LIFE = 4;
        public int POWER_SUPPLY_TECHNOLOGY_NICD = 5;
        public int POWER_SUPPLY_TECHNOLOGY_LIMN = 6;
        public Header header;
        public float voltage;
        public float temperature;
        public float current;
        public float charge;
        public float capacity;
        public float design_capacity;
        public float percentage;
        public int power_supply_status;
        public int power_supply_health;
        public int power_supply_technology;
        public bool present;
        public float[] cell_voltage;
        public float[] cell_temperature;
        public string location;
        public string serial_number;
    }
}
