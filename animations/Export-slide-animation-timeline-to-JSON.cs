// -----------------------------------------------------------------------------

// Tested and verified with Aspose.Slides for .NET 26.8.0.
// Example: Export slide animation timeline to JSON using C#

//

// Description:

// Demonstrates how to read a PowerPoint presentation, extract basic

// information about each slide's animation timeline (main sequence count,

// interactive sequences count, and text animations count) and serialize this

// data to a JSON file using Aspose.Slides for .NET. The example also shows

// how to save the original presentation unchanged.

//

// Keywords:

// C#, PowerPoint, PPTX, Aspose.Slides for .NET, JSON, Export, Slide, Animation,

// Timeline, Presentation Processing, Office Automation

//

// Use Cases:

// - Generate a JSON report of animation details for each slide.

// - Integrate slide animation analysis into .NET automation tools.

// - Validate or audit animation settings before publishing.

// - Build utilities that process PPTX files and output structured data.

// -----------------------------------------------------------------------------

using System;

using System.IO;

using System.Collections.Generic;

using System.Text.Json;

using Aspose.Slides;

using Aspose.Slides.Animation;

using Aspose.Slides.Export;



namespace AnimationTimelineExport

{

    class Program

    {

        static void Main()

        {

            var inputPath = "input.pptx";

            var outputJsonPath = "animation_timeline.json";



            if (!File.Exists(inputPath))

            {

                Console.WriteLine($"Input file not found: {inputPath}");

                return;

            }



            try

            {

                using (var presentation = new Aspose.Slides.Presentation(inputPath))

                {

                    var slidesData = new List<object>();



                    foreach (var slide in presentation.Slides)

                    {

                        var timeline = slide.Timeline; // IAnimationTimeLine

                        var mainSequence = timeline.MainSequence; // ISequence

                        var interactiveSequences = timeline.InteractiveSequences; // ISequenceCollection

                        var textAnimations = timeline.TextAnimationCollection; // ITextAnimationCollection



                        var slideInfo = new

                        {

                            SlideIndex = presentation.Slides.IndexOf(slide),

                            MainSequenceCount = mainSequence.Count,

                            InteractiveSequencesCount = interactiveSequences.Count,

                            TextAnimationsCount = textAnimations.Count

                        };



                        slidesData.Add(slideInfo);

                    }



                    var jsonOptions = new JsonSerializerOptions { WriteIndented = true };

                    var json = JsonSerializer.Serialize(slidesData, jsonOptions);

                    File.WriteAllText(outputJsonPath, json);



                    // Save the presentation before exiting (no modifications made)

                    presentation.Save("output.pptx", Aspose.Slides.Export.SaveFormat.Pptx);

                }

            }

            catch (NotSupportedException)

            {

                // Format not supported

            }

            catch (Exception ex)

            {

                Console.WriteLine($"Error: {ex.Message}");

            }

        }

    }

}

