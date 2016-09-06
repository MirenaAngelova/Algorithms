using System;

namespace _04.Fast_and_Furious_2
{
    public class CarInfo : IComparable<CarInfo>
    {
        public CarInfo(string cameraName, DateTime recordingTime)
        {
            this.CameraName = cameraName;
            this.RecordingTime = recordingTime;
        }

        public DateTime RecordingTime { get; private set; }

        public string CameraName { get; private set; }

        public int CompareTo(CarInfo other)
        {
            return this.RecordingTime.CompareTo(other.RecordingTime);
        }
    }
}