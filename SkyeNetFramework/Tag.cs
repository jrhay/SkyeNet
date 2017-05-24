using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace SkyeNet
{
    /// <summary>
    /// Class to represent a Skyetek RFID Tag
    /// </summary>
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto, Pack = 8)]
    public class Tag
    {
        // SkyeTek API Tag struct marshaling

        public TagType type;

        public IntPtr id;

        public UInt16 afi;

        public UInt16 session;

        public byte rf;

        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 128)]
        public String friendly;

        IntPtr user;
        IntPtr internaldata;

        // Class Methods

        public override string ToString()
        {
            return friendly;
        }
    }
}
