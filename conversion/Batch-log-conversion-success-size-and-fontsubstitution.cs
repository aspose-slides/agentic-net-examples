using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace BatchFontConversion
{
    class Program
    {
        static void Main(string[] args)
        {
            string logFilePath = "conversion_log.txt";
            using (StreamWriter logWriter = new StreamWriter(logFilePath, true))
            {
                foreach (string inputPath in args)
                {
                    if (!File.Exists(inputPath))
                    {
                        logWriter.WriteLine($"{DateTime.Now}: Input file not found - '{inputPath}'.");
                        continue;
                    }

                    string outputDirectory = Path.GetDirectoryName(inputPath);
                    string outputFileName = Path.GetFileNameWithoutExtension(inputPath) + "_out.pptx";
                    string outputPath = Path.Combine(outputDirectory, outputFileName);

                    try
                    {
                        Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation(inputPath);

                        presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);

                        FileInfo outputInfo = new FileInfo(outputPath);
                        long outputSize = outputInfo.Length;

                        logWriter.WriteLine($"{DateTime.Now}: Successfully converted '{inputPath}' to '{outputPath}'. Output size: {outputSize} bytes.");

                        foreach (Aspose.Slides.FontSubstitutionInfo substitution in presentation.FontsManager.GetSubstitutions())
                        {
                            logWriter.WriteLine($"    Font substitution warning: {substitution.OriginalFontName} -> {substitution.SubstitutedFontName}");
                        }

                        presentation.Dispose();
                    }
                    catch (NotSupportedException)
                    {
                        // format not supported
                        logWriter.WriteLine($"{DateTime.Now}: Conversion failed for '{inputPath}'. Format not supported.");
                    }
                    catch (Exception ex)
                    {
                        logWriter.WriteLine($"{DateTime.Now}: Conversion failed for '{inputPath}'. Error: {ex.Message}");
                    }
                }
            }
        }
    }
}