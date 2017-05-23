using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace SkyeNet
{
    /// <summary>
    /// .NET Wrapper of SkyeTek C API for Windows.
    /// </summary>
    public class SkyeNet : IDisposable
    {
        #region P/Invoke Signatures

        [DllImport("stapi", CallingConvention = CallingConvention.Cdecl)]
        static extern UInt32 SkyeTek_DiscoverDevices(ref IntPtr lpDevices);

        [DllImport("stapi", CallingConvention = CallingConvention.Cdecl)]
        static extern void SkyeTek_FreeDevices(IntPtr lpDevices, UInt32 count);

        [DllImport("stapi", CallingConvention = CallingConvention.Cdecl)]
        static extern UInt32 SkyeTek_DiscoverReaders(IntPtr lpDevices, UInt32 deviceCount, ref IntPtr lpReaders);

        [DllImport("stapi", CallingConvention = CallingConvention.Cdecl)]
        static extern void SkyeTek_FreeReaders(IntPtr lpReaders, UInt32 count);

        #endregion

        uint _numDevices = 0;
        IntPtr _Devices = IntPtr.Zero;

        uint _numReaders = 0;
        IntPtr _Readers = IntPtr.Zero;

        /// <summary>
        /// The number of SkyeTek hardware devices currently attached
        /// </summary>
        public uint NumDevices
        {
            get { return _numDevices; }
        }

        /// <summary>
        /// The number of RFID Tag readers currently attached
        /// </summary>
        public uint NumReaders
        {
            get { return _numReaders; }
        }

        /// <summary>
        /// Deallocate the internal list of RFID readers
        /// </summary>
        private void FreeReaders()
        {
            if (_Readers != IntPtr.Zero)
            {
                SkyeTek_FreeReaders(_Readers, _numReaders);
                _Readers = IntPtr.Zero;
            }
        }

        /// <summary>
        /// Deallocate the internal list of devices
        /// </summary>
        private void FreeDevices()
        {
            if (_Devices != IntPtr.Zero)
            {
                SkyeTek_FreeDevices(_Devices, _numDevices);
                _Devices = IntPtr.Zero;
            }
        }

        /// <summary>
        /// Check all attached devices for RFID tag readers and refresh the internal list of attached readers.
        /// Calls SkyeTek API function SkyeTek_DiscoverReaders()
        /// </summary>
        /// <param name="device">Device to limit the RFID reader search to, null or omitted for "all devices"</param>
        /// <returns>Count of RFID tag readers currently attached to the system</returns>
        public uint RefreshReaders(Device device = null)
        {
            FreeReaders();
            if (device == null)
                _numReaders = SkyeTek_DiscoverReaders(_Devices, NumDevices, ref _Readers);
            else
            {
                IntPtr devicePtr = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(Device)));
                IntPtr deviceArray = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(IntPtr)));
                try
                {
                    Marshal.StructureToPtr(device, devicePtr, false);
                    Marshal.WriteIntPtr(deviceArray, devicePtr);
                    _numReaders = SkyeTek_DiscoverReaders(deviceArray, 1, ref _Readers);
                }
                finally
                {
                    Marshal.FreeHGlobal(deviceArray);
                    Marshal.FreeHGlobal(devicePtr);
                }
            }
            return NumReaders;
        }

        /// <summary>
        /// Check the hardware connections and refresh the internal list of attached
        /// SkyeTek hardware devices.
        /// Calls SkyeTek API function SkyeTek_DiscoverDevices()
        /// </summary>
        /// <returns>Count of devices Skyetek hardware devices currently attached to the system</returns>
        public uint RefreshDevices()
        {
            FreeDevices();
            _numDevices = SkyeTek_DiscoverDevices(ref _Devices);
            return NumDevices;
        }

        /// <summary>
        /// Get a list of all found Skyetek hardware devices currently attached to the system
        /// Calls RefreshDevices()
        /// </summary>
        /// <returns>List of Device instances</returns>
        public IEnumerable<Device> GetDevices()
        {
            RefreshDevices();
            List<Device> devices = new List<Device>((int)NumDevices);
            for (int i = 0; i < NumDevices; i++)
                devices.Add(GetDevice(i));
            return devices;
        }

        /// <summary>
        /// Get a list of all found RFID readers, optionally limiting to just readers on a particular
        /// Skyetek hardware device.  GetDevices() or RefreshDevices() should be called before calling this method.
        /// </summary>
        /// <param name="device">Device to limit the RFID reader search to, null or omitted for "all devices"</param>
        /// <returns></returns>
        public IEnumerable<Reader> GetReaders(Device device = null)
        {
            RefreshReaders(device);
            List<Reader> readers = new List<Reader>((int)NumReaders);
            for (int i = 0; i < NumReaders; i++)
                readers.Add(GetReader(i));
            return readers;
        }

        /// <summary>
        /// Return a specific Skyetek hardware device by index number
        /// </summary>
        /// <param name="index">0-based index of device to return</param>
        /// <returns>Device information.  Throws an IndexOutOfRangeException if index is out of range</returns>
        public Device GetDevice(int index)
        {
            if ((index < 0) || (index >= NumDevices))
                throw new IndexOutOfRangeException("Invalid Device Index");
            IntPtr Address = Marshal.ReadIntPtr(_Devices + (4 * index));
            return Marshal.PtrToStructure<Device>(Address);
        }

        /// <summary>
        /// Return a specific Skyetek RFID tag reader by index number
        /// </summary>
        /// <param name="index">0-based index of RFID reader to return</param>
        /// <returns>Reader information.  Throws IndexOutOfRangeException if index is out of range</returns>
        public Reader GetReader(int index)
        {
            if ((index < 0) || (index >= NumReaders))
                throw new IndexOutOfRangeException("Invalid Reader Index");
            IntPtr Address = Marshal.ReadIntPtr(_Readers + (4 * index));
            return Marshal.PtrToStructure<Reader>(Address);
        }


        #region IDisposable Support
        private bool disposedValue = false; // To detect redundant calls

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    // TODO: dispose managed state (managed objects).
                }

                FreeReaders();
                FreeDevices();

                disposedValue = true;
            }
        }

        ~SkyeNet()
        {
            // Do not change this code. Put cleanup code in Dispose(bool disposing) above.
            Dispose(false);
        }

        public void Dispose()
        {
            // Do not change this code. Put cleanup code in Dispose(bool disposing) above.
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        #endregion
    }
}
