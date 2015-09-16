using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace FileDupeFinder
{
    public partial class FileForm : Form
    {
		private FilesystemCrawl _crawler;
		private Timer _timer;
	    private int _total;
	    private int _complete;
	    private bool _finished;

        public FileForm()
        {
            InitializeComponent();

			_timer = new Timer {Interval = 50};
		    _timer.Tick += Timer_Tick;
        }

        private void btnBrowse_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog dialog = new FolderBrowserDialog();
            dialog.SelectedPath = tbSearchPath.Text;
            dialog.ShowNewFolderButton = false;
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                tbSearchPath.Text = dialog.SelectedPath;
            }
        }

	    private void btnSearch_Click(object sender, EventArgs e)
	    {
		    btnSearch.Enabled = false;
		    tbSearchPath.Enabled = false;
		    btnBrowse.Enabled = false;

            progressBar1.Maximum = _total = 1;
            progressBar1.Value = _complete = 0;
		    _finished = false;
			progressBar1.Visible = true;
			btnDelete.Visible = false;

		    _crawler = new FilesystemCrawl(tbSearchPath.Text);
		    _crawler.OnProgress = (total, complete) =>
		    {
			    _total = total;
			    _complete = complete;
		    };
		    _crawler.OnFinished = () => { _finished = true; };

			_timer.Start();
	    }

	    private void Timer_Tick(object sender, EventArgs e)
		{
			progressBar1.Maximum = _total;
			progressBar1.Value = _complete;

		    if (_finished)
		    {
				_timer.Stop();
			    EndProcessFiles();
		    }
	    }

        private void EndProcessFiles()
        {
            lbDuplicateSets.Items.Clear();
            foreach (string hash in _crawler.Duplicates.Keys)
            {
				DuplicateList dupeList = new DuplicateList(tbSearchPath.Text);
				foreach (var duplicateFile in _crawler.Duplicates[hash])
					dupeList.AddFile(duplicateFile);
                lbDuplicateSets.Items.Add(dupeList);
            }

            if (lbDuplicateSets.Items.Count > 0)
                lbDuplicateSets.SelectedIndex = 0;

            btnSearch.Enabled = true;
            tbSearchPath.Enabled = true;
            btnBrowse.Enabled = true;

			progressBar1.Visible = false;
			btnDelete.Visible = true;
        }

        const int imageSize = 200;
        const int imagePadding = 20;
        const int margin_top = 30;
        const int margin_left = 20;
        const int rowSize = 3;

        private void lbDuplicateSets_SelectedIndexChanged(object sender, EventArgs e)
        {
            duplicatesPanel.Controls.Clear();

            DuplicateList dupeList = (DuplicateList)lbDuplicateSets.SelectedItem;
            int index = 0;
            foreach (var dupe in dupeList.GetDuplicates())
            {
                try
                {
	                Size resize;
	                Image resizedImg;
	                using (Image img = Image.FromFile(dupe.Filepath))
	                {
		                resize = ThumbnailSize(img.Size, imageSize);
		                resizedImg = new Bitmap(img, resize);
	                }
	                
	                var pb = new PictureBox
	                {
						Width = imageSize + 2,
						Height = imageSize + 2,
		                SizeMode = PictureBoxSizeMode.CenterImage,
		                Location =
			                new Point(margin_left + (imageSize + imagePadding)*(index%rowSize),
				                margin_top + (imageSize + imagePadding)*(int) (index/rowSize)),
		                Image = resizedImg,
						BorderStyle = BorderStyle.FixedSingle
	                };
	                duplicatesPanel.Controls.Add(pb);
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Loading image {0} hit exception {1}", dupe.Filepath, ex);
                }

                Label label = new Label();
                label.Text = dupe.DisplayPath;
                label.Font = new Font(label.Font.FontFamily, 7.0f);
                label.Location = new Point(margin_left + (imageSize + imagePadding) * (index % rowSize) + 10, margin_top + (imageSize + imagePadding) * (int)(index / 3) + 200);
                label.Size = new Size(180, 20);
                label.TextAlign = ContentAlignment.MiddleCenter;
                duplicatesPanel.Controls.Add(label);

                index++;
            }
        }

	    private Size ThumbnailSize(Size original, int max)
	    {
		    try
		    {
				Size thumb = original;
			    float aspect = original.Width/(float) original.Height;
			    if (original.Width > original.Height)
			    {
				    if (original.Width > max)
				    {
					    thumb.Width = max;
					    thumb.Height = (int)(max/aspect);
				    }
			    }
			    else
				{
					if (original.Height > max)
					{
						thumb.Height = max;
						thumb.Width = (int)(max * aspect);
					}
			    }
				return thumb;

		    }
		    catch (Exception)
		    {
			    return new Size(max, max);
		    }
	    }

        void btnDelete_Click(object sender, EventArgs args)
        {
	        var toDelete = new List<string>();
	        foreach (var item in lbDuplicateSets.Items)
	        {
		        var dupeList = item as DuplicateList;
		        var dupes = dupeList.GetDuplicates();
		        for (int i = 1; i < dupes.Count; i++)
		        {
			        toDelete.Add(dupes[i].Filepath);
		        }
	        }

	        if (toDelete.Count > 0)
	        {
		        if (MessageBox.Show("You are about to delete " + toDelete.Count + " items.  Okay?", "Really Delete?",
			        MessageBoxButtons.YesNo) != DialogResult.Yes)
		        {
			        return;
		        }
	        }

	        foreach (string path in toDelete)
            {
                try
                {
                    File.Delete(path);
                }
                catch (Exception e)
                {
                    Console.WriteLine("Exception while deleting {0}: {1}", path, e);
                }
            }

            lbDuplicateSets.Items.Clear();
			duplicatesPanel.Controls.Clear();
        }
    }
}
