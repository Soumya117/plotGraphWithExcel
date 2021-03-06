﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Windows.Forms;

namespace datagraph
{
  public static class FormUtil
  {
    public static void clearTextBoxes(Control.ControlCollection controls)
    {
      Action<Control.ControlCollection> func = null;
      func = (controls1) =>
      {
        foreach (Control control in controls1)
          if (control is TextBox)
            (control as TextBox).Clear();
          else
            func(control.Controls);
      };
      func(controls);
    }

    public static void verifyTextBoxInputIsNum(TextBox textBox)
    {
      float textValue;
      if (!String.IsNullOrEmpty(textBox.Text) && !float.TryParse(textBox.Text, out textValue))
      {
        MessageBox.Show("Only Numbers are allowed", "Inform", MessageBoxButtons.OK, MessageBoxIcon.Error);
        textBox.ResetText();
      }
    }

    public static string setFilePath(string selectedPath, bool isDefaultLoc, bool isRoot)
    {
      string path;
      if (isDefaultLoc == false)
      {
        path = @selectedPath + "Export";
      }
      else if (isRoot == false)
      {
        path = @selectedPath + "\\Export";
      }
      else
      {
        path = "C:\\Export";
      }
      return path;
    }

    public static void deleteDirectory(string path)
    {
      foreach (string filename in Directory.GetFiles(path))
      {
        File.Delete(filename);
      }
      foreach (string subfolder in Directory.GetDirectories(path))
      {
        deleteDirectory(subfolder);
      }
      Directory.Delete(path);
    }
  }
}
