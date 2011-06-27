﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Kaedei.AcDown.Interface.Forms
{
   public partial class FormPassword : Form
   {
      StringBuilder pw;
      public FormPassword(StringBuilder password)
      {
         InitializeComponent();
         pw = password;
      }

      private void btnOK_Click(object sender, EventArgs e)
      {
         pw.Append(txtPassword.Text);
         this.Close();
      }


   }
}
