using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace DigitalSignatureVerification
{
    class Program
    {
        static void Main(string[] args)
        {
            // Determine input file path
            string inputPath;
            if (args.Length > 0 && !String.IsNullOrEmpty(args[0]))
            {
                inputPath = args[0];
            }
            else
            {
                inputPath = "SignedPresentation.pptx";
            }

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.WriteLine("Input file does not exist: " + inputPath);
                return;
            }

            // Define intermediate file for format conversion
            string intermediatePath = Path.Combine(Path.GetDirectoryName(inputPath) ?? "", "ConvertedPresentation.pptx");

            try
            {
                // Load the signed presentation
                using (Presentation pres = new Presentation(inputPath))
                {
                    // Save presentation to another format (PPTX) as conversion step
                    pres.Save(intermediatePath, SaveFormat.Pptx);
                }

                // Load the converted presentation to verify signatures
                using (Presentation convertedPres = new Presentation(intermediatePath))
                {
                    if (convertedPres.DigitalSignatures.Count > 0)
                    {
                        bool allValid = true;
                        Console.WriteLine("Signatures used to sign the presentation:");
                        foreach (DigitalSignature signature in convertedPres.DigitalSignatures)
                        {
                            string subject = signature.Certificate.SubjectName.Name;
                            string signTime = signature.SignTime.ToString("yyyy-MM-dd HH:mm");
                            string validity = signature.IsValid ? "VALID" : "INVALID";
                            Console.WriteLine(subject + ", " + signTime + " -- " + validity);
                            allValid &= signature.IsValid;
                        }

                        if (allValid)
                        {
                            Console.WriteLine("Presentation is genuine, all signatures are valid.");
                        }
                        else
                        {
                            Console.WriteLine("Presentation has been modified since signing.");
                        }
                    }
                    else
                    {
                        Console.WriteLine("No digital signatures found in the presentation.");
                    }

                    // Save the presentation before exit (as required)
                    convertedPres.Save(intermediatePath, SaveFormat.Pptx);
                }
            }
            catch (NotSupportedException)
            {
                // Format not supported
                Console.WriteLine("The specified file format is not supported for this operation.");
            }
            catch (Exception ex)
            {
                // General exception handling
                Console.WriteLine("An error occurred: " + ex.Message);
            }
        }
    }
}