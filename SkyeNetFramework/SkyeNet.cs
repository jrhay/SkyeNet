using System;
using System.Collections.Generic;
using System.Runtime.ExceptionServices;
using System.Runtime.InteropServices;
using System.Security;

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

        [DllImport("stapi", CallingConvention = CallingConvention.Cdecl)]
        static extern void SkyeTek_FreeReader(IntPtr lpReader);

        [DllImport("stapi", CallingConvention = CallingConvention.Cdecl)]
        static extern void SkyeTek_FreeDevice(IntPtr lpDevice);

        [DllImport("stapi", CallingConvention = CallingConvention.Cdecl)]
        static extern void SkyeTek_FreeTag(IntPtr lpTag);

        [DllImport("stapi", CallingConvention = CallingConvention.Cdecl)]
        static extern Status SkyeTek_GetTags(IntPtr lpReader, TagType tagType, ref IntPtr lpTags, ref UInt16 count);
        
        [DllImport("stapi", CallingConvention = CallingConvention.Cdecl)]
        static extern Status SkyeTek_FreeTags(IntPtr lpReader, IntPtr lpTags, UInt16 count);

        #endregion

        uint _numDevices = 0;
        IntPtr _Devices = IntPtr.Zero;

        uint _numReaders = 0;
        IntPtr _Readers = IntPtr.Zero;

        IntPtr _CurrentReader = IntPtr.Zero;

        uint _numTags = 0;
        IntPtr _Tags = IntPtr.Zero;

        Status _LastResult = Status.SUCCESS;
        Exception _LastException = null;

        /// <summary>
        /// The last operation result, for methods that set LastResult (as noted in their comments)
        /// </summary>
        public Status LastResult
        {
            get { return _LastResult; }
        }

        /// <summary>
        /// The last exception ecountered in the SkyTek API wrapper
        /// </summary>
        public Exception LastException
        {
            get { return _LastException; }
        }


        /// <summary>
        /// Set the current active RFID reader to be used for Tag 
        /// discovery/reading/programming, system parameters, etc.
        /// 
        /// Changing this value will immediately close and invalidate
        /// any currently-read tag or system data.
        /// </summary>
        public Reader ActiveReader
        {
            get
            {
                if (_CurrentReader == IntPtr.Zero)
                    return null;
                return Marshal.PtrToStructure<Reader>(_CurrentReader);
            }
            set
            {
                FreeTags();
                if (value == null)
                {
                    if (_CurrentReader != IntPtr.Zero)
                    {
                        Marshal.FreeHGlobal(_CurrentReader);
                        _CurrentReader = IntPtr.Zero;
                    }
                }
                else
                {
                    if (_CurrentReader == IntPtr.Zero)
                        _CurrentReader = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(Reader)));
                    Marshal.StructureToPtr(value, _CurrentReader, false);
                }
            }
        }


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
        /// The number of RFID tags the reader last saw
        /// </summary>
        public uint NumTags
        {
            get { return _numTags; }
        }

        /// <summary>
        /// Deallocate the internal list of RFID tags last seen
        /// </summary>
        private void FreeTags()
        {
            if (_Tags != IntPtr.Zero)
            {
                for (int i = 0; i < _numTags; i++)
                {
                    IntPtr Address = Marshal.ReadIntPtr(_Tags + (4 * i));
                    SkyeTek_FreeTag(Address);
                }
                if (_CurrentReader != IntPtr.Zero)
                    SkyeTek_FreeTags(_CurrentReader, _Tags, (UInt16)_numTags);

                _Tags = IntPtr.Zero;
                _numTags = 0;
            }
        }

        /// <summary>
        /// Deallocate the internal list of RFID readers
        /// </summary>
        private void FreeReaders()
        {
            if (_Readers != IntPtr.Zero)
            {
                for (int i = 0; i < _numReaders; i++)
                {
                    IntPtr Address = Marshal.ReadIntPtr(_Readers + (4 * i));
                    SkyeTek_FreeReader(Address);
                }
                SkyeTek_FreeReaders(_Readers, _numReaders);

                _Readers = IntPtr.Zero;
                _numReaders = 0;
                _CurrentReader = IntPtr.Zero;
            }
        }

        /// <summary>
        /// Deallocate the internal list of devices
        /// </summary>
        private void FreeDevices()
        {
            if (_Devices != IntPtr.Zero)
            {
                for (int i = 0; i < _numDevices; i++)
                {
                    IntPtr Address = Marshal.ReadIntPtr(_Devices + (4 * i));
                    SkyeTek_FreeDevice(Address);
                }
                SkyeTek_FreeDevices(_Devices, _numDevices);

                _Devices = IntPtr.Zero;
                _numDevices = 0;
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
                catch (Exception ex)
                {
                    _LastResult = Status.FAILURE;
                    _LastException = ex;
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
            try
            {
                _numDevices = SkyeTek_DiscoverDevices(ref _Devices);
            }
            catch (Exception ex)
            {
                _LastResult = Status.FAILURE;
                _LastException = ex;
            }
            return NumDevices;
        }

        /// <summary>
        /// Scan for any readable tags of the specified type, returning the number of tags discovered.
        /// Must be called after an active RFID reader has been set; throws InvalidOperationException if no reader is active.
        /// </summary>
        /// <param name="tagType">Scan for tags of this type</param>
        /// <returns>Number of nearby tags discovered, or 0 on any error (LastResult is set appropriately)</returns>
        //[HandleProcessCorruptedStateExceptions]
        //[SecurityCritical]
        public uint RefreshTags(TagType tagType)
        {
            FreeTags();

            if (_CurrentReader == IntPtr.Zero)
                throw new InvalidOperationException("An Active RFID Reader must be set before discovering tags");

            try
            {
                UInt16 numTags = 0;
                _LastResult = SkyeTek_GetTags(_CurrentReader, tagType, ref _Tags, ref numTags);
                //IntPtr Address = Marshal.ReadIntPtr(_Readers);
                //SkyeTek_GetTags(Address, 0x0000, ref _Tags, ref numTags);
                if (_LastResult == Status.SUCCESS)
                    _numTags = numTags;
                else
                    FreeTags();
            }
            catch (Exception ex)
            {
                _LastResult = Status.FAILURE;
                _LastException = ex;
                _numTags = 0;
            }

            return _numTags;
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
        /// Get a list of any nearby tags of the specified type.
        /// Must be called after an active RFID reader has been set; throws InvalidOperationException if no reader is active.
        /// </summary>
        /// <param name="tagType">Tag type to scan for, or empty for "Auto Detect"</param>
        /// <returns>List of tags discovered, will be empty with LastResult set appropriately on an error</returns>
        public IEnumerable<Tag> GetTags(TagType tagType = TagType.AUTO_DETECT)
        {
            RefreshTags(tagType);
            List<Tag> tags = new List<Tag>((int)NumTags);
            for (int i = 0; i < NumTags; i++)
                tags.Add(GetTag(i));
            return tags;
        }

        /// <summary>
        /// Return a specific Skyetek hardware device by index number
        /// Throws InvalidOperationException if no RFID devices have been found
        /// Throws IndexOutOfRangeException if index is out of range
        /// </summary>
        /// <param name="index">0-based index of device to return</param>
        /// <returns>Device information.</returns>
        public Device GetDevice(int index)
        {
            if (_Devices == IntPtr.Zero)
                throw new InvalidOperationException("No RFID hardware found");
            if ((index < 0) || (index >= NumDevices))
                throw new IndexOutOfRangeException("Invalid Device Index");
            IntPtr Address = Marshal.ReadIntPtr(_Devices + (4 * index));
            return Marshal.PtrToStructure<Device>(Address);
        }

        /// <summary>
        /// Return a specific Skyetek RFID tag reader by index number
        /// Throws InvalidOperationException if no RFID readers have been found
        /// Throws IndexOutOfRangeException if index is out of range
        /// </summary>
        /// <param name="index">0-based index of RFID reader to return</param>
        /// <returns>Reader information.</returns>
        public Reader GetReader(int index)
        {
            if (_Readers == IntPtr.Zero)
                throw new InvalidOperationException("No RFID readers found");
            if ((index < 0) || (index >= NumReaders))
                throw new IndexOutOfRangeException("Invalid Reader Index");
            IntPtr Address = Marshal.ReadIntPtr(_Readers + (4 * index));
            return Marshal.PtrToStructure<Reader>(Address);
        }

        /// <summary>
        /// Return a specific RFID tag by index number
        /// Must have recently-discovered tags loaded.  Throws InvalidOperationException if no tags have been discovered
        /// Throws IndexOutOfRangeException if index is out of range.
        /// </summary>
        /// <param name="index">0-based index of recently-disocered RFID tag to return</param>
        /// <returns>Tag information</returns>
        public Tag GetTag(int index)
        {
            if (_Tags == IntPtr.Zero)
                throw new InvalidOperationException("Can not read RFID tag: No tags have been discovered");
            if ((index < 0) || (index >= NumTags))
                throw new IndexOutOfRangeException("Invalid Tag Index");
            IntPtr Address = Marshal.ReadIntPtr(_Tags + (4 * index));
            return Marshal.PtrToStructure<Tag>(Address);
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
                    _LastException = null;
                }

                FreeTags();
                FreeReaders();
                FreeDevices();
                ActiveReader = null;

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
