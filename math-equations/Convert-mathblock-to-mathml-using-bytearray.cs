using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.MathText;

namespace AsposeSlidesMathMLExport
{
    class Program
    {
        static void Main(string[] args)
        {
            string inputPath = "input.pptx";
            if (!File.Exists(inputPath))
            {
                Console.WriteLine("Input file does not exist.");
                return;
            }

            Presentation pres = null;
            try
            {
                pres = new Presentation(inputPath);
            }
            catch (NotSupportedException)
            {
                // format not supported
                Console.WriteLine("File format not supported.");
                return;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error loading presentation: " + ex.Message);
                return;
            }

            MathParagraph mathParagraph = null;
            foreach (ISlide slide in pres.Slides)
            {
                foreach (IShape shape in slide.Shapes)
                {
                    if (shape is MathParagraph)
                    {
                        mathParagraph = shape as MathParagraph;
                        break;
                    }
                }
                if (mathParagraph != null)
                {
                    break;
                }
            }

            if (mathParagraph == null)
            {
                Console.WriteLine("No MathParagraph found in the presentation.");
            }
            else
            {
                using (MemoryStream memoryStream = new MemoryStream())
                {
                    mathParagraph.WriteAsMathMl(memoryStream);
                    byte[] mathMlBytes = memoryStream.ToArray();
                    // Example: write the MathML byte array to a file for further processing
                    File.WriteAllBytes("mathml_output.xml", mathMlBytes);
                }
            }

            // Save the presentation before exiting
            try
            {
                pres.Save("output.pptx", SaveFormat.Pptx);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error saving presentation: " + ex.Message);
            }
            finally
            {
                pres.Dispose();
            }
        }
    }
}