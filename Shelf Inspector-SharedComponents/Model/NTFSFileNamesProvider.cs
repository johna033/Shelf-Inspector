using System;
using System.Collections.Generic;
using System.IO;
using ShelfInspectorDataModel.Infrastructure.Dto;

namespace ShelfInspectorDataModel.Model
{
    public class NtfsFileNamesProvider: ITrainingFilesProvider
    {
        public LinkedList<TrainingImage> GetFileNames(string folder)
        {
            string configFile = folder + @"\"+ GlobalConstants.TrainingSetConfigFileName;
            TextReader textReader = new StreamReader(configFile);
            LinkedList<TrainingImage> result = new LinkedList<TrainingImage>();
            while (textReader.Peek() >= 0)
            {
                string text = textReader.ReadLine();
                string[] parsed = text.Split(' ');
                TrainingImage metaImage = new TrainingImage
                {
                    BelongsToClass = Int32.Parse(parsed[1]),
                    File = folder + @"\" + parsed[0]
                };

                result.AddLast(metaImage);

            }
            textReader.Close();
            return result;
        }
    }
}
