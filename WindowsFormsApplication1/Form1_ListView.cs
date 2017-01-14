using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Configuration;
using System.Windows;

namespace PatkaPlayer
{
    public partial class frmPlayer
    {
        private ListViewItem dragFrom;
        private VisualStylesListView dragFromLV;

        private bool playlistDragStarted = false;
        private bool fileDragStarted = false;
        private bool folderDragStarted = false;

        private List<string> listFolder = new List<string>();
        private List<string> listFile = new List<string>();
        private List<string> listPlaylist = new List<string>();

        private List<string> listFolderFiltered = new List<string>();
        private List<string> listFileFiltered = new List<string>();
        private List<string> listPlaylistFiltered = new List<string>();

        private string allFolders = "[All folders]";
        private string lastFolder = "-";

        private void createFolderList()
        {
            txtFolderFilter.Text = "";
            listFolder.Clear();

            foreach (ListViewItem item in lstFolders.Items)
            {
                listFolder.Add(item.Text);
            }
        }

        private void createFileList()
        {
            txtFileFilter.Text = "";
            listFile.Clear();

            foreach (ListViewItem item in lstFiles.Items)
            {
                listFile.Add(item.Text);
            }
        }

        private void createPlaylistList()
        {
            txtPlaylistFolderFilter.Text = "";
            txtPlaylistFileFilter.Text = "";
            listPlaylist.Clear();

            foreach (ListViewItem item in lstPlaylist.Items)
            {
                listPlaylist.Add(item.Text);
            }
        }

        private void createFolderListFiltered()
        {
            listFolderFiltered.Clear();

            foreach (ListViewItem item in lstFolders.Items)
            {
                listFolderFiltered.Add(item.Text);
            }
        }

        private void createFileListFiltered()
        {
            listFileFiltered.Clear();

            foreach (ListViewItem item in lstFiles.Items)
            {
                listFileFiltered.Add(item.Text);
            }
        }

        private void createPlaylistListFiltered()
        {
            listPlaylistFiltered.Clear();

            foreach (ListViewItem item in lstPlaylist.Items)
            {
                listPlaylistFiltered.Add(item.Text);
            }
        }

        private List<string> getList()
        {
            if (randomTarget == "folder")
            {
                List<string> list = new List<string>();

                if (txtFolderFilter.Text == "")
                {
                    foreach (string folder in listFolder)
                    {
                        if (folder != "-" && Directory.Exists(folder))
                        {
                            string[] files = Directory.GetFiles(folder, "*.mp3", SearchOption.TopDirectoryOnly);
                            list.AddRange(files);
                        }
                    }
                }

                else
                {
                    foreach (string folder in listFolderFiltered)
                    {
                        string[] files = Directory.GetFiles(folder, "*.mp3", SearchOption.TopDirectoryOnly);
                        list.AddRange(files);
                    }
                }

                return list;
            }

            else if (randomTarget == "file")
            {
                if (txtFileFilter.Text == "") return listFile;
                else return listFileFiltered;

            }

            else
            {
                if (txtPlaylistFolderFilter.Text == "" && txtPlaylistFileFilter.Text == "") return listPlaylist;
                else return listPlaylistFiltered;

            }
        }

        private void resizeColumns()
        {
            lstFolders.BeginUpdate();
            clmFolder.Width = 0;
            clmFolderName.Width = lstFolders.ClientRectangle.Width;
            lstFolders.EndUpdate();

            lstFiles.BeginUpdate();
            clmFile.Width = 0;
            clmFileName.Width = lstFiles.ClientRectangle.Width;
            lstFiles.EndUpdate();

            lstPlaylist.BeginUpdate();
            clmPlaylist.Width = 0;
            clmPlaylistFolder.Width = 340;
            clmPlaylistFile.Width = 340;

            int numWidth = lstPlaylist.ClientRectangle.Width - clmPlaylistFolder.Width - clmPlaylistFile.Width;
            if (numWidth > 80) numWidth = 80;
            clmPlaylistNum.Width = numWidth;
            lstPlaylist.EndUpdate();
        }

        private void setPlaylistNumbers()
        {
            int i = 1;
            foreach (ListViewItem item in lstPlaylist.Items)
            {
                item.SubItems[1].Text = i.ToString();
                i++;
            }
        }

        private void addFolders()
        {
            if (Directory.Exists(mp3Dir))
            {
                string[] folders = Directory.GetDirectories(mp3Dir);

                lstFolders.Items.Clear();
                lstFolders.BeginUpdate();

                ListViewItem item1 = new ListViewItem("-");
                item1.SubItems.Add(allFolders);
                lstFolders.Items.Add(item1);

                foreach (string folder in folders)
                {
                    ListViewItem item = new ListViewItem(folder);
                    item.SubItems.Add(Path.GetFileName(folder));
                    lstFolders.Items.Add(item);
                }

                lstFolders.EndUpdate();
                resizeColumns();

                if (lstFolders.Items.Count > 0) lstFolders.Items[0].Selected = true;
                addFiles(lstFolders.Items[0].Text);
            }

            createFolderList();
        }

        private void addFilesWithoutGroups(string folder)
        {
            if (folder == "-")
            {
                string[] files = Directory.GetFiles(mp3Dir, "*.mp3", SearchOption.AllDirectories);

                lstFiles.Items.Clear();
                lstFiles.BeginUpdate();

                foreach (string file in files)
                {
                    ListViewItem item = new ListViewItem(file);
                    item.SubItems.Add(Path.GetFileNameWithoutExtension(file));
                    lstFiles.Items.Add(item);
                }

                lstFiles.EndUpdate();
                resizeColumns();
            }

            else if (Directory.Exists(folder))
            {
                string[] files = Directory.GetFiles(folder, "*.mp3", SearchOption.TopDirectoryOnly);

                lstFiles.Items.Clear();
                lstFiles.BeginUpdate();

                foreach (string file in files)
                {
                    ListViewItem item = new ListViewItem(file);
                    item.SubItems.Add(Path.GetFileNameWithoutExtension(file));
                    lstFiles.Items.Add(item);
                }

                lstFiles.EndUpdate();
                resizeColumns();
            }

            createFileList();
        }

        private void addFiles(string folder)
        {
            if (folder == "-")
            {
                string[] folders = Directory.GetDirectories(mp3Dir);

                lstFiles.BeginUpdate();
                lstFiles.Items.Clear();
                lstFiles.Groups.Clear();

                foreach (string f in folders)
                {
                    string[] files = Directory.GetFiles(f, "*.mp3", SearchOption.TopDirectoryOnly);

                    ListViewGroup group = new ListViewGroup("", HorizontalAlignment.Left);
                    group.HeaderAlignment = HorizontalAlignment.Center;
                    group.Header = Path.GetFileName(f);
                    lstFiles.Groups.Add(group);

                    foreach (string file in files)
                    {
                        ListViewItem item = new ListViewItem(file, 0, group);
                        item.SubItems.Add(Path.GetFileNameWithoutExtension(file));
                        lstFiles.Items.Add(item);
                    }
                }

                lstFiles.EndUpdate();
                resizeColumns();
            }

            else if (Directory.Exists(folder))
            {
                string[] files = Directory.GetFiles(folder, "*.mp3", SearchOption.TopDirectoryOnly);

                lstFiles.BeginUpdate();
                lstFiles.Items.Clear();
                lstFiles.Groups.Clear();

                ListViewGroup group = new ListViewGroup("", HorizontalAlignment.Left);
                group.HeaderAlignment = HorizontalAlignment.Center;
                group.Header = Path.GetFileName(folder);
                lstFiles.Groups.Add(group);

                foreach (string file in files)
                {
                    ListViewItem item = new ListViewItem(file, 0, group);
                    item.SubItems.Add(Path.GetFileNameWithoutExtension(file));
                    lstFiles.Items.Add(item);
                }

                lstFiles.EndUpdate();
                resizeColumns();
            }

            createFileList();
        }

        private void addPlaylistFile(string file)
        {
            string folder = Path.GetDirectoryName(file);
            lstPlaylist.BeginUpdate();

            ListViewItem item = new ListViewItem(file);
            item.SubItems.Add("");
            item.SubItems.Add(Path.GetFileName(folder));
            item.SubItems.Add(Path.GetFileNameWithoutExtension(file));
            lstPlaylist.Items.Add(item);

            lstPlaylist.EndUpdate();
            resizeColumns();
            setPlaylistNumbers();

            createPlaylistList();
        }

        private void addPlaylistFolder(string folder)
        {
            if (Directory.Exists(folder))
            {
                string[] files = Directory.GetFiles(folder, "*.mp3", SearchOption.TopDirectoryOnly);

                lstPlaylist.BeginUpdate();

                foreach (string file in files)
                {
                    ListViewItem item = new ListViewItem(file);
                    item.SubItems.Add("");
                    item.SubItems.Add(Path.GetFileName(folder));
                    item.SubItems.Add(Path.GetFileNameWithoutExtension(file));
                    lstPlaylist.Items.Add(item);
                }

                lstPlaylist.EndUpdate();
                resizeColumns();
                setPlaylistNumbers();
            }

            createPlaylistList();
        }

        private void removePlaylistItem(int index)
        {
            lstPlaylist.BeginUpdate();

            lstPlaylist.Items.RemoveAt(index);

            lstPlaylist.EndUpdate();
            resizeColumns();
            setPlaylistNumbers();
        }

        private void lstFolders_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lstFolders.SelectedItems.Count > 0) lastFolder = lstFolders.SelectedItems[0].Text;
        }

        private void lstFolders_MouseDown(object sender, MouseEventArgs e)
        {
            folderDragStarted = false;
        }

        private void lstFolders_MouseUp(object sender, MouseEventArgs e)
        {
            if (!folderDragStarted && lstFolders.Items.Count > 0)
            {
                ListViewItem item = lstFolders.GetItemAt(e.X, e.Y);

                if (item != null)
                {
                    if (e.Button == MouseButtons.Left) addFiles(item.Text);
                    //else if (e.Button == MouseButtons.Right) addPlaylistFolder(item.Text);
                }
            }
        }

        private void lstFiles_MouseDown(object sender, MouseEventArgs e)
        {
            fileDragStarted = false;
        }

        private void lstFiles_MouseUp(object sender, MouseEventArgs e)
        {
            if (!fileDragStarted && lstFiles.Items.Count > 0)
            {
                ListViewItem item = lstFiles.GetItemAt(e.X, e.Y);

                if (item != null)
                {
                    if (e.Button == MouseButtons.Left) playFile(item.Text);
                    //else if (e.Button == MouseButtons.Right) addPlaylistFile(item.Text);
                }
            }
        }

        private void lstPlaylist_MouseDown(object sender, MouseEventArgs e)
        {
            playlistDragStarted = false;
        }

        private void lstPlaylist_MouseUp(object sender, MouseEventArgs e)
        {
            if (lstPlaylist.Items.Count > 0 && !playlistDragStarted)
            {
                ListViewItem item = lstPlaylist.GetItemAt(e.X, e.Y);

                if (item != null)
                {
                    if (e.Button == MouseButtons.Left)
                    {
                        if (!ModifierKeys.HasFlag(Keys.Control) && !ModifierKeys.HasFlag(Keys.Shift)) playFile(item.Text);
                    }

                    else if (e.Button == MouseButtons.Right)
                    {

                    }
                }
            }

            playlistDragStarted = false;
        }

        private void lstPlaylist_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete) removePlaylistItems();
            if (e.KeyCode == Keys.A && e.Modifiers == Keys.Control)
            {
                foreach (ListViewItem item in lstPlaylist.Items) item.Selected = true;
            }
        }

        private void removePlaylistItems()
        {
            if (lstPlaylist.SelectedItems.Count > 0)
            {
                int index = lstPlaylist.SelectedItems[0].Index;

                foreach (ListViewItem item in lstPlaylist.SelectedItems)
                {
                    item.Remove();
                }

                if (lstPlaylist.Items.Count > 0)
                {
                    if (index < lstPlaylist.Items.Count) lstPlaylist.Items[index].Selected = true;
                    else lstPlaylist.Items[lstPlaylist.Items.Count - 1].Selected = true;
                }

                createPlaylistList();
                resizeColumns();
                setPlaylistNumbers();
            }
        }

        // ******************* Drag and drop / Folders ********************

        private void lstFolders_ItemDrag(object sender, ItemDragEventArgs e)
        {
            folderDragStarted = true;
            dragFrom = (ListViewItem)e.Item;
            dragFromLV = lstFolders;
            lstFolders.DoDragDrop(e.Item, DragDropEffects.All);
        }

        // ******************* Drag and drop / Files ********************

        private void lstFiles_ItemDrag(object sender, ItemDragEventArgs e)
        {
            fileDragStarted = true;
            dragFrom = (ListViewItem)e.Item;
            dragFromLV = lstFiles;
            lstFiles.DoDragDrop(e.Item, DragDropEffects.All);
        }

        private void lstFiles_DragDrop(object sender, DragEventArgs e)
        {
            if (dragFromLV == lstPlaylist) removePlaylistItems();

            dragFromLV = null;
        }

        private void lstFiles_DragEnter(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.Move;
        }

        private void lstFiles_DragOver(object sender, DragEventArgs e)
        {
        }

        private void lstFiles_GiveFeedback(object sender, GiveFeedbackEventArgs e)
        {
            //e.UseDefaultCursors = false;
            //Cursor.Current = Cursors.Default;
        }

        // ******************* Drag and drop / Playlist ********************

        private void lstPlaylist_ItemDrag(object sender, ItemDragEventArgs e)
        {
            playlistDragStarted = true;
            dragFrom = (ListViewItem)e.Item;
            dragFromLV = lstPlaylist;
            lstPlaylist.DoDragDrop(e.Item, DragDropEffects.All);
        }

        private void lstPlaylist_DragDrop(object sender, DragEventArgs e)
        {
            if (dragFromLV == lstFolders) addPlaylistFolder(lstFolders.SelectedItems[0].Text);
            else if (dragFromLV == lstFiles) addPlaylistFile(lstFiles.SelectedItems[0].Text);

            dragFromLV = null;
        }

        private void lstPlaylist_DragEnter(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.Move;
        }

        private void lstPlaylist_DragOver(object sender, DragEventArgs e)
        {
            if (dragFromLV == lstPlaylist)
                {
                Point location = lstPlaylist.PointToClient(new Point(e.X, e.Y));
                ListViewItem item = lstPlaylist.GetItemAt(location.X, location.Y);

                if (item != null)
                {
                    int indexFirstSelected = lstPlaylist.SelectedItems[0].Index;
                    int indexLastSelected = lstPlaylist.SelectedItems[lstPlaylist.SelectedItems.Count - 1].Index;
                    int indexTo = item.Index;
                    int indexFrom = dragFrom.Index;

                    if (indexTo < indexFrom)
                    {
                        int diff = indexFrom - indexFirstSelected;
                        int newPosition = indexTo - diff;
                        if (newPosition >= 0) moveUp(newPosition);
                    }

                    if (indexTo > indexFrom)
                    {
                        int diff = indexLastSelected - indexFrom;
                        int newPosition = indexTo + diff;
                        if (newPosition < lstPlaylist.Items.Count) moveDown(newPosition);
                    }
                }

                createPlaylistList();
            }
        }

        private void lstPlaylist_GiveFeedback(object sender, GiveFeedbackEventArgs e)
        {
            //e.UseDefaultCursors = false;
            //Cursor.Current = Cursors.Default;
        }

        private void moveUp(int indexTo)
        {
            lstPlaylist.BeginUpdate();

            int diff = lstPlaylist.SelectedItems[0].Index - indexTo;
            foreach (ListViewItem item in lstPlaylist.SelectedItems)
            {
                int indexFrom = item.Index;
                int newPosition = indexFrom - diff;

                lstPlaylist.Items.RemoveAt(indexFrom);
                lstPlaylist.Items.Insert(newPosition, item);
            }

            setPlaylistNumbers();
            lstPlaylist.EndUpdate();
        }

        private void moveDown(int indexTo)
        {
            lstPlaylist.BeginUpdate();

            int diff = indexTo - lstPlaylist.SelectedItems[lstPlaylist.SelectedItems.Count - 1].Index;
            for (int i = lstPlaylist.SelectedItems.Count - 1; i >= 0; i--)
            {
                ListViewItem item = lstPlaylist.SelectedItems[i];
                int indexFrom = item.Index;
                int newPosition = indexFrom + diff;

                lstPlaylist.Items.RemoveAt(indexFrom);
                lstPlaylist.Items.Insert(newPosition, item);
            }

            setPlaylistNumbers();
            lstPlaylist.EndUpdate();
        }

        // ******************* lstPlaylist filters ********************

        private void btnRemoveFolderFilter_Click(object sender, EventArgs e)
        {
            txtFolderFilter.Text = "";
        }

        private void btnRemoveFileFilter_Click(object sender, EventArgs e)
        {
            txtFileFilter.Text = "";
        }

        private void btnRemovePlaylistFilter_Click(object sender, EventArgs e)
        {
            txtPlaylistFolderFilter.Text = "";
            txtPlaylistFileFilter.Text = "";
        }

        private void txtFolderFilter_TextChanged(object sender, EventArgs e)
        {
            if (txtFolderFilter.Text == "")
            {
                lstFolders.BeginUpdate();
                lstFolders.Items.Clear();

                foreach (string folder in listFolder)
                {
                    if (folder == "-")
                    {
                        ListViewItem item = new ListViewItem("-");
                        item.SubItems.Add(allFolders);
                        lstFolders.Items.Add(item);
                    }

                    else
                    {
                        ListViewItem item = new ListViewItem(folder);
                        item.SubItems.Add(Path.GetFileName(folder));
                        lstFolders.Items.Add(item);
                    }
                }

                lstFolders.EndUpdate();
                resizeColumns();
            }

            else
            {
                lstFolders.BeginUpdate();
                lstFolders.Items.Clear();

                foreach (string folder in listFolder)
                {
                    if (folder != "-")
                    {
                        string folderName = Path.GetFileName(folder);
                        if (folderName.IndexOf(txtFolderFilter.Text, StringComparison.OrdinalIgnoreCase) > -1)
                        {
                            ListViewItem item = new ListViewItem(folder);
                            item.SubItems.Add(Path.GetFileName(folder));
                            lstFolders.Items.Add(item);
                        }
                    }
                }

                lstFolders.EndUpdate();
                resizeColumns();
            }

            createFolderListFiltered();
        }

        private void txtFileFilter_TextChanged(object sender, EventArgs e)
        {
            if (txtFileFilter.Text == "")
            {
                /*
                lstFiles.BeginUpdate();
                lstFiles.Items.Clear();
                lstFiles.Groups.Clear();

                foreach (string file in listFile)
                {
                    ListViewItem item = new ListViewItem(file);
                    item.SubItems.Add(Path.GetFileNameWithoutExtension(file));
                    lstFiles.Items.Add(item);
                }

                lstFiles.EndUpdate();
                resizeColumns();
                */
                addFiles(lastFolder);
            }

            else
            {
                lstFiles.BeginUpdate();
                lstFiles.Items.Clear();
                lstFiles.Groups.Clear();

                foreach (string file in listFile)
                {
                    string fileName = Path.GetFileNameWithoutExtension(file);
                    if (fileName.IndexOf(txtFileFilter.Text, StringComparison.OrdinalIgnoreCase) > -1)
                    {
                        ListViewItem item = new ListViewItem(file);
                        item.SubItems.Add(Path.GetFileNameWithoutExtension(file));
                        lstFiles.Items.Add(item);
                    }
                }

                lstFiles.EndUpdate();
                resizeColumns();
            }

            createFileListFiltered();
        }

        private void txtPlaylistFolderFilter_TextChanged(object sender, EventArgs e)
        {
            txtPlaylist_TextChanged();
        }

        private void txtPlaylistFileFilter_TextChanged(object sender, EventArgs e)
        {
            txtPlaylist_TextChanged();
        }

        private void txtPlaylist_TextChanged()
        {
            if (txtPlaylistFileFilter.Text == "" && txtPlaylistFolderFilter.Text == "")
            {
                lstPlaylist.BeginUpdate();
                lstPlaylist.Items.Clear();

                foreach (string file in listPlaylist)
                {
                    string folder = Path.GetDirectoryName(file);

                    ListViewItem item = new ListViewItem(file);
                    item.SubItems.Add("");
                    item.SubItems.Add(Path.GetFileName(folder));
                    item.SubItems.Add(Path.GetFileNameWithoutExtension(file));
                    lstPlaylist.Items.Add(item);
                }

                lstPlaylist.EndUpdate();
                resizeColumns();
                setPlaylistNumbers();
            }

            else
            {
                lstPlaylist.BeginUpdate();
                lstPlaylist.Items.Clear();

                foreach (string file in listPlaylist)
                {
                    string folder = Path.GetDirectoryName(file);
                    string folderName = Path.GetFileName(folder);
                    string fileName = Path.GetFileNameWithoutExtension(file);

                    bool found = true;

                    if (txtPlaylistFolderFilter.Text != "")
                    {
                        if (folderName.IndexOf(txtPlaylistFolderFilter.Text, StringComparison.OrdinalIgnoreCase) > -1) found = true;
                        else found = false;
                    }

                    if (found && txtPlaylistFileFilter.Text != "")
                    {
                        if (fileName.IndexOf(txtPlaylistFileFilter.Text, StringComparison.OrdinalIgnoreCase) > -1) found = true;
                        else found = false;
                    }

                    if (found)
                    {
                        ListViewItem item = new ListViewItem(file);
                        item.SubItems.Add("");
                        item.SubItems.Add(Path.GetFileName(folder));
                        item.SubItems.Add(Path.GetFileNameWithoutExtension(file));
                        lstPlaylist.Items.Add(item);
                    }
                }

                lstPlaylist.EndUpdate();
                resizeColumns();
                setPlaylistNumbers();
            }

            createPlaylistListFiltered();
        }

        private void txtFolderFilter_DoubleClick(object sender, EventArgs e)
        {
            txtFolderFilter.Text = "";
        }

        private void txtFileFilter_DoubleClick(object sender, EventArgs e)
        {
            txtFileFilter.Text = "";
        }

        private void txtPlaylistFolderFilter_DoubleClick(object sender, EventArgs e)
        {
            txtPlaylistFolderFilter.Text = "";
        }

        private void txtPlaylistFileFilter_DoubleClick(object sender, EventArgs e)
        {
            txtPlaylistFileFilter.Text = "";
        }

        // ********************** Load / Save ************************

        private void btnClearPlaylist_Click(object sender, EventArgs e)
        {
            lstPlaylist.BeginUpdate();
            lstPlaylist.Items.Clear();
            lstPlaylist.EndUpdate();
            resizeColumns();
        }

        private void btnLoadPlaylist_Click(object sender, EventArgs e)
        {
            OpenFileDialog dlg = new OpenFileDialog();

            dlg.Filter = "Playlist files (*.lst)|*.lst|All files (*.*)|*.*";
            dlg.FilterIndex = 1;
            dlg.RestoreDirectory = true;
            dlg.InitialDirectory = Path.GetDirectoryName(Application.ExecutablePath);
            dlg.Multiselect = false;

            if (dlg.ShowDialog() == DialogResult.OK)
            {
                if (File.Exists(dlg.FileName))
                {
                    listLoad(dlg.FileName);
                }
            }
        }

        private void btnSavePlaylist_Click(object sender, EventArgs e)
        {
            SaveFileDialog dlg = new SaveFileDialog();

            dlg.Filter = "Playlist files (*.lst)|*.lst|All files (*.*)|*.*";
            dlg.FilterIndex = 1;
            dlg.RestoreDirectory = true;
            dlg.InitialDirectory = Path.GetDirectoryName(Application.ExecutablePath);

            if (dlg.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    if (File.Exists(dlg.FileName)) File.Delete(dlg.FileName);
                }

                catch
                {
                    MessageBox.Show("Saving failed.");
                }

                listSave(dlg.FileName);
            }
        }

        private void listSave(string file)
        {
            try
            {
                using (StreamWriter sw = new StreamWriter(file))
                {
                    if (lstPlaylist.Items.Count > 0)
                    {
                        foreach (ListViewItem item in lstPlaylist.Items)
                        {
                            string str = item.SubItems[0].Text + "|" + item.SubItems[2].Text + "|" + item.SubItems[3].Text;
                            sw.WriteLine(str);
                        }
                    }
                }
            }

            catch { }
        }

        private void listLoad(string file)
        {
            try
            {
                lstPlaylist.Items.Clear();

                if (File.Exists(file))
                {
                    using (StreamReader reader = File.OpenText(file))
                    {
                        lstPlaylist.BeginUpdate();

                        while (reader.Peek() >= 0)
                        {
                            string line = reader.ReadLine();
                            List<string> list = line.Split('|').ToList<string>();

                            ListViewItem item = new ListViewItem(list[0]);
                            item.SubItems.Add("");
                            item.SubItems.Add(list[1]);
                            item.SubItems.Add(list[2]);

                            lstPlaylist.Items.Add(item);
                        }

                        lstPlaylist.EndUpdate();
                        resizeColumns();
                        setPlaylistNumbers();
                    }

                }
            }

            catch { }
        }




    }
}
