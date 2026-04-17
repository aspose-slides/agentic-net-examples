using System;
using System.IO;
using System.Text;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace SignatureReport
{
    class Program
    {
        static void Main(string[] args)
        {
            // Directory containing presentations; can be passed as first argument
            string directoryPath = args.Length > 0 ? args[0] : "Presentations";

            if (!Directory.Exists(directoryPath))
            {
                Console.WriteLine("Directory does not exist: " + directoryPath);
                return;
            }

            string csvPath = Path.Combine(directoryPath, "signatures_report.csv");
            StringBuilder csvBuilder = new StringBuilder();
            csvBuilder.AppendLine("FileName,Signer,SignTime");

            string[] files = Directory.GetFiles(directoryPath);
            foreach (string file in files)
            {
                try
                {
                    using (Presentation pres = new Presentation(file))
                    {
                        if (pres.DigitalSignatures.Count > 0)
                        {
                            foreach (DigitalSignature signature in pres.DigitalSignatures)
                            {
                                string signer = signature.Certificate != null && signature.Certificate.SubjectName != null
                                    ? signature.Certificate.SubjectName.Name
                                    : string.Empty;

                                string line = string.Format("{0},{1},{2}",
                                    Path.GetFileName(file),
                                    signer,
                                    signature.SignTime.ToString("yyyy-MM-dd HH:mm"));

                                csvBuilder.AppendLine(line);
                            }
                        }

                        // Save presentation before exiting (preserves original format as PPTX)
                        pres.Save(file, SaveFormat.Pptx);
                    }
                }
                catch (Aspose.Slides.PptxUnsupportedFormatException)
                {
                    // Format not supported
                    Console.WriteLine("Unsupported format for file: " + file);
                }
                catch (Aspose.Slides.PptUnsupportedFormatException)
                {
                    // Format not supported
                    Console.WriteLine("Unsupported format for file: " + file);
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error processing file " + file + ": " + ex.Message);
                }
            }

            File.WriteAllText(csvPath, csvBuilder.ToString());
            Console.WriteLine("CSV report generated at: " + csvPath);
        }
    }
}