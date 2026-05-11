using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using ImageMagick;

namespace ImgConvert
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            // 初始化時檢查 Magick.NET
            CheckMagickNET();
        }

        private void CheckMagickNET()
        {
            try
            {
                // 顯示應用程式路徑信息
                string appPath = AppDomain.CurrentDomain.BaseDirectory;
                string x64Path = Path.Combine(appPath, "x64");
                string x86Path = Path.Combine(appPath, "x86");
                
                // 嘗試初始化 ImageMagick - 創建一個簡單的測試圖像
                using (MagickImage test = new MagickImage(new MagickColor("white"), 1, 1))
                {
                    // 成功
                }
            }
            catch (Exception ex)
            {
                string appPath = AppDomain.CurrentDomain.BaseDirectory;
                string x64Path = Path.Combine(appPath, "x64");
                string x86Path = Path.Combine(appPath, "x86");
                
                string errorMsg = $"Magick.NET 初始化失敗\n\n";
                errorMsg += $"應用程式目錄: {appPath}\n";
                errorMsg += $"x64 路徑: {(Directory.Exists(x64Path) ? "存在" : "不存在")}\n";
                errorMsg += $"x86 路徑: {(Directory.Exists(x86Path) ? "存在" : "不存在")}\n\n";
                errorMsg += $"錯誤: {ex.Message}\n";
                if (ex.InnerException != null)
                {
                    errorMsg += $"\n內部錯誤: {ex.InnerException.Message}";
                }
                
                MessageBox.Show(errorMsg, "警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // 驗證畫質參數
            if (!int.TryParse(textBox1.Text, out int quality) || quality < 1 || quality > 100)
            {
                MessageBox.Show("畫質參數必須是 1-100 之間的數字", "輸入錯誤", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                textBox1.Focus();
                textBox1.SelectAll();
                return;
            }

            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Filter = "圖片檔 (*.webp;*.jpg;*.jpeg;*.png;*.bmp;*.gif;*.tif;*.tiff)|*.webp;*.jpg;*.jpeg;*.png;*.bmp;*.gif;*.tif;*.tiff|All files (*.*)|*.*";
                openFileDialog.Multiselect = true;
                openFileDialog.Title = "選擇要轉換的圖檔";

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        // 確定轉檔格式
                        string outputFormat = GetOutputFormat();

                        int successCount = 0;
                        List<string> failedFiles = new List<string>();

                        foreach (string filePath in openFileDialog.FileNames)
                        {
                            try
                            {
                                ConvertImage(filePath, outputFormat, quality);
                                successCount++;
                            }
                            catch
                            {
                                failedFiles.Add(Path.GetFileName(filePath));
                            }
                        }

                        if (failedFiles.Count == 0)
                        {
                            MessageBox.Show($"轉檔完成！成功 {successCount} 檔。", "成功", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                        {
                            string failedList = string.Join("\n", failedFiles);
                            MessageBox.Show($"完成：成功 {successCount} 檔，失敗 {failedFiles.Count} 檔。\n\n失敗檔案：\n{failedList}", "部分完成", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                    }
                    catch (Exception ex)
                    {
                        string errorMsg = $"轉檔發生錯誤:\n{ex.Message}";
                        if (ex.InnerException != null)
                        {
                            errorMsg += $"\n\n內部錯誤: {ex.InnerException.Message}";
                        }
                        MessageBox.Show(errorMsg, "錯誤", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private string GetOutputFormat()
        {
            if (radioJpgButton.Checked)
                return "jpg";
            else if (radioWebpButton.Checked)
                return "webp";
            else
                return "png";
        }

        private void ConvertImage(string inputPath, string outputFormat, int quality)
        {
            // 取得檔案所在目錄
            string directory = Path.GetDirectoryName(inputPath);
            string fileName = Path.GetFileNameWithoutExtension(inputPath);
            string sourceExtension = Path.GetExtension(inputPath).TrimStart('.');
            
            // 建立 temp 資料夾
            string tempDir = Path.Combine(directory, "temp");
            if (!Directory.Exists(tempDir))
            {
                Directory.CreateDirectory(tempDir);
            }
            
            // 避免不同來源副檔名但同檔名時互相覆蓋，例如 a.jpg 和 a.png 同時轉成 a.webp
            string outputFileName = $"{fileName}.{outputFormat}";
            string outputPath = Path.Combine(tempDir, outputFileName);

            if (File.Exists(outputPath))
            {
                outputFileName = $"{fileName}_Src{sourceExtension}.{outputFormat}";
                outputPath = Path.Combine(tempDir, outputFileName);
            }
            
            // 使用 Magick.NET 進行轉檔
            using (MagickImage image = new MagickImage(inputPath))
            {
                // 根據輸出格式設定
                if (outputFormat.ToLower() == "jpg")
                {
                    image.Format = MagickFormat.Jpeg;
                    image.Quality = quality;
                }
                else if (outputFormat.ToLower() == "webp")
                {
                    image.Format = MagickFormat.WebP;
                    image.Quality = quality;
                }
                else // png
                {
                    image.Format = MagickFormat.Png;
                    // PNG 使用無損壓縮，Magick.NET 沒有 CompressionLevel 屬性
                    // 可考慮不設定壓縮等級，或使用 image.SetArtifact
                    // 這裡直接省略 CompressionLevel 設定
                }

                image.Write(outputPath);
            }
        }

    }
}
