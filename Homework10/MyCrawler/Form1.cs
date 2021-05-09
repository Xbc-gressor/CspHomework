using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MyCrawler
{
    public partial class Form1 : Form
    {
        Crawler crawler = new Crawler();
        public Form1()
        {
            InitializeComponent();
            crawler.CrawlerCompleted += this.CrawlerCompleted;
            crawler.CurPageDownloaded += this.CurPageDownloaded;
        }

        private void CrawlerCompleted(Crawler crawler)
        {
            if (this.resBox.InvokeRequired)
            {
                Action<String> action = this.AddRes;
                this.Invoke(action, new object[] { "爬虫已停止...." + "\r\n" });
            }else
            {
                this.AddRes("爬虫已停止...." + "\r\n");
            }
        }
        
        private void CurPageDownloaded(Crawler crawler, string url, string info)
        {
            string pageInfo = $"[网页={url}, 爬取状态={info}]";
            if (this.resBox.InvokeRequired)
            {
                Action<String> action = this.AddRes;
                this.Invoke(action, new object[] { pageInfo + "\r\n" });
            }
            else
            {
                this.AddRes(pageInfo + "\r\n");
            }
        }

        private void AddRes(string res)
        {
            this.resBox.Items.Add(res);
        }
        async private void startButton_Click(object sender, EventArgs e)
        {
            crawler.StartUrl = this.urlTextBox.Text;
            this.resBox.Items.Clear();
            this.resBox.Items.Add("爬虫启动！" + "\r\n");

            Match match = Regex.Match(crawler.StartUrl, crawler.urlContentRegex);

            if (match.Length == 0)
            {
                this.resBox.Items.Add("无效url！" + "\r\n");
            }
            else
            {
                string host = match.Groups["host"].Value;
                crawler.HostRegex = "^" + host + "$";
                Task task = Task.Run(() => crawler.Crawl());
                await task;
            }

        }
    }
}
