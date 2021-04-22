
using System;
using System.Text;
using System.Runtime.InteropServices;

namespace lab4_1
{
    class ComputerInformation
    {
        [DllImport("kernel32.dll")]
        public static extern int GetComputerName(StringBuilder buffer, ref int sizeBuffer);

        [DllImport("kernel32.dll")]
        public static extern int GetWindowsDirectory(StringBuilder buffer, ref int sizeBuffer);

      
        [StructLayout(LayoutKind.Sequential)]
        public struct SYSTEM_INFO
        {
            public ushort wProcessorArchitecture;
            public ushort wReserved;
            public uint dwPageSize;
            public IntPtr lpMinimumApplicationAddress;
            public IntPtr lpMaximumApplicationAddress;
            public IntPtr dwActiveProcessorMask;
            public uint dwNumberOfProcessors;
            public uint dwProcessorType;
            public uint dwAllocationGranularity;
            public ushort wProcessorLevel;
            public ushort wProcessorRevision;
        }

        [DllImport("kernel32.dll")]
        public static extern void GetSystemInfo(out SYSTEM_INFO info);
    }
    class Program
    {
        static void Main(string[] args)
        {
            StringBuilder bufferForComputerName = new StringBuilder(16);
            int lenght1 = bufferForComputerName.Capacity;
            ComputerInformation.GetComputerName(bufferForComputerName, ref lenght1);
            Console.WriteLine($"Computer name: {bufferForComputerName}");

            StringBuilder bufferForWindowsDirectory = new StringBuilder(16);
            int lenght4 = bufferForWindowsDirectory.Capacity;
            ComputerInformation.GetWindowsDirectory(bufferForWindowsDirectory, ref lenght4);
            Console.WriteLine($"Windows Directory: {bufferForWindowsDirectory}");

            ComputerInformation.SYSTEM_INFO info;
            ComputerInformation.GetSystemInfo(out info);
            string typeOfProcessor;
            switch (info.wProcessorArchitecture)
            {
                case 0:
                    typeOfProcessor = "Intel x86";
                    break;
                case 5:
                    typeOfProcessor = "ARM";
                    break;
                case 6:
                    typeOfProcessor = "IA64 Intel Itanium-based";
                    break;
                case 9:
                    typeOfProcessor = "AMD64 x64 (AMD or Intel)";
                    break;
                case 12:
                    typeOfProcessor = "ARM64";
                    break;
                default:
                    typeOfProcessor = "Unknown architecture.";
                    break;
            }
            Console.WriteLine($"Type of Processor: {typeOfProcessor}");
        }
    }
}