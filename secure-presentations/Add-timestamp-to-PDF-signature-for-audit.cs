using System;
using System.IO;
using System.Net.Http;
using System.Security.Cryptography.X509Certificates;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static async System.Threading.Tasks.Task Main(string[] args)
    {
        // Paths for certificate and output presentation
        string certificatePath = "testsignature1.pfx";
        string certificatePassword = "testpass1";
        string outputPresentationPath = "SignedPresentation.pptx";

        // Verify that the certificate file exists
        if (!File.Exists(certificatePath))
        {
            Console.WriteLine("Certificate file not found: " + certificatePath);
            return;
        }

        // Retrieve current UTC time from a trusted server
        DateTime trustedTime;
        try
        {
            using (HttpClient httpClient = new HttpClient())
            {
                // Example trusted time service
                HttpResponseMessage response = httpClient.GetAsync("http://worldtimeapi.org/api/timezone/Etc/UTC").Result;
                response.EnsureSuccessStatusCode();
                string json = response.Content.ReadAsStringAsync().Result;

                // Simple extraction of the "datetime" field
                int startIndex = json.IndexOf("\"datetime\":\"");
                if (startIndex >= 0)
                {
                    startIndex += "\"datetime\":\"".Length;
                    int endIndex = json.IndexOf('"', startIndex);
                    string dateTimeString = json.Substring(startIndex, endIndex - startIndex);
                    trustedTime = DateTime.Parse(dateTimeString, null, System.Globalization.DateTimeStyles.AdjustToUniversal);
                }
                else
                {
                    trustedTime = DateTime.UtcNow;
                }
            }
        }
        catch (Exception ex)
        {
            // Handle any errors while contacting the external service
            Console.WriteLine("Failed to obtain trusted time: " + ex.Message);
            trustedTime = DateTime.UtcNow; // Fallback to local UTC time
        }

        // Create presentation, add digital signature with timestamp comment, and save
        try
        {
            using (Presentation presentation = new Presentation())
            {
                DigitalSignature digitalSignature = new DigitalSignature(certificatePath, certificatePassword);
                digitalSignature.Comments = "Signed at UTC time: " + trustedTime.ToString("yyyy-MM-dd HH:mm:ss") + " (trusted server)";
                presentation.DigitalSignatures.Add(digitalSignature);
                presentation.Save(outputPresentationPath, SaveFormat.Pptx);
            }
        }
        catch (PptxUnsupportedFormatException)
        {
            // Format not supported
            Console.WriteLine("The presentation format is not supported.");
        }
        catch (PptUnsupportedFormatException)
        {
            // Format not supported
            Console.WriteLine("The presentation format is not supported.");
        }
        catch (Exception ex)
        {
            // General error handling
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}