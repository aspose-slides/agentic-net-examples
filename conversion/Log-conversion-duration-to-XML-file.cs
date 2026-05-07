using System;
using System.IO;
using System.Diagnostics;
using System.Xml.Linq;
using Aspose.Slides.Export;

namespace BatchConversion
{
    class Program
    {
        static void Main(string[] args)
        {
            string inputDirectory = "InputPresentations";
            string outputDirectory = "ConvertedPresentations";
            string resultXmlPath = "ConversionResults.xml";

            if (!Directory.Exists(inputDirectory))
            {
                Console.WriteLine("Input directory does not exist.");
                return;
            }

            if (!Directory.Exists(outputDirectory))
            {
                Directory.CreateDirectory(outputDirectory);
            }

            XDocument resultDoc = new XDocument(new XElement("Conversions"));
            string[] files = Directory.GetFiles(inputDirectory);
            foreach (string inputPath in files)
            {
                if (!File.Exists(inputPath))
                {
                    continue;
                }

                string fileName = Path.GetFileNameWithoutExtension(inputPath);
                string outputPath = Path.Combine(outputDirectory, fileName + ".pptx");
                Stopwatch sw = new Stopwatch();
                try
                {
                    sw.Start();
                    using (Aspose.Slides.Presentation pres = new Aspose.Slides.Presentation(inputPath))
                    {
                        pres.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
                    }
                    sw.Stop();
                    XElement entry = new XElement("Conversion",
                        new XAttribute("Input", inputPath),
                        new XAttribute("Output", outputPath),
                        new XAttribute("DurationMs", sw.ElapsedMilliseconds));
                    resultDoc.Root.Add(entry);
                }
                catch (NotSupportedException)
                {
                    // format not supported
                    XElement entry = new XElement("Conversion",
                        new XAttribute("Input", inputPath),
                        new XAttribute("Error", "Format not supported"));
                    resultDoc.Root.Add(entry);
                }
                catch (Exception ex)
                {
                    // other errors
                    XElement entry = new XElement("Conversion",
                        new XAttribute("Input", inputPath),
                        new XAttribute("Error", ex.Message));
                    resultDoc.Root.Add(entry);
                }
            }

            resultDoc.Save(resultXmlPath);
        }
    }
}