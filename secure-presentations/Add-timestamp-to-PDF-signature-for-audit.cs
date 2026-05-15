using System;
using System.IO;
using System.Net.Http;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        string inputPath = Path.Combine(Directory.GetCurrentDirectory(), "input.pptx");
        string outputPath = Path.Combine(Directory.GetCurrentDirectory(), "SignedOutput.pptx");
        string pfxPath = Path.Combine(Directory.GetCurrentDirectory(), "certificate.pfx");
        string pfxPassword = "password";

        if (!File.Exists(inputPath))
        {
            Console.WriteLine("Input file does not exist.");
            return;
        }
        if (!File.Exists(pfxPath))
        {
            Console.WriteLine("Certificate file does not exist.");
            return;
        }

        DateTime serverTime;
        try
        {
            using (HttpClient client = new HttpClient())
            {
                HttpResponseMessage response = client.GetAsync("http://worldtimeapi.org/api/ip").Result;
                response.EnsureSuccessStatusCode();
                string json = response.Content.ReadAsStringAsync().Result;
                int idx = json.IndexOf("\"datetime\":\"");
                if (idx >= 0)
                {
                    int start = idx + "\"datetime\":\"".Length;
                    int end = json.IndexOf('"', start);
                    string datetimeStr = json.Substring(start, end - start);
                    serverTime = DateTime.Parse(datetimeStr, null, System.Globalization.DateTimeStyles.RoundtripKind);
                }
                else
                {
                    serverTime = DateTime.UtcNow;
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Failed to retrieve server time: " + ex.Message);
            serverTime = DateTime.UtcNow;
        }

        using (Presentation pres = new Presentation(inputPath))
        {
            pres.CurrentDateTime = serverTime;

            Aspose.Slides.DigitalSignature signature = new Aspose.Slides.DigitalSignature(pfxPath, pfxPassword);
            signature.Comments = "Signed at " + serverTime.ToString("o");
            pres.DigitalSignatures.Add(signature);
            pres.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
        }
    }
}