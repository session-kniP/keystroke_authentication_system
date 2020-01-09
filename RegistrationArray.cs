using System;

namespace KeyboardWriting
{
    class RegistrationArray
    {
        private int offset;
        private TimeSpan[] buffer;
        private int bufferSize;

        public RegistrationArray(int size)
        {
            offset = 0;
            bufferSize = size;
            buffer = new TimeSpan[size];
        }

        public void Add(TimeSpan value)
        {
            buffer[offset++] = value;
        }

        public void Pop()
        {
            offset--;
        }

        public double CountPerfect()
        {
            double perfect = 0;

            for (int i = 0; i < bufferSize; i++)
            {
                perfect += buffer[i].TotalMilliseconds + buffer[i].TotalSeconds * 1000;
            }
            return perfect /= bufferSize;
        }

        public int GetLength()
        {
            return bufferSize;
        }
    }
}
