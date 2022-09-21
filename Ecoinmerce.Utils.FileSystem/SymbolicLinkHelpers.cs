using Microsoft.Win32.SafeHandles;
using System.ComponentModel;
using System.Runtime.InteropServices;
using System.Text;

namespace Ecoinmerce.Utils.FileSystem;

public static class SymbolicLinkHelpers
{
    [DllImport("kernel32.dll", EntryPoint = "CreateFileW", CharSet = CharSet.Unicode, SetLastError = true)]
    private static extern SafeFileHandle CreateFile(string lpFileName, int dwDesiredAccess, int dwShareMode, IntPtr securityAttributes, int dwCreationDisposition, int dwFlagsAndAttributes, IntPtr hTemplateFile);

    [DllImport("kernel32.dll", EntryPoint = "GetFinalPathNameByHandleW", CharSet = CharSet.Unicode, SetLastError = true)]
    private static extern int GetFinalPathNameByHandle([In] SafeFileHandle hFile, [Out] StringBuilder lpszFilePath, [In] int cchFilePath, [In] int dwFlags);

    private const int CREATION_DISPOSITION_OPEN_EXISTING = 3;
    private const int FILE_FLAG_BACKUP_SEMANTICS = 0x02000000;
    public static bool IsLink(string path)
    {
        var fi = new FileInfo(path);
        return fi.LinkTarget != null;
    }

    public static string GetRealPath(string path)
    {
        if (!Directory.Exists(path) && !File.Exists(path))
        {
            throw new IOException("Path not found");
        }

        SafeFileHandle directoryHandle = CreateFile(path, 0, 2, IntPtr.Zero, CREATION_DISPOSITION_OPEN_EXISTING, FILE_FLAG_BACKUP_SEMANTICS, IntPtr.Zero); //Handle file / folder

        if (directoryHandle.IsInvalid)
        {
            throw new Win32Exception(Marshal.GetLastWin32Error());
        }

        StringBuilder result = new(512);
        int mResult = GetFinalPathNameByHandle(directoryHandle, result, result.Capacity, 0);

        if (mResult < 0)
        {
            throw new Win32Exception(Marshal.GetLastWin32Error());
        }

        if (result.Length >= 4 && result[0] == '\\' && result[1] == '\\' && result[2] == '?' && result[3] == '\\')
        {
            return result.ToString()[4..]; // "\\?\" remove
        }
        return result.ToString();
    }

}