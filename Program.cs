using System;
using System.IO;
using System.Net;
using HtmlAgilityPack;

class CustomWebClient : WebClient
{
    protected override WebRequest GetWebRequest(Uri address)
    {
        HttpWebRequest request = (HttpWebRequest)base.GetWebRequest(address);
        if (request != null)
        {
            request.AllowAutoRedirect = true;
        }
        return request;
    }
}

class Program
{
    static void Main()
    {
        Console.Write("Enter the URL of the website: ");
        string url = Console.ReadLine();

        if (Uri.TryCreate(url, UriKind.Absolute, out _))
        {
            string downloadPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Downloads");
            DownloadPdfFiles(url, downloadPath);

            Console.WriteLine("Press any key to exit.");
            Console.ReadKey();
        }
        else
        {
            Console.WriteLine("Invalid URL. Please enter a valid URL. Press any key to exit.");
            Console.ReadKey();
        }
    }


    static void DownloadPdfFiles(string url, string downloadPath)
    {
        var web = new HtmlWeb();
        var doc = web.Load(url);

        foreach (var link in doc.DocumentNode.SelectNodes("//a[@href]"))
        {
            var href = link.GetAttributeValue("href", "");

            // Check if the link points to a PDF file
            if (href.EndsWith(".pdf", StringComparison.OrdinalIgnoreCase))
            {
                DownloadFile(url, href, downloadPath, Path.GetFileName(href));
            }
        }

        Console.WriteLine("PDF download completed. Check the 'Downloads' folder.");
    }

    static void DownloadFile(string baseUrl, string relativeUrl, string downloadPath, string fileName)
    {
        using (var client = new CustomWebClient())
        {
            if (!Directory.Exists(downloadPath))
            {
                Directory.CreateDirectory(downloadPath);
            }

            string fileUrl = new Uri(new Uri(baseUrl), relativeUrl).AbsoluteUri;
            string filePath = Path.Combine(downloadPath, fileName);

            HttpWebResponse response = null; // Declare the response variable

            try
            {
                Console.WriteLine($"Downloading {fileName}...");
                client.DownloadFile(fileUrl, filePath);
                Console.WriteLine($"Download complete: {fileName}");
            }
            catch (WebException ex)
            {
                if (ex.Response is HttpWebResponse)
                {
                    response = (HttpWebResponse)ex.Response;
                }

                if (response != null && response.StatusCode == HttpStatusCode.NotFound)
                {
                    Console.WriteLine($"File not found (404): {fileUrl}");
                }
                else
                {
                    Console.WriteLine($"WebException: {ex.Message}");
                    if (response != null)
                    {
                        Console.WriteLine($"HTTP Status Code: {response.StatusCode}");
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
            }
        }
    }
}
