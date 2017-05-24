using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace SkyeNet
{
    /// <summary>
    /// Class to represent a Skyetek RFID Reader
    /// </summary>
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto, Pack = 8)]
    public class Reader
    {
        // Skyetek API Reader struct marshaling

        IntPtr id;

        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 128)]
        public String model;

        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 128)]
        public String serialNumber;

        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 128)]
        public String firmware;

        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 128)]
        public String manufacturer;

        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 128)]
        public String rid;

        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 128)]
        public String readerName;

        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 256)]
        public String friendly;

        byte isBootload;
        byte sendRID;

        IntPtr protocol;
        IntPtr device;

        IntPtr user;
        IntPtr internaldata;

        // Class Methods

        public override string ToString()
        {
            if (!String.IsNullOrEmpty(readerName))
                return readerName;

            if (!String.IsNullOrEmpty(friendly))
                return friendly;

            if (!String.IsNullOrEmpty(manufacturer) || !String.IsNullOrEmpty(model))
                return manufacturer + " " + model;

            if (!String.IsNullOrEmpty(serialNumber))
                return serialNumber;

            return "RFID Reader ";
        }

    }
}
