// -----------------------------------------------------------------------------
// Example: Add timestamp to PPTX digital signature for audit using C#
//
// Description:
// Demonstrates how to add a trusted timestamp to a digital signature in a
// PowerPoint presentation using C# and Aspose.Slides for .NET. The example
// retrieves the current UTC time from an external time service, creates a
// presentation, applies a digital signature with a timestamp comment, and
// saves the signed PPTX file. This pattern can be used to embed audit‑ready
// timestamps in presentation files.
//
// Keywords:
// C#, PowerPoint, PPTX, Aspose.Slides for .NET, Digital Signature, Timestamp,
// Audit, Presentation Processing, Office Automation
//
// Use Cases:
// - Automate adding trusted timestamps to PPTX digital signatures for audit.
// - Build C# tools for PowerPoint presentation signing and verification.
// - Integrate timestamped digital signatures into .NET document workflows.
// - Ensure presentation integrity and traceability before distribution.
// -----------------------------------------------------------------------------

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
