using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace SkyeNet
{
    /// <summary>
    /// Class to represent a Skyetek hardware device
    /// </summary>
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto)]
    public class Device
    {
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 64)]
        public String friendly;

        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 64)]
        public String type;

        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 256)]
        public String address;

        public byte asynchronous;

        public UInt32 major;

        IntPtr readFD;

        IntPtr writeFD;

        IntPtr user;
        IntPtr internaldata;
    }
}
