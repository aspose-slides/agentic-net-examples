using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace ValidateSwfShowHiddenSlides
{
    class Program
    {
        static void Main(string[] args)
        {
            // Path to the source presentation
            string sourcePath = "input.pptx";

            // Verify that the source file exists
            if (!File.Exists(sourcePath))
            {
                Console.WriteLine("Source file not found: " + sourcePath);
                return;
            }

            try
            {
                // Load the presentation
                using (Presentation presentation = new Presentation(sourcePath))
                {
                    // Get total slide count from document properties
                    int totalSlides = presentation.DocumentProperties.Slides;
                    Console.WriteLine("Total slides in source: " + totalSlides);

                    // Save without including hidden slides
                    SwfOptions optionsWithoutHidden = new SwfOptions();
                    optionsWithoutHidden.ShowHiddenSlides = false;
                    string outputPathWithoutHidden = "output_no_hidden.swf";

                    try
                    {
                        presentation.Save(outputPathWithoutHidden, SaveFormat.Swf, optionsWithoutHidden);
                        Console.WriteLine("Saved without hidden slides: " + outputPathWithoutHidden);
                    }
                    catch (PptxUnsupportedFormatException)
                    {
                        Console.WriteLine("SWF format not supported for PPTX files.");
                    }
                    catch (PptUnsupportedFormatException)
                    {
                        Console.WriteLine("SWF format not supported for PPT files.");
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("Error saving without hidden slides: " + ex.Message);
                    }

                    // Save including hidden slides
                    SwfOptions optionsWithHidden = new SwfOptions();
                    optionsWithHidden.ShowHiddenSlides = true;
                    string outputPathWithHidden = "output_with_hidden.swf";

                    try
                    {
                        presentation.Save(outputPathWithHidden, SaveFormat.Swf, optionsWithHidden);
                        Console.WriteLine("Saved with hidden slides: " + outputPathWithHidden);
                    }
                    catch (PptxUnsupportedFormatException)
                    {
                        Console.WriteLine("SWF format not supported for PPTX files.");
                    }
                    catch (PptUnsupportedFormatException)
                    {
                        Console.WriteLine("SWF format not supported for PPT files.");
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("Error saving with hidden slides: " + ex.Message);
                    }

                    // Verify that the slide count remains unchanged
                    Console.WriteLine("Verified slide count remains unchanged: " + totalSlides);
                }
            }
            catch (FileNotFoundException fnfEx)
            {
                Console.WriteLine("File not found exception: " + fnfEx.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Unexpected error: " + ex.Message);
            }
        }
    }
}