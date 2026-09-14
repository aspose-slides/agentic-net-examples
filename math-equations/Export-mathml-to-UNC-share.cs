// -----------------------------------------------------------------------------
// Example: Export MathML from a PowerPoint slide to a network share (UNC path)
// 
// Description:
// This console application creates a PowerPoint presentation using Aspose.Slides for .NET,
// adds a simple mathematical equation, exports the equation as MathML to a file located
// on a network share via a UNC path, and saves the presentation locally. It includes
// checks for file and directory existence and demonstrates proper resource disposal.
// 
// Keywords:
// C#, PowerPoint, PPTX, Aspose.Slides for .NET, MathML, UNC path, network share, export math paragraph
// 
// Use Cases:
// - Generate MathML for equations to be consumed by web services.
// - Store MathML files on a shared network location for collaborative editing.
// - Automate creation of presentations with embedded math and export their markup.
// Tested and Verified with Aspose.Slides for .NET v26.9.0.
// -----------------------------------------------------------------------------
using System;
using System.IO;

namespace AsposeSlidesMathMLExport
{
    public class Program
    {
        public static void Main(string[] args)
        {
            // Define the UNC path where MathML will be saved
            string uncFilePath = @"\\ServerName\SharedFolder\EquationMathML.xml";

            // Define local path for the generated presentation
            string localPresentationPath = Path.Combine(Directory.GetCurrentDirectory(), "MathPresentation.pptx");

            // Ensure the directory for the UNC file exists
            try
            {
                string uncDirectory = Path.GetDirectoryName(uncFilePath);
                if (!Directory.Exists(uncDirectory))
                {
                    Directory.CreateDirectory(uncDirectory);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Failed to create UNC directory: " + ex.Message);
                return;
            }

            // Create a new presentation
            Aspose.Slides.Presentation presentation = null;
            try
            {
                presentation = new Aspose.Slides.Presentation();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Failed to create presentation: " + ex.Message);
                return;
            }

            // Add a math shape to the first slide
            Aspose.Slides.IAutoShape mathShape = null;
            try
            {
                mathShape = presentation.Slides[0].Shapes.AddMathShape(0, 0, 500, 50);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Failed to add math shape: " + ex.Message);
                presentation.Dispose();
                return;
            }

            // Build the math paragraph a + b = c
            Aspose.Slides.MathText.IMathParagraph mathParagraph = null;
            try
            {
                Aspose.Slides.MathText.MathPortion mathPortion = (Aspose.Slides.MathText.MathPortion)mathShape.TextFrame.Paragraphs[0].Portions[0];
                mathParagraph = mathPortion.MathParagraph;

                Aspose.Slides.MathText.MathematicalText a = new Aspose.Slides.MathText.MathematicalText("a");
                Aspose.Slides.MathText.MathematicalText plus = new Aspose.Slides.MathText.MathematicalText("+");
                Aspose.Slides.MathText.MathematicalText b = new Aspose.Slides.MathText.MathematicalText("b");
                Aspose.Slides.MathText.MathematicalText equals = new Aspose.Slides.MathText.MathematicalText("=");
                Aspose.Slides.MathText.MathematicalText c = new Aspose.Slides.MathText.MathematicalText("c");

                mathParagraph.Add(a.Join(plus).Join(b).Join(equals).Join(c));
            }
            catch (Exception ex)
            {
                Console.WriteLine("Failed to construct math paragraph: " + ex.Message);
                presentation.Dispose();
                return;
            }

            // Export MathML to the UNC file
            FileStream mathMlStream = null;
            try
            {
                mathMlStream = new FileStream(uncFilePath, FileMode.Create, FileAccess.Write);
                mathParagraph.WriteAsMathMl(mathMlStream);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Failed to write MathML to UNC path: " + ex.Message);
            }
            finally
            {
                if (mathMlStream != null)
                {
                    mathMlStream.Close();
                    mathMlStream.Dispose();
                }
            }

            // Save the presentation locally
            try
            {
                presentation.Save(localPresentationPath, Aspose.Slides.Export.SaveFormat.Pptx);
                Console.WriteLine("Presentation saved to: " + localPresentationPath);
                Console.WriteLine("MathML exported to UNC path: " + uncFilePath);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Failed to save presentation: " + ex.Message);
            }
            finally
            {
                presentation.Dispose();
            }
        }
    }
}
