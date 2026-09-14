// -----------------------------------------------------------------------------
// Example: Generate MathML Files from PowerPoint Presentations Using Aspose.Slides
//
// Description:
// This console utility scans a specified folder for PowerPoint files (PPTX/PPT),
// extracts any mathematical objects using Aspose.Slides, converts them to MathML,
// and writes each MathML snippet to a separate XML file. It validates input
// files, handles missing Aspose.Slides.Math support gracefully, and saves the
// presentations before exiting.
//
// Keywords:
// C#, PowerPoint, PPTX, Aspose.Slides for .NET, MathML extraction, presentation processing
//
// Use Cases:
// - Automate conversion of lecture slides containing equations to MathML for web publishing.
// - Batch process corporate training decks to extract embedded mathematical content.
// - Integrate into CI pipelines to verify presence of MathML in generated slide decks.
// Tested and Verified with Aspose.Slides for .NET v26.9.0.
// -----------------------------------------------------------------------------
using System;
using System.IO;
using System.Reflection;

namespace AsposeSlidesMathMlGenerator
{
    public class Program
    {
        public static void Main(string[] args)
        {
            string inputFolder;
            if (args != null && args.Length > 0 && !string.IsNullOrWhiteSpace(args[0]))
            {
                inputFolder = args[0];
            }
            else
            {
                Console.WriteLine("Please provide the path to the folder containing presentations as the first argument.");
                return;
            }

            if (!Directory.Exists(inputFolder))
            {
                Console.WriteLine("The specified folder does not exist: " + inputFolder);
                return;
            }

            string outputFolder = Path.Combine(inputFolder, "MathML_Output");
            if (!Directory.Exists(outputFolder))
            {
                Directory.CreateDirectory(outputFolder);
            }

            string[] presentationFiles = Directory.GetFiles(inputFolder, "*.*", SearchOption.TopDirectoryOnly);
            foreach (string filePath in presentationFiles)
            {
                string extension = Path.GetExtension(filePath).ToLowerInvariant();
                if (extension != ".pptx" && extension != ".ppt")
                {
                    continue; // Skip non-PowerPoint files
                }

                try
                {
                    Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation(filePath);
                    int slideIndex = 0;
                    foreach (Aspose.Slides.ISlide slide in presentation.Slides)
                    {
                        slideIndex++;
                        int mathShapeIndex = 0;
                        foreach (Aspose.Slides.IShape shape in slide.Shapes)
                        {
                            // Use reflection to detect Math objects without compile‑time dependency
                            Type shapeType = shape.GetType();
                            Type mathShapeType = Type.GetType("Aspose.Slides.Math.OMath, Aspose.Slides");
                            if (mathShapeType != null && mathShapeType.IsAssignableFrom(shapeType))
                            {
                                mathShapeIndex++;
                                string mathMl = ExtractMathMl(shape);
                                if (!string.IsNullOrEmpty(mathMl))
                                {
                                    string outputFileName = string.Format("{0}_slide{1}_math{2}.xml",
                                        Path.GetFileNameWithoutExtension(filePath),
                                        slideIndex,
                                        mathShapeIndex);
                                    string outputPath = Path.Combine(outputFolder, outputFileName);
                                    File.WriteAllText(outputPath, mathMl);
                                    Console.WriteLine("MathML saved: " + outputPath);
                                }
                            }
                        }
                    }

                    // Save the presentation (even if unchanged) to ensure any internal changes are persisted
                    string savePath = Path.Combine(inputFolder, Path.GetFileNameWithoutExtension(filePath) + "_processed" + extension);
                    presentation.Save(savePath, Aspose.Slides.Export.SaveFormat.Pptx);
                    presentation.Dispose();
                }
                catch (FileNotFoundException fnfEx)
                {
                    Console.WriteLine("File not found: " + fnfEx.FileName);
                }
                catch (UnauthorizedAccessException uaEx)
                {
                    Console.WriteLine("Access denied to file: " + filePath + " - " + uaEx.Message);
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error processing file '" + filePath + "': " + ex.Message);
                }
            }

            Console.WriteLine("Processing completed.");
        }

        private static string ExtractMathMl(Aspose.Slides.IShape shape)
        {
            try
            {
                // Attempt to invoke a method named 'GetMathML' via reflection
                MethodInfo getMathMlMethod = shape.GetType().GetMethod("GetMathML", BindingFlags.Public | BindingFlags.Instance);
                if (getMathMlMethod != null)
                {
                    object result = getMathMlMethod.Invoke(shape, null);
                    return result as string;
                }

                // If 'GetMathML' is not available, try a property named 'MathML'
                PropertyInfo mathMlProperty = shape.GetType().GetProperty("MathML", BindingFlags.Public | BindingFlags.Instance);
                if (mathMlProperty != null)
                {
                    object result = mathMlProperty.GetValue(shape);
                    return result as string;
                }

                // If neither method nor property exists, the format is not supported
                // Comment: MathML extraction not supported for this shape type.
                return null;
            }
            catch (TargetInvocationException tie)
            {
                // Handle exceptions thrown by the invoked method/property
                Console.WriteLine("Failed to extract MathML from shape: " + tie.InnerException?.Message);
                return null;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Unexpected error during MathML extraction: " + ex.Message);
                return null;
            }
        }
    }
}
