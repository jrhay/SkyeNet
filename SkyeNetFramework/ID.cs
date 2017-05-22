using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace SkyeNet
{
    /// <summary>
    /// Class to represent a Skyetek ID
    /// </summary>
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto)]
    public class ID
    {
        IntPtr id;
        UInt32 length;
    }
}
