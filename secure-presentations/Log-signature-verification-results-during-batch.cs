using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        string[] inputFiles = new string[] { "Presentation1.pptx", "Presentation2.pptx" };
        foreach (string filePath in inputFiles)
        {
            if (!File.Exists(filePath))
            {
                Console.WriteLine("File not found: " + filePath);
                continue;
            }

            try
            {
                using (Presentation pres = new Presentation(filePath))
                {
                    if (pres.DigitalSignatures.Count > 0)
                    {
                        foreach (DigitalSignature signature in pres.DigitalSignatures)
                        {
                            LogSignatureResult(signature);
                        }
                    }
                    else
                    {
                        Console.WriteLine("No digital signatures found in: " + filePath);
                    }

                    // Save presentation before exit (no modifications)
                    pres.Save(filePath, SaveFormat.Pptx);
                }
            }
            catch (NotSupportedException)
            {
                // Format not supported
                Console.WriteLine("File format not supported: " + filePath);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error processing file " + filePath + ": " + ex.Message);
            }
        }
    }

    static void LogSignatureResult(DigitalSignature signature)
    {
        string subject = signature.Certificate.SubjectName.Name;
        string time = signature.SignTime.ToString("yyyy-MM-dd HH:mm");
        string validity = signature.IsValid ? "VALID" : "INVALID";
        Console.WriteLine(subject + ", " + time + " -- " + validity);
    }
}