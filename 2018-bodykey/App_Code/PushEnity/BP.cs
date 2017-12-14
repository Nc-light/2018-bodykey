using System;
namespace bodykey.App_Code.PushEnity
{
    public class BP
    {
        public string dataType { get; set; }

        public BpDatas data { get; set; }
    }

    public class BpDatas
    {
        public string deviceId { get; set; }
        public string sn { get; set; }

        public int userNo { get; set; }

        public double diastolicPressure { get; set; }
        public double systolicPressure { get; set; }
        public int heartRate { get; set; }
        public bool irregularHeartbeat { get; set; }
        public bool movementError { get; set; }

        public string measurementDate { get; set; }
    }
}
