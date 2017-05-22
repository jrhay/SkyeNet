using System;
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

        public uint NumDevices
        {
            get { return _numDevices; }
        }

        public uint NumReaders
        {
            get { return _numReaders; }
        }

        private void FreeReaders()
        {
            if (_Readers != IntPtr.Zero)
            {
                SkyeTek_FreeReaders(_Readers, _numReaders);
                _Readers = IntPtr.Zero;
            }
        }

        private void FreeDevices()
        {
            if (_Devices != IntPtr.Zero)
            {
                SkyeTek_FreeDevices(_Devices, _numDevices);
                _Devices = IntPtr.Zero;
            }
        }

        public uint RefreshReaders()
        {
            FreeReaders();
            _numReaders = SkyeTek_DiscoverReaders(_Devices, NumDevices, ref _Readers);
            return NumReaders;
        }

        public uint RefreshDevices()
        {
            FreeDevices();
            _numDevices = SkyeTek_DiscoverDevices(ref _Devices);
            return NumDevices;
        }

        public Device GetDevice(int index)
        {
            if ((index < 0) || (index >= NumDevices))
                throw new IndexOutOfRangeException("Invalid Device Index");
            IntPtr Address = Marshal.ReadIntPtr(_Devices + (4 * index));
            return Marshal.PtrToStructure<Device>(Address);
        }

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
