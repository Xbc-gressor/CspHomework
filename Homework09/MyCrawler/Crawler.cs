using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;

namespace MyCrawler
{
    class Crawler
    {
        // 解析网站内容的正则表达式
        public readonly string urlContentRegex = @"^(?<url>https?://(?<host>(www.)?[-a-zA-Z0-9@:%._+~#=]{1,256}.[a-zA-Z0-9()]{1,6})/?)(.*/)*(?<type>(.*(.html|.jsp|.aspx))?)$";
        // 过滤网站类型的正则表达式，保证只爬取htm/html/aspx/jsp等网页
        public string TypeRegex { get; set; } = @".*(.html|.jsp|.aspx)?$";
        // 过滤host，保证只爬取特定网站的页面
        public string HostRegex { get; set; } = @"";
        // 解析url的正则表达式
        public readonly string urlRefRegex = @"<a.+?(href|HREF)=[""'](?<url>[^""'#>]+)[""'].*>";

        // 爬虫结束事件
        public event Action<Crawler> CrawlerCompleted;
        // 当前页面下载事件
        public event Action<Crawler, string, string> CurPageDownloaded;

        // 最大爬取页数
        private int MaxPage { get; set; }
        // 起始url
        public string StartUrl { get; set; }

        // url列表
        private Hashtable urls = new Hashtable();
        // 已经爬取的个数
        private int count = 0;
        private Random rd = new Random();
        // 储存路径
        private string savePath = Environment.CurrentDirectory.ToString() + "//spiderData";

        public Crawler()
        {
            MaxPage = 100;
        }

        public void Crawl()
        {
            CurPageDownloaded(this, Environment.CurrentDirectory.ToString(), "工作目录");
            
            urls = new Hashtable();
            this.urls.Add(StartUrl, false);//加入初始页面

            while (true)
            {
                string current = null;
                foreach (string url in urls.Keys)
                {
                    if ((bool)urls[url]) continue;
                    current = url;
                }

                if (current == null || count > MaxPage) break;
                try
                {
                    string html = DownLoad(current);
                    urls[current] = true;
                    //解析
                    Parse(html, current);

                    //触发当前页下载成功事件
                    CurPageDownloaded(this, current, "SUCCESS：爬取成功");
                }
                catch (Exception e)
                {
                    //触发当前页下载失败事件
                    CurPageDownloaded(this, current, "ERROR：" + e.Message);
                }
            }

            // 爬虫完成
            CrawlerCompleted(this);
        }

        public string DownLoad(string url)
        {
            try
            {
                WebClient webClient = new WebClient();
                webClient.Encoding = Encoding.UTF8;
                string html = webClient.DownloadString(url);
                TimeSpan ts = DateTime.Now - new DateTime(1970, 1, 1, 0, 0, 0, 0);
                
                string fileName = "";
                if (Regex.IsMatch(url, @".*\.html?$"))
                {
                    fileName = Convert.ToInt64(ts.TotalSeconds).ToString() + rd.Next(10, 99).ToString() + ".html";
                }
                else if (Regex.IsMatch(url, @".*\.jsp?$"))
                {
                    fileName = Convert.ToInt64(ts.TotalSeconds).ToString() + rd.Next(10, 99).ToString() + ".jsp";
                }
                else if (Regex.IsMatch(url, @".*\.aspx?$"))
                {
                    fileName = Convert.ToInt64(ts.TotalSeconds).ToString() + rd.Next(10, 99).ToString() + ".aspx";
                }
                else
                {
                    fileName = Convert.ToInt64(ts.TotalSeconds).ToString() + rd.Next(10, 99).ToString();
                }
                if (!Directory.Exists(savePath))
                {
                    Directory.CreateDirectory(savePath);
                }
                File.WriteAllText(savePath + "//" + fileName, html, Encoding.UTF8);
                return html;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        private void Parse(string html, string pageUrl)
        {
            //获取html中的url集合
            MatchCollection matchUrls = new Regex(urlRefRegex).Matches(html);
            foreach (Match matchUrl in matchUrls)
            {
                string linkUrl = matchUrl.Groups["url"].Value;

                if (linkUrl == null || linkUrl.Equals(""))
                {
                    continue;
                }
                //转换为绝对路径   pageUrl当前页url
                linkUrl = ConvertUrl(linkUrl, pageUrl);
                //解析出host和file两个部分
                Match linkUrlMatch = Regex.Match(linkUrl, urlContentRegex);
                string host = linkUrlMatch.Groups["host"].Value;
                string type = linkUrlMatch.Groups["type"].Value;
                if (type.Equals(""))
                {
                    type = "index.html";
                }
                //过滤重复页面 过滤非html/aspx/jsp网页
                if (Regex.IsMatch(host, HostRegex) && Regex.IsMatch(type, TypeRegex) && (urls[linkUrl] == null))
                {
                    //将转换后的url加入字典   并设为false未爬取
                    urls[linkUrl] = false;
                }
            }
        }

        /**
         * 将相对路径转为绝对路径
         */
        private string ConvertUrl(string url, string baseUrl)
        {
            //绝对路径
            if (url.Contains("://"))
            {
                return url;
            }
            else if (url.StartsWith("//"))
            {
                return "http:" + url;
            }
            else if (url.StartsWith("/"))
            {
                String baseU = Regex.Match(baseUrl, urlContentRegex).Groups["url"].Value;
                return baseU.EndsWith("/") ? baseU + url.Substring(1) : baseU + url;
            }
            else if (url.StartsWith("./"))
            {
                return ConvertUrl(url.Substring(2), baseUrl);
            }
            else if (url.StartsWith("../"))
            {
                int idx = baseUrl.LastIndexOf('/');
                return ConvertUrl(url.Substring(3), baseUrl.Substring(0, idx));
            }
            int end = baseUrl.LastIndexOf("/");
            return baseUrl.Substring(0, end) + "/" + url;
        }
    
    }
}
