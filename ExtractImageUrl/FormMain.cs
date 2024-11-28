using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace ExtractImageUrl
{
  public partial class FormMain: Form
  {
    public FormMain()
    {
      InitializeComponent();
    }

    private void FormMain_Load(object sender, EventArgs e)
    {
      textBoxTarget.Text = string.Empty;
    }

    private void QuitterToolStripMenuItem_Click(object sender, EventArgs e)
    {
      Application.Exit();
    }

    private void ButtonExtract_Click(object sender, EventArgs e)
    {
      textBoxTarget.Text = string.Empty;
      var source = textBoxSource.Text;
      var imageExtensions = "jpg;png;svg";
      var sourceArray = source.Split(new char[] { '"' });
      var urlFound = new List<string>();
      foreach (var item in sourceArray)
      {
        if (item.StartsWith("https"))
        {
          urlFound.Add(item);
        }
      }

      foreach (var item in urlFound) 
      {
        textBoxTarget.Text += $"{item}{Environment.NewLine}";
      }
    }
  }
}
