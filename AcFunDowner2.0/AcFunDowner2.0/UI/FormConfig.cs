﻿using System;
using System.Windows.Forms;
using Kaedei.AcFunDowner.Properties;

namespace Kaedei.AcFunDowner
{
    public partial class FormConfig : Form
    {
        public FormConfig()
        {
            InitializeComponent();
        }

        private void FormConfig_Load(object sender, EventArgs e)
        {
            this.Icon = Resources.ac;
            if (Config.setting.AutoDownAllSection) 
                chkDownAllParts.Checked = true;
            if (Config.setting.DownSub) 
                chkDownSub.Checked = true;
            if (Config.setting.OpenFolderAfterComplete) 
                chkOpenFolder.Checked = true;
            if (Config.setting.PlaySound) 
                chkPlaySound.Checked = true;
            numCacheSize.Value = Config.setting.CacheSize;
            lnkSavePath.Text = Config.setting.SavePath;
            txtServerIP.Text = Config.setting.ServerIP;
				chkEnableLog.Checked = Config.setting.EnableLog;
				chkCheckUrl.Checked = Config.setting.AutoCheckUrl;
				chkWatch.Checked = Config.setting.WatchClipboardEnabled;
				chkDeleteFile.Checked = Config.setting.DeleteTaskAndFile;
				chkShowTrayIcon.Checked = Config.setting.ShowTrayIcon;
				chkEnableWin7.Checked = Config.setting.EnableWindows7Feature;
				chkShowBigButton.Checked = Config.setting.ShowBigStartButton;
				switch (Config.setting.SearchEngine)
				{
					case "Google":
						txtSearchText.Text = "AcFun站内搜索";
						break;
					case "BiliBili":
						txtSearchText.Text = "BiliBili站内搜索";
						break;
					case "Bing":
						txtSearchText.Text = "AcFun视频搜索 - Bing";
						break;
					case "Baidu":
						txtSearchText.Text = "AcFun视频搜索 - 百度";
						break;
					default:
						txtSearchText.Text = Config.setting.SearchQuery;
						break;
				}
				
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
			  //保存设置
            Config.setting.AutoDownAllSection = chkDownAllParts.Checked;
            Config.setting.DownSub = chkDownSub.Checked;
            Config.setting.OpenFolderAfterComplete = chkOpenFolder.Checked;
            Config.setting.PlaySound = chkPlaySound.Checked;
            Config.setting.CacheSize=(Int32)numCacheSize.Value ;
            Config.setting.SavePath=lnkSavePath.Text ;
            Config.setting.ServerIP= txtServerIP.Text ;
				Config.setting.EnableLog = chkEnableLog.Checked;
				Config.setting.AutoCheckUrl = chkCheckUrl.Checked;
				Config.setting.WatchClipboardEnabled = chkWatch.Checked;
				Config.setting.DeleteTaskAndFile = chkDeleteFile.Checked;
				Config.setting.ShowTrayIcon = chkShowTrayIcon.Checked;
				Config.setting.EnableWindows7Feature = chkEnableWin7.Checked;
				Config.setting.ShowBigStartButton = chkShowBigButton.Checked;
				string tmp = txtSearchText.Text;
				if (tmp != "AcFun站内搜索" && tmp != "BiliBili站内搜索" && tmp != "AcFun视频搜索 - Bing" && tmp != "AcFun视频搜索 - 百度")
				{
					Config.setting.SearchEngine = "Custom";
					Config.setting.SearchQuery = txtSearchText.Text;
				}
            Config.SaveSettings();
            this.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void lnkSavePath_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
			  //选择文件夹
            FolderBrowserDialog fbd = new FolderBrowserDialog();
            fbd.ShowNewFolderButton=true;
            fbd.Description="请设置视频默认保存的文件夹：";
            fbd.SelectedPath=lnkSavePath.Text ;
            if (fbd.ShowDialog() == DialogResult.OK) 
                lnkSavePath.Text = fbd.SelectedPath;
         }

		  private void txtServerIP_KeyPress(object sender, KeyPressEventArgs e)
		  {
			  //e.Handled = true;
		  }

        private void lnkLog_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
			  if (Config.setting.EnableLog)
				  System.Diagnostics.Process.Start(Logging.LogFilePath);
			  else
				  MessageBox.Show("当前禁止记录日志文件,请查看应用程序设置", "日志文件被禁止", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

		  private void lnkMore_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
		  {
			  System.Diagnostics.Process.Start("notepad.exe",
				  System.IO.Path.Combine(
				  Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData),
				  @"Kaedei\AcFunDowner\config.xml"));
			  //System.Diagnostics.Process.Start(@"http://blog.sina.com.cn/s/blog_58c506600100h7p9.html");
		  }


    }
}