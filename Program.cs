using System;
using System.Net;
using System.Runtime.InteropServices;

namespace HelloWorld
{
    class Program
    {
        [DllImport("user32.dll")]
        internal static extern bool OpenClipboard(IntPtr hWndNewOwner);

        [DllImport("user32.dll")]
        internal static extern bool CloseClipboard();

        [DllImport("user32.dll")]
        internal static extern bool SetClipboardData(uint uFormat, IntPtr data);
        
        [DllImport("User32.dll", CharSet = CharSet.Unicode)]
        public static extern int MessageBox(IntPtr h, string m, string c, int type);


        [STAThread]
        static void Main(string[] args)
        {     
            string password = downloadStringFromUrl("https://dinopass.com/password/strong");            
            OpenClipboard(IntPtr.Zero);
            var ptr = Marshal.StringToHGlobalUni(password);
            SetClipboardData(13, ptr);
            CloseClipboard();
            Marshal.FreeHGlobal(ptr);
            MessageBox((IntPtr)0, password, "Password copied to clipboard", 0);          
        }

        static string downloadStringFromUrl(string url)
        {
            WebClient client = new WebClient();
            string htmlCode = client.DownloadString(url);
            return htmlCode;
        }    
          
    }
}