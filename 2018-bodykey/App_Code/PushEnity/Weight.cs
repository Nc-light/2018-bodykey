using System;
using System.Collections;

namespace bodykey.App_Code.PushEnity
{
    public class Weight
    {
        public string dataType { get; set; }

        public WeightDatas data { get; set; }
    }

    public class WeightDatas
    {
        public string deviceId { get; set; }
        public string sn { get; set; }

        public int userNo { get; set; }
        public double weight { get; set; }

        public double bmi { get; set; }
        public double pbf { get; set; }
        public double muscle { get; set; }
        public double bone { get; set; }
        public double water { get; set; }

        public double resistance { get; set; }
        public string measurementDate { get; set; }
    }
}
