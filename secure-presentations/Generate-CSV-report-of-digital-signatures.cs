using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace DigitalSignatureReport
{
    class Program
    {
        static void Main(string[] args)
        {
            // Input directory containing presentations
            string inputDirectory = "InputPresentations";
            if (!Directory.Exists(inputDirectory))
            {
                Console.WriteLine("Input directory does not exist.");
                return;
            }

            // Output CSV file path
            string outputFile = Path.Combine(inputDirectory, "DigitalSignaturesReport.csv");
            using (StreamWriter writer = new StreamWriter(outputFile, false))
            {
                // CSV header
                writer.WriteLine("FileName,SignatureSubject,SignTime");

                // Process each file in the directory
                string[] files = Directory.GetFiles(inputDirectory);
                foreach (string filePath in files)
                {
                    try
                    {
                        // Load presentation
                        Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation(filePath);

                        // List all digital signatures
                        if (presentation.DigitalSignatures.Count > 0)
                        {
                            foreach (Aspose.Slides.DigitalSignature signature in presentation.DigitalSignatures)
                            {
                                string line = string.Format("{0},{1},{2}",
                                    Path.GetFileName(filePath),
                                    signature.Certificate.SubjectName.Name,
                                    signature.SignTime.ToString("yyyy-MM-dd HH:mm"));
                                writer.WriteLine(line);
                            }
                        }

                        // Save presentation before exit (no modifications made)
                        presentation.Save(filePath, Aspose.Slides.Export.SaveFormat.Pptx);
                        presentation.Dispose();
                    }
                    catch (Exception ex)
                    {
                        // Handle unsupported format or other errors
                        // Comment: format not supported or other error
                    }
                }
            }
        }
    }
}