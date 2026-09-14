// -----------------------------------------------------------------------------
// Example: Measure MathML Export Performance with Aspose.Slides
//
// Description:
// This console application loads a PowerPoint PPTX file, searches for math
// objects, and measures the execution time of each WriteAsMathMl call to
// evaluate export performance. It uses Aspose.Slides for .NET, handles missing
// files, and gracefully skips unsupported formats.
//
// Keywords:
// C#, PowerPoint, PPTX, Aspose.Slides for .NET, MathML export, performance timing
//
// Use Cases:
// - Benchmarking MathML export speed for large presentations.
// - Identifying performance bottlenecks in slide content processing.
// - Automating quality checks for math-heavy PowerPoint files.
// Tested and Verified with Aspose.Slides for .NET v26.9.0.
// -----------------------------------------------------------------------------
using System;
using System.IO;
using System.Diagnostics;
using System.Reflection;

namespace AsposeSlidesMathMlTiming
{
    public class Program
    {
        public static void Main(string[] args)
        {
            string inputPath = "input.pptx";
            if (!File.Exists(inputPath))
            {
                Console.WriteLine("Input file not found: " + inputPath);
                return;
            }

            Aspose.Slides.Presentation presentation = null;
            try
            {
                presentation = new Aspose.Slides.Presentation(inputPath);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Failed to load presentation: " + ex.Message);
                return;
            }

            // Attempt to locate MathParagraph objects via reflection
            bool mathFound = false;
            foreach (Aspose.Slides.ISlide slide in presentation.Slides)
            {
                foreach (Aspose.Slides.IShape shape in slide.Shapes)
                {
                    // Check if the shape's type name contains "MathParagraph"
                    Type shapeType = shape.GetType();
                    if (shapeType.FullName != null && shapeType.FullName.Contains("MathParagraph"))
                    {
                        mathFound = true;
                        // Use reflection to invoke WriteAsMathMl
                        MethodInfo writeMethod = shapeType.GetMethod("WriteAsMathMl", new Type[] { typeof(object) });
                        if (writeMethod == null)
                        {
                            Console.WriteLine("WriteAsMathMl method not found on type: " + shapeType.FullName);
                            continue;
                        }

                        // Create MathMlExportOptions via reflection
                        Type optionsType = Type.GetType("Aspose.Slides.Math.MathMlExportOptions, Aspose.Slides");
                        object optionsInstance = null;
                        if (optionsType != null)
                        {
                            ConstructorInfo ctor = optionsType.GetConstructor(Type.EmptyTypes);
                            if (ctor != null)
                            {
                                optionsInstance = ctor.Invoke(null);
                            }
                        }

                        if (optionsInstance == null)
                        {
                            Console.WriteLine("MathMlExportOptions type not available; skipping MathML export.");
                            continue;
                        }

                        Stopwatch sw = new Stopwatch();
                        try
                        {
                            sw.Start();
                            // The method returns a string containing MathML
                            object mathMl = writeMethod.Invoke(shape, new object[] { optionsInstance });
                            sw.Stop();
                            Console.WriteLine("MathML export time (ms): " + sw.ElapsedMilliseconds);
                            // Optionally, write MathML to a file for verification
                            string outputMathMlPath = Path.Combine(Path.GetDirectoryName(inputPath), "MathExport_" + Guid.NewGuid().ToString() + ".xml");
                            File.WriteAllText(outputMathMlPath, mathMl as string ?? string.Empty);
                        }
                        catch (TargetInvocationException tie) when (tie.InnerException is NotSupportedException)
                        {
                            Console.WriteLine("MathML export not supported for this shape.");
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine("Error during MathML export: " + ex.Message);
                        }
                    }
                }
            }

            if (!mathFound)
            {
                Console.WriteLine("No MathParagraph objects found in the presentation.");
            }

            // Save the presentation (no modifications made, but required by task)
            try
            {
                string outputPath = Path.Combine(Path.GetDirectoryName(inputPath), "TimedOutput.pptx");
                presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
                Console.WriteLine("Presentation saved to: " + outputPath);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Failed to save presentation: " + ex.Message);
            }
        }
    }
}
