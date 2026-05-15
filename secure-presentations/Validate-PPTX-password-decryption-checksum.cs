using System;
using System.IO;
using System.Text;
using System.Security.Cryptography;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace PresentationChecksumValidator
{
    class Program
    {
        static void Main(string[] args)
        {
            // Input file name, password and expected checksum (hex string)
            string pptFileName = "protected.pptx";
            string password = "myPassword";
            string expectedChecksum = "ABCDEF1234567890ABCDEF1234567890";

            // Build full path and verify existence
            string pptPath = Path.Combine(Directory.GetCurrentDirectory(), pptFileName);
            if (!File.Exists(pptPath))
            {
                Console.WriteLine("File does not exist: " + pptPath);
                return;
            }

            try
            {
                // Get presentation info and verify password
                Aspose.Slides.IPresentationInfo presentationInfo = Aspose.Slides.PresentationFactory.Instance.GetPresentationInfo(pptPath);
                bool isPasswordCorrect = presentationInfo.CheckPassword(password);
                Console.WriteLine("Password correct: " + isPasswordCorrect);
                if (!isPasswordCorrect)
                {
                    Console.WriteLine("Incorrect password.");
                    return;
                }

                // Load the presentation with the provided password
                Aspose.Slides.LoadOptions loadOptions = new Aspose.Slides.LoadOptions();
                loadOptions.Password = password;
                Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation(pptPath, loadOptions);

                // Save to a memory stream to compute checksum
                using (MemoryStream memoryStream = new MemoryStream())
                {
                    presentation.Save(memoryStream, Aspose.Slides.Export.SaveFormat.Pptx);
                    memoryStream.Position = 0;

                    using (MD5 md5 = MD5.Create())
                    {
                        byte[] hashBytes = md5.ComputeHash(memoryStream);
                        StringBuilder hashStringBuilder = new StringBuilder();
                        foreach (byte b in hashBytes)
                        {
                            hashStringBuilder.Append(b.ToString("X2"));
                        }
                        string actualChecksum = hashStringBuilder.ToString();
                        Console.WriteLine("Actual checksum: " + actualChecksum);
                        Console.WriteLine("Checksum matches expected: " + actualChecksum.Equals(expectedChecksum, StringComparison.OrdinalIgnoreCase));
                    }
                }

                // Save presentation before exit (no modifications made)
                presentation.Save(pptPath, Aspose.Slides.Export.SaveFormat.Pptx);
                presentation.Dispose();
            }
            catch (NotSupportedException)
            {
                // Format not supported
                Console.WriteLine("The file format is not supported.");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
        }
    }
}