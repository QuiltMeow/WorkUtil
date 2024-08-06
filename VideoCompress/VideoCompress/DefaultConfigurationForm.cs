namespace VideoCompress
{
    public partial class DefaultConfigurationForm : Form
    {
        public struct DefaultResolution
        {
            public int width;
            public int height;
            public string name;
        }

        private static IList<DefaultResolution> resolutionList = new List<DefaultResolution>()
        {
            new DefaultResolution()
            {
                width = 1080,
                height = 608,
                name = "廣告看板橫幅"
            },
            new DefaultResolution()
            {
                width = 1080,
                height = 1313,
                name = "廣告看板直幅"
            },
            new DefaultResolution()
            {
                width = 1080,
                height = 640,
                name = "廣告看板橫幅（舊版）"
            },
            new DefaultResolution()
            {
                width = 1080,
                height = 1275,
                name = "廣告看板直幅（舊版）"
            },
            new DefaultResolution()
            {
                width = 832,
                height = 160,
                name = "電視牆"
            }
        };

        private static int[] bitRateArray = [96, 128, 160, 192, 256, 320, 480, 640, 720, 960, 1024, 1080, 1280, 1560, 1920, 2048];

        public DefaultConfigurationForm()
        {
            InitializeComponent();
            foreach (DefaultResolution resolution in resolutionList)
            {
                cbResolution.Items.Add($"{resolution.name}（{resolution.width}×{resolution.height}）");
            }

            foreach (int bitRate in bitRateArray)
            {
                cbBitRate.Items.Add($"{bitRate} Kbps");
            }

            cbResolution.SelectedIndex = 0;
            cbBitRate.SelectedIndex = 7;
        }

        public bool hasChange
        {
            get;
            private set;
        }

        public int width
        {
            get;
            private set;
        }

        public int height
        {
            get;
            private set;
        }

        public int bitRate
        {
            get;
            private set;
        }

        private void btnConfirm_Click(object sender, EventArgs e)
        {
            hasChange = true;
            DefaultResolution selectResolution = resolutionList[cbResolution.SelectedIndex];
            width = selectResolution.width;
            height = selectResolution.height;
            bitRate = bitRateArray[cbBitRate.SelectedIndex];
            Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}