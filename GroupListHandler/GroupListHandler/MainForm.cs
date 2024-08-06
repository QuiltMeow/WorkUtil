using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GroupListHandler
{
    public partial class MainForm : Form
    {
        private const string TITLE = "人民團體名冊";

        public MainForm()
        {
            InitializeComponent();
        }

        private async void btnHandleFile_Click(object sender, EventArgs e)
        {
            string input = txtFileHandlerInput.Text;
            string output = txtFileHandlerOutput.Text;
            if (!File.Exists(input))
            {
                MessageBox.Show("請輸入有效檔案", "提醒", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (string.IsNullOrWhiteSpace(output))
            {
                MessageBox.Show("請指定輸出檔案", "提醒", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            enableControl(false);
            try
            {
                await Task.Run(() =>
                {
                    string csv = FileHandler.convertExcelFileToCSV(input);
                    IList<string[]> clean = CSVHandler.cleanUpNameList(csv);
                    FileHandler.convertCSVToXLSX(output, TITLE, clean);
                });
                MessageBox.Show("檔案處理完成", "資訊", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"處理檔案時發生例外狀況 : {ex.Message}", "錯誤", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            enableControl(true);

            void enableControl(bool enable)
            {
                btnBrowseFileHandlerInput.Enabled = btnBrowseFileHandlerOutput.Enabled = btnHandleFile.Enabled
                    = enable;
            }
        }

        private async void btnHandleDifference_Click(object sender, EventArgs e)
        {
            string left = txtDifferenceLeftInput.Text;
            string right = txtDifferenceRightInput.Text;
            string output = txtDifferenceOutput.Text;
            if (!File.Exists(left) || !File.Exists(right))
            {
                MessageBox.Show("請輸入有效檔案", "提醒", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (string.IsNullOrWhiteSpace(output))
            {
                MessageBox.Show("請指定輸出檔案", "提醒", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            enableControl(false);
            try
            {
                await Task.Run(() =>
                {
                    string leftCSV = FileHandler.convertExcelFileToCSV(left);
                    string rightCSV = FileHandler.convertExcelFileToCSV(right);
                    IList<string[]> compare = CSVHandler.outputCompareResult(leftCSV, rightCSV);
                    FileHandler.convertCSVToXLSX(output, $"{TITLE}－比對結果", compare);
                });
                MessageBox.Show("檔案處理完成", "資訊", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"處理檔案時發生例外狀況 : {ex.Message}", "錯誤", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            enableControl(true);

            void enableControl(bool enable)
            {
                btnBrowseDifferenceLeftInput.Enabled = btnBrowseDifferenceRightInput.Enabled = btnBrowseDifferenceOutput.Enabled
                    = btnHandleDifference.Enabled = enable;
            }
        }

        private static string openFileDialog(string title, string filter)
        {
            using (OpenFileDialog open = new OpenFileDialog()
            {
                Filter = filter,
                Title = title
            })
            {
                if (open.ShowDialog() != DialogResult.OK)
                {
                    return null;
                }
                return open.FileName;
            }
        }

        private static string saveFileDialog(string title, string filter)
        {
            using (SaveFileDialog save = new SaveFileDialog()
            {
                Filter = filter,
                Title = title
            })
            {
                if (save.ShowDialog() != DialogResult.OK)
                {
                    return null;
                }
                return save.FileName;
            }
        }

        private const string EXCEL_FILTER = "Excel 檔案 (*.xlsx)|*.xlsx";

        private void btnBrowseFileHandlerInput_Click(object sender, EventArgs e)
        {
            string path = openFileDialog("請輸入原始檔案", EXCEL_FILTER);
            if (path != null)
            {
                txtFileHandlerInput.Text = path;
            }
        }

        private void btnBrowseFileHandlerOutput_Click(object sender, EventArgs e)
        {
            string path = saveFileDialog("請指定輸出檔案", EXCEL_FILTER);
            if (path != null)
            {
                txtFileHandlerOutput.Text = path;
            }
        }

        private void btnBrowseDifferenceLeftInput_Click(object sender, EventArgs e)
        {
            string path = openFileDialog("請輸入比對檔案 1", EXCEL_FILTER);
            if (path != null)
            {
                txtDifferenceLeftInput.Text = path;
            }
        }

        private void btnBrowseDifferenceRightInput_Click(object sender, EventArgs e)
        {
            string path = openFileDialog("請輸入比對檔案 2", EXCEL_FILTER);
            if (path != null)
            {
                txtDifferenceRightInput.Text = path;
            }
        }

        private void btnBrowseDifferenceOutput_Click(object sender, EventArgs e)
        {
            string path = saveFileDialog("請指定輸出檔案", EXCEL_FILTER);
            if (path != null)
            {
                txtDifferenceOutput.Text = path;
            }
        }
    }
}