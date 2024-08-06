using System.Diagnostics;
using System.Text;

namespace VideoCompress
{
    public partial class MainForm : Form
    {
        private static readonly Random random = new Random();
        private static readonly IList<string> tempFile = new List<string>();

        private const int RETURN_FAILURE = 1;

        private const string REMOVE_AUDIO_COMMAND = $"-i \"{INPUT_SYMBOL}\" -c copy -an \"{OUTPUT_SYMBOL}\"";
        private const string RESIZE_RESOLUTION_COMMAND = $"-i \"{INPUT_SYMBOL}\" -vf scale={WIDTH_SYMBOL}:{HEIGHT_SYMBOL},setsar=1 \"{OUTPUT_SYMBOL}\"";
        private const string CHANGE_BIT_RATE_COMMAND = $"-i \"{INPUT_SYMBOL}\" -b {BIT_RATE_SYMBOL}k \"{OUTPUT_SYMBOL}\"";
        private const string RE_ENCODE_COMMAND = $"-i \"{INPUT_SYMBOL}\" -vcodec libx264 -acodec aac \"{OUTPUT_SYMBOL}\"";

        private const string INPUT_SYMBOL = "{input}";
        private const string OUTPUT_SYMBOL = "{output}";
        private const string WIDTH_SYMBOL = "{width}";
        private const string HEIGHT_SYMBOL = "{height}";
        private const string BIT_RATE_SYMBOL = "{bitRate}";

        private const string FF_MPEG_PATH = "FFMpeg.exe";

        public MainForm()
        {
            InitializeComponent();
        }

        ~MainForm()
        {
            deleteTempFile();
        }

        static MainForm()
        {
            if (!File.Exists(FF_MPEG_PATH))
            {
                MessageBox.Show("FFMpeg 程式不存在", "錯誤", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Environment.Exit(RETURN_FAILURE);
            }
        }

        public static string getRandomString(int length)
        {
            const string RANDOM_SET = "0123456789ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz";
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < length; ++i)
            {
                sb.Append(RANDOM_SET[random.Next(RANDOM_SET.Length)]);
            }
            return sb.ToString();
        }

        private static void deleteTempFile()
        {
            foreach (string file in tempFile)
            {
                try
                {
                    File.Delete(file);
                }
                catch
                {
                }
            }
            tempFile.Clear();
        }

        public static void removeAudio(string input, string output, DataReceivedEventHandler? standardOutput = null, DataReceivedEventHandler? standardError = null)
        {
            CommandHelper.runProcess(FF_MPEG_PATH, REMOVE_AUDIO_COMMAND
                .Replace(INPUT_SYMBOL, input)
                .Replace(OUTPUT_SYMBOL, output), standardOutput, standardError);
        }

        public static void resizeResolution(string input, string output, int width, int height, DataReceivedEventHandler? standardOutput = null, DataReceivedEventHandler? standardError = null)
        {
            CommandHelper.runProcess(FF_MPEG_PATH, RESIZE_RESOLUTION_COMMAND
                .Replace(INPUT_SYMBOL, input)
                .Replace(OUTPUT_SYMBOL, output)
                .Replace(WIDTH_SYMBOL, width.ToString())
                .Replace(HEIGHT_SYMBOL, height.ToString()), standardOutput, standardError);
        }

        public static void changeBitRate(string input, string output, int bitRate, DataReceivedEventHandler? standardOutput = null, DataReceivedEventHandler? standardError = null)
        {
            CommandHelper.runProcess(FF_MPEG_PATH, CHANGE_BIT_RATE_COMMAND
                .Replace(INPUT_SYMBOL, input)
                .Replace(OUTPUT_SYMBOL, output)
                .Replace(BIT_RATE_SYMBOL, bitRate.ToString()), standardOutput, standardError);
        }

        public static void reEncode(string input, string output, DataReceivedEventHandler? standardOutput = null, DataReceivedEventHandler? standardError = null)
        {
            CommandHelper.runProcess(FF_MPEG_PATH, RE_ENCODE_COMMAND
                .Replace(INPUT_SYMBOL, input)
                .Replace(OUTPUT_SYMBOL, output), standardOutput, standardError);
        }

        private void btnBrowseInput_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog open = new OpenFileDialog()
            {
                Title = "請選擇輸入檔案"
            })
            {
                if (open.ShowDialog() != DialogResult.OK)
                {
                    return;
                }
                txtInput.Text = open.FileName;
            }
        }

        private void btnBrowseOutput_Click(object sender, EventArgs e)
        {
            string input = txtInput.Text;
            if (string.IsNullOrWhiteSpace(input))
            {
                MessageBox.Show("請選擇輸入檔案", "提醒", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string extension = Path.GetExtension(input).ToLowerInvariant()[1..];
            using (SaveFileDialog save = new SaveFileDialog()
            {
                Filter = $"{extension.ToUpperInvariant()} 檔案 (*.{extension})|*.{extension}",
                Title = "請指定輸出檔案"
            })
            {
                if (save.ShowDialog() != DialogResult.OK)
                {
                    return;
                }
                txtOutput.Text = save.FileName;
            }
        }

        private void btnSelectDefault_Click(object sender, EventArgs e)
        {
            using (DefaultConfigurationForm form = new DefaultConfigurationForm())
            {
                form.ShowDialog();
                if (form.hasChange)
                {
                    numWidth.Value = form.width;
                    numHeight.Value = form.height;
                    numBitRate.Value = form.bitRate;
                }
            }
        }

        public static void appendTextThreadSafe(TextBox textBox, string? text)
        {
            if (text == null)
            {
                return;
            }
            try
            {
                textBox.Invoke((MethodInvoker)delegate
                {
                    textBox.AppendText($"{text}{Environment.NewLine}");
                });
            }
            catch
            {
            }
        }

        private void dataReceiveEventHandler(object sender, DataReceivedEventArgs e)
        {
            appendTextThreadSafe(txtResult, e.Data);
        }

        private async void btnProcess_Click(object sender, EventArgs e)
        {
            string input = txtInput.Text;
            string output = txtOutput.Text;
            if (string.IsNullOrWhiteSpace(input) || string.IsNullOrWhiteSpace(output))
            {
                MessageBox.Show("請指定來源檔案及輸出檔案", "提醒", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!File.Exists(input))
            {
                MessageBox.Show("來源檔案不存在", "提醒", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            enableControl(true);
            try
            {
                string extension = Path.GetExtension(input).ToLowerInvariant();
                string currentInputPath = input;
                string? currentOutputPath = null;
                if (chkRemoveAudio.Checked)
                {
                    updateCurrentOutputPath();
                    await Task.Run(() => removeAudio(currentInputPath, currentOutputPath!, dataReceiveEventHandler, dataReceiveEventHandler));
                    currentInputPath = currentOutputPath!;
                }

                if (chkResizeResolution.Checked)
                {
                    int width = Convert.ToInt32(numWidth.Value);
                    int height = Convert.ToInt32(numHeight.Value);

                    updateCurrentOutputPath();
                    await Task.Run(() => resizeResolution(currentInputPath, currentOutputPath!, width, height, dataReceiveEventHandler, dataReceiveEventHandler));
                    currentInputPath = currentOutputPath!;
                }

                if (chkChangeBitRate.Checked)
                {
                    int bitRate = Convert.ToInt32(numBitRate.Value);
                    updateCurrentOutputPath();
                    await Task.Run(() => changeBitRate(currentInputPath, currentOutputPath!, bitRate, dataReceiveEventHandler, dataReceiveEventHandler));
                    currentInputPath = currentOutputPath!;
                }

                if (chkReEncode.Checked)
                {
                    updateCurrentOutputPath();
                    await Task.Run(() => reEncode(currentInputPath, currentOutputPath!, dataReceiveEventHandler, dataReceiveEventHandler));
                }

                if (currentOutputPath == null)
                {
                    MessageBox.Show("請選擇影片處理方式", "提醒", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                await Task.Run(() => File.Copy(currentOutputPath, output, true));
                MessageBox.Show("影片處理完成", "資訊", MessageBoxButtons.OK, MessageBoxIcon.Information);

                void updateCurrentOutputPath(int length = 10)
                {
                    currentOutputPath = Path.Combine(Path.GetTempPath(), $"{getRandomString(length)}{extension}");
                    tempFile.Add(currentOutputPath);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"處理影片時發生例外狀況 : {ex.Message}", "錯誤", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                deleteTempFile();
                enableControl(false);
            }

            void enableControl(bool start)
            {
                txtInput.Enabled = btnBrowseInput.Enabled = txtOutput.Enabled
                    = btnBrowseOutput.Enabled = chkRemoveAudio.Enabled = chkResizeResolution.Enabled
                    = btnSelectDefault.Enabled = chkChangeBitRate.Enabled = chkReEncode.Enabled
                    = btnProcess.Enabled = !start;

                if (start)
                {
                    numWidth.Enabled = numHeight.Enabled = numBitRate.Enabled
                        = false;
                }
                else
                {
                    updateResizeResolutionStatus();
                    updateChangeBitRateStatus();
                }
            }
        }

        private void btnClearLog_Click(object sender, EventArgs e)
        {
            txtResult.Text = string.Empty;
        }

        private void updateResizeResolutionStatus()
        {
            numWidth.Enabled = numHeight.Enabled = chkResizeResolution.Checked;
        }

        private void updateChangeBitRateStatus()
        {
            numBitRate.Enabled = chkChangeBitRate.Checked;
        }

        private void chkResizeResolution_CheckedChanged(object sender, EventArgs e)
        {
            updateResizeResolutionStatus();
        }

        private void chkChangeBitRate_CheckedChanged(object sender, EventArgs e)
        {
            updateChangeBitRateStatus();
        }
    }
}