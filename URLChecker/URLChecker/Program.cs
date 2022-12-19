using AngleSharp;
using AngleSharp.Dom;
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

namespace URLChecker
{
    public static class Program
    {
        private static readonly IList<LinkPage> pageList = new List<LinkPage>();
        private static readonly ISet<string> visitPage = new HashSet<string>();
        private static readonly Queue<string> toVisit = new Queue<string>();
        private static readonly IDictionary<string, int> resultMap = new Dictionary<string, int>();

        private static readonly IConfiguration config = Configuration.Default.WithDefaultLoader().WithDefaultCookies();
        private static readonly IBrowsingContext browser = BrowsingContext.New(config);

        public static async Task Main()
        {
            toVisit.Enqueue(Constant.BASE_DOMAIN);
            Console.WriteLine("開始爬取網頁連結 ...");
            while (toVisit.Count > 0)
            {
                string link = toVisit.Dequeue();
                visitPage.Add(link);

                Console.WriteLine($"正在爬取連結 : {link}");
                await loadPage(link);
            }

            Console.WriteLine("正在收集結果資料 ...");
            collectResult();

            Console.WriteLine("正在輸出結果至檔案 ...");
            writeToFile(Constant.OUTPUT_FILE_NAME);

            Console.WriteLine("處理完成 !");
            Console.Write("請按任意按鍵繼續 ... ");
            Console.ReadKey(true);
        }

        public static async Task loadPage(string link)
        {
            int code;
            Url url = new Url(link);
            IDocument document = null;
            try
            {
                document = await browser.OpenAsync(url);
                code = document.ToHtml() == Constant.TIMEOUT_STRING ? Constant.TIMEOUT : (int)document.StatusCode;
            }
            catch (Exception ex)
            {
                code = Constant.ERROR;
                Console.WriteLine($"發生例外狀況 : {ex.Message}");
            }
            resultMap.Add(link, code);

            if (document == null)
            {
                return;
            }
            if (!link.StartsWith(Constant.BASE_DOMAIN))
            {
                return;
            }
            LinkPage data = new LinkPage(link);

            IHtmlCollection<IElement> collection = document.QuerySelectorAll("a");
            foreach (IElement element in collection)
            {
                string name = element.Text();
                if (string.IsNullOrWhiteSpace(name))
                {
                    name = "無名稱";
                }

                string href = element.GetAttribute("href");
                if (href == null || href.Contains("#") || href.Contains("mailto:"))
                {
                    continue;
                }
                else if (href.Contains("javascript"))
                {
                    const string LIST_PREFIX = "javascript:list(";
                    if (href.Contains(LIST_PREFIX))
                    {
                        const string PAGE_PREFIX = "&page=";
                        href = $"{(link.Contains(PAGE_PREFIX) ? link.Split(new string[] { PAGE_PREFIX }, StringSplitOptions.RemoveEmptyEntries)[0] : link)}{PAGE_PREFIX}{href.Substring(LIST_PREFIX.Length).Split(',')[0]}";
                    }
                    else
                    {
                        // 過濾以下項目
                        // imgprview (圖片預覽)
                        // SetFont (字型大小設定)
                        // openprint() (友善列印)
                        // document.getElementById("accesskey_u").focus() (返回頁首)
                        // history.go(-1) (回到上一頁)
                        continue;
                    }
                }
                else if (!href.StartsWith("http"))
                {
                    href = $"{Constant.BASE_DOMAIN}{href}";
                }

                if (!visitPage.Contains(href))
                {
                    toVisit.Enqueue(href);
                    visitPage.Add(href);
                }

                LinkStatus status = new LinkStatus(name, href);
                data.linkData.Add(status);
            }
            pageList.Add(data);
        }

        public static void collectResult()
        {
            foreach (LinkPage page in pageList)
            {
                foreach (LinkStatus data in page.linkData)
                {
                    data.code = resultMap[data.link];
                }
            }
        }

        public static string getHTTPCodeString(int code)
        {
            switch (code)
            {
                case Constant.TIMEOUT:
                    {
                        return "超時";
                    }
                case Constant.ERROR:
                    {
                        return "錯誤";
                    }
                default:
                    {
                        return code.ToString();
                    }
            }
        }

        public static bool checkHasError(LinkPage page)
        {
            foreach (LinkStatus data in page.linkData)
            {
                if (data.code >= 400)
                {
                    return true;
                }
            }
            return false;
        }

        public static void writeToFile(string path)
        {
            using (FileStream fs = new FileStream(path, FileMode.Create, FileAccess.Write))
            {
                using (StreamWriter sw = new StreamWriter(fs))
                {
                    foreach (LinkPage page in pageList)
                    {
                        if (checkHasError(page))
                        {
                            sw.WriteLine($"請求網址 : {page.parent}");
                            foreach (LinkStatus data in page.linkData)
                            {
                                if (data.code >= 400)
                                {
                                    int code = data.code;
                                    sw.WriteLine($"網頁連結 : {data.name}，網址 : {data.link}，錯誤代碼 : {getHTTPCodeString(code)}");
                                }
                            }
                            sw.WriteLine();
                        }
                    }
                }
            }
        }
    }
}