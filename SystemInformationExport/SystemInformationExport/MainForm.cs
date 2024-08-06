using System;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SystemInformationExport
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private async void btnExport_Click(object sender, EventArgs e)
        {
            string path = txtPath.Text;
            enableControl(false);
            await Task.Run(() => CommandHelper.exportSystemInformation(path));
            enableControl(true);

            void enableControl(bool enable)
            {
                btnBrowsePath.Enabled = btnExport.Enabled = enable;
            }
        }

        private void btnBrowsePath_Click(object sender, EventArgs e)
        {
            using (SaveFileDialog save = new SaveFileDialog()
            {
                Filter = "系統資訊檔案 (*.nfo)|*.nfo",
                Title = "請指定導出檔案"
            })
            {
                if (save.ShowDialog() != DialogResult.OK)
                {
                    return;
                }
                txtPath.Text = save.FileName;
                btnExport.Enabled = true;
            }
        }
    }
}