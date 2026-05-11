using ImageMagick;
using System;
using System.IO;
using System.Windows.Forms;

namespace ImgConvert
{
    internal static class Program
    {
        /// <summary>
        /// 應用程式的主要進入點。
        /// </summary>
        [STAThread]
        static void Main()
        {
            try
            {
                // 配置 Magick.NET 搜尋路徑
                string appPath = AppDomain.CurrentDomain.BaseDirectory;
                string x64Path = Path.Combine(appPath, "x64");
                string x86Path = Path.Combine(appPath, "x86");

                // 依執行程序位元數設定原生庫目錄（相容於目前 Magick.NET 版本）
                string nativePath = Environment.Is64BitProcess ? x64Path : x86Path;
                if (Directory.Exists(nativePath))
                {
                    MagickNET.SetNativeLibraryDirectory(nativePath);
                }
            }
            catch
            {
                // 忽略初始化錯誤，稍後會提示用戶
            }

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }
    }
}
