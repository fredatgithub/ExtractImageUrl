using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Linq;

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
      TextBoxSource_TextChanged(sender, e);
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
      var sourceArray = source.Split('"');
      var urlFound = new List<string>();
      foreach (var item in sourceArray)
      {
        if (item.StartsWith("https") && IsAPicture(item, imageExtensions))
        {
          urlFound.Add(item);
        }
      }

      foreach (var item in urlFound)
      {
        textBoxTarget.Text += $"{item}{Environment.NewLine}";
      }
    }

    private static bool IsAPicture(string url, string imageExtensions)
    {
      bool result = false;
      foreach (var _ in from item in imageExtensions.Split(';')
                        where url.EndsWith(item)
                        select new { })
      {
        result = true;
      }

      return result;
    }

    private void TextBoxSource_TextChanged(object sender, EventArgs e)
    {
      buttonExtract.Enabled = textBoxSource.Text.Length > 0;
    }
  }
}
