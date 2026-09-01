// -----------------------------------------------------------------------------

// Tested and verified with Aspose.Slides for .NET 26.8.0.
// Example: Log conversion duration to XML file using C#

//

// Description:

// Demonstrates how to batch convert PowerPoint presentations to PPTX format,

// measure each conversion's duration, and log the results to an XML file using

// Aspose.Slides for .NET. The example processes all files in a specified input

// directory, saves converted files to an output directory, and records success

// or error information along with conversion time in a structured XML report.

// This pattern can be used to monitor performance, audit batch operations, or

// integrate conversion logging into automated workflows.

//

// Keywords:

// C#, Aspose.Slides for .NET, PowerPoint, PPTX, batch conversion, conversion

// duration, XML logging, presentation processing, automation, file I/O

//

// Use Cases:

// - Automate batch conversion of presentations while tracking performance.

// - Generate XML reports of conversion outcomes for auditing or monitoring.

// - Integrate conversion timing into CI/CD pipelines or server-side services.

// - Diagnose and handle unsupported formats or conversion errors.

// -----------------------------------------------------------------------------



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

