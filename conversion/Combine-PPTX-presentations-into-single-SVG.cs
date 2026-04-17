using System;
using System.IO;
using Aspose.Slides.Export;

namespace CombineAndConvertToSvg
{
    class Program
    {
        static void Main(string[] args)
        {
            // Define input and output directories
            string inputDir = Path.Combine(Environment.CurrentDirectory, "Input");
            string outputDir = Path.Combine(Environment.CurrentDirectory, "Output");

            // Ensure directories exist
            if (!Directory.Exists(inputDir))
                Directory.CreateDirectory(inputDir);
            if (!Directory.Exists(outputDir))
                Directory.CreateDirectory(outputDir);

            // List of source PPTX files to combine
            string[] sourceFiles = new string[]
            {
                Path.Combine(inputDir, "presentation1.pptx"),
                Path.Combine(inputDir, "presentation2.pptx")
                // Add more file paths as needed
            };

            // Path for the combined presentation
            string combinedPath = Path.Combine(outputDir, "combined.pptx");

            // Create a new empty presentation to hold combined slides
            Aspose.Slides.Presentation combinedPresentation = new Aspose.Slides.Presentation();

            // Loop through each source file, load it, and clone its slides into the combined presentation
            foreach (string sourceFile in sourceFiles)
            {
                // Check if the source file exists
                if (!File.Exists(sourceFile))
                {
                    // Skip missing files (could log or notify here)
                    continue;
                }

                // Load the source presentation
                Aspose.Slides.Presentation sourcePresentation = null;
                try
                {
                    sourcePresentation = new Aspose.Slides.Presentation(sourceFile);
                }
                catch (NotSupportedException)
                {
                    // Format not supported; skip this file
                    continue;
                }

                // Clone each slide from the source into the combined presentation
                for (int slideIndex = 0; slideIndex < sourcePresentation.Slides.Count; slideIndex++)
                {
                    combinedPresentation.Slides.AddClone(sourcePresentation.Slides[slideIndex]);
                }

                // Dispose the source presentation
                sourcePresentation.Dispose();
            }

            // Save the combined presentation
            combinedPresentation.Save(combinedPath, Aspose.Slides.Export.SaveFormat.Pptx);
            combinedPresentation.Dispose();

            // Convert each slide of the combined presentation to SVG
            string svgFormatString = Path.Combine(outputDir, "slide_{0}.svg");
            Aspose.Slides.Presentation svgPresentation = null;
            try
            {
                svgPresentation = new Aspose.Slides.Presentation(combinedPath);
            }
            catch (NotSupportedException)
            {
                // Format not supported; exit conversion
                return;
            }

            for (int index = 0; index < svgPresentation.Slides.Count; index++)
            {
                Aspose.Slides.ISlide slide = svgPresentation.Slides[index];
                string svgFilePath = string.Format(svgFormatString, index);
                using (FileStream stream = new FileStream(svgFilePath, FileMode.Create, FileAccess.Write))
                {
                    slide.WriteAsSvg(stream);
                }
            }

            // Save the presentation before exit (already saved earlier) and dispose
            svgPresentation.Dispose();
        }
    }
}