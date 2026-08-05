// -----------------------------------------------------------------------------
// Example: Log signature verification results during batch using C#
//
// Description:
// Demonstrates how to iterate through multiple PowerPoint presentations,
// detect digital signatures, verify each signature, and log the verification
// results to the console. The example uses Aspose.Slides for .NET to load
// presentations, access DigitalSignature objects, and optionally re‑save the
// files. It is suitable for batch processing scenarios where signature
// validation needs to be recorded.
//
// Keywords:
// C#, PowerPoint, PPTX, Aspose.Slides for .NET, Digital Signature, Verification,
// Batch Processing, Console Logging, Presentation Automation
//
// Use Cases:
// - Validate digital signatures across a collection of PPTX files.
// - Generate logs of signature validity for compliance auditing.
// - Integrate signature verification into automated PowerPoint workflows.
// - Ensure presentations are signed before distribution or publishing.
// -----------------------------------------------------------------------------
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
