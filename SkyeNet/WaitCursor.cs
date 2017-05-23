using System;
using System.Windows.Forms;

namespace SkyeNet
{
    /// <summary>
    /// Sets a wait cursor and implements IDisposable so that the cursor can be
    /// restored at the end of a using statement.
    /// Code from http://www.blackbeltcoder.com/Articles/winforms/implementing-a-waitcursor-class
    /// </summary>
    public class WaitCursor : IDisposable
    {
        public WaitCursor()
        {
            IsWaitCursor = true;
        }

        public void Dispose()
        {
            IsWaitCursor = false;
        }

        public bool IsWaitCursor
        {
            get
            {
                return Application.UseWaitCursor;
            }
            set
            {
                if (Application.UseWaitCursor != value)
                {
                    Application.UseWaitCursor = value;
                    Cursor.Current = value ? Cursors.WaitCursor : Cursors.Default;
                }
            }
        }
    }
}
