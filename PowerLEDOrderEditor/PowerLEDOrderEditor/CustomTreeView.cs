using System.Windows.Forms;

namespace PowerLEDOrderEditor
{
    public partial class CustomTreeView : TreeView
    {
        public event TreeViewEventHandler SelectedNodeChanged;

        public CustomTreeView()
        {
            AfterSelect += new TreeViewEventHandler(SelectNodeChangedEvent);
            MouseUp += new MouseEventHandler(MouseUpEvent);
        }

        public void SelectNodeChangedEvent(object sender, TreeViewEventArgs e)
        {
            SelectedNodeChangedTrigger(sender, e);
        }

        public void MouseUpEvent(object sender, MouseEventArgs e)
        {
            if (SelectedNode == null)
            {
                SelectedNodeChangedTrigger(sender, new TreeViewEventArgs(null));
            }
        }

        public void SelectedNodeChangedTrigger(object sender, TreeViewEventArgs e)
        {
            if (SelectedNodeChanged != null)
            {
                SelectedNodeChanged(sender, e);
            }
        }
    }
}