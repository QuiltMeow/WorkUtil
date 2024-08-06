using System;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using System.Xml.Linq;

namespace PowerLEDOrderEditor
{
    public partial class MainForm : Form
    {
        private readonly PowerLEDXML xmlHandler;

        public MainForm()
        {
            InitializeComponent();
            xmlHandler = new PowerLEDXML();
        }

        private void btnBrowseInput_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog open = new OpenFileDialog()
            {
                Filter = "Power LED 專案檔案 (*.ledprj)|*.ledprj|XML 檔案 (*.xml)|*.xml",
                Title = "請選擇輸入檔案"
            })
            {
                if (open.ShowDialog() != DialogResult.OK)
                {
                    return;
                }
                txtInput.Text = open.FileName;
            }
            loadFile();
        }

        private void loadFile()
        {
            try
            {
                xmlHandler.load(txtInput.Text);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"讀取檔案時發生例外狀況 : {ex.Message}");
                return;
            }

            tvXML.Nodes.Clear();
            foreach (PowerLEDXML.Screen screen in xmlHandler.screenList)
            {
                TreeNode root = tvXML.Nodes.Add(screen.name);
                foreach (XElement program in screen.program)
                {
                    string name = program.Attribute("name").Value;
                    TreeNode node = root.Nodes.Add(name);
                    node.Tag = program;
                }
            }
        }

        private void tvXML_DragDrop(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent("System.Windows.Forms.TreeNode", false))
            {
                Point point = ((TreeView)sender).PointToClient(new Point(e.X, e.Y));
                TreeNode destinationNode = ((TreeView)sender).GetNodeAt(point);
                TreeNode moveNode = e.Data.GetData("System.Windows.Forms.TreeNode") as TreeNode;

                if (checkMoveNode(moveNode, destinationNode))
                {
                    return;
                }
                TreeNode parent = moveNode.Parent;
                moveNode.Remove();

                int index = destinationNode.Index;
                parent.Nodes.Insert(index, (TreeNode)moveNode.Clone());
            }
        }

        private void tvXML_DragEnter(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.Move;
        }

        private void tvXML_ItemDrag(object sender, ItemDragEventArgs e)
        {
            DoDragDrop(e.Item, DragDropEffects.Move);
        }

        private static bool checkMoveNode(TreeNode parentNode, TreeNode childNode)
        {
            if (parentNode.Equals(childNode))
            {
                return true;
            }

            foreach (TreeNode node in parentNode.Nodes)
            {
                if (checkMoveNode(node, childNode))
                {
                    return true;
                }
            }
            return false;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            foreach (TreeNode root in tvXML.Nodes)
            {
                string screen = root.Text;
                XElement rootElement = xmlHandler.getElementByScreenName(screen);
                foreach (TreeNode node in root.Nodes)
                {
                    if (node.Tag != null)
                    {
                        XElement program = (XElement)node.Tag;
                        program.Remove();
                        rootElement.Add(program);
                    }
                }
            }

            using (SaveFileDialog save = new SaveFileDialog()
            {
                Filter = "Power LED 專案檔案 (*.ledprj)|*.ledprj|XML 檔案 (*.xml)|*.xml",
                Title = "請指定輸出檔案"
            })
            {
                if (save.ShowDialog() != DialogResult.OK)
                {
                    return;
                }

                try
                {
                    xmlHandler.xml.Save(save.FileName);
                    MessageBox.Show("檔案儲存完成", "資訊", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"儲存檔案時發生例外狀況 : {ex.Message}", "錯誤", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnOpenContent_Click(object sender, EventArgs e)
        {
            try
            {
                using (Process.Start(txtContent.Text))
                {
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"開啟檔案時發生例外狀況 : {ex.Message}", "錯誤", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void tvXML_SelectedNodeChanged(object sender, TreeViewEventArgs e)
        {
            TreeNode select = tvXML.SelectedNode;
            if (select == null || select.Tag == null)
            {
                return;
            }

            try
            {
                XElement element = (XElement)tvXML.SelectedNode.Tag;
                XElement page = element.Descendants("page").First();
                txtPageName.Text = page.Attribute("name").Value;
                txtSpeed.Text = page.Descendants("speed").First().Value;
                txtDelay.Text = (int.Parse(page.Descendants("delay").First().Value) / 100).ToString();

                if (page.Elements("filepath").Any())
                {
                    string path = page.Descendants("filepath").First().Value;
                    txtContent.Text = path;
                    btnOpenContent.Enabled = true;
                }
                else
                {
                    txtContent.Rtf = page.Descendants("rtf").First().Value;
                    btnOpenContent.Enabled = false;
                }
            }
            catch (Exception ex)
            {
                txtContent.Text = $"讀取存檔時發生例外狀況 : {ex.Message}";
                btnOpenContent.Enabled = false;
            }
        }

        private void tvXML_DragOver(object sender, DragEventArgs e)
        {
            tvXML.scroll();
        }
    }
}