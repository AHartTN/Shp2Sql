namespace Shp2Sql
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.IO;
    using System.Linq;
    using Microsoft.SqlServer.Types;
    using Shp2Sql.Classes.Helpers;
    using Shp2Sql.Enumerators;
    using Shp2Sql.Models.Binding;
    using Shp2Sql.Models.Entity;

    public class ESRIHelper
    {
        #region Extensions
        public const string ShapeFormatExtension = ".shp";
        public const string ShapeIndexFormatExtension = ".shx";
        public const string AttributeFormatExtension = ".dbf";
        public const string ProjectionFormatExtension = ".prj";

        public const string GeocodingIndexExtension = ".ixs";
        public const string ODBGeocodingIndexExtension = ".mxs";
        public const string DBFAttributeIndexExtension = ".atx";
        public const string GeospatialMetadataExtension = ".shp.xml";
        public const string CodePageExtension = ".cpg";

        public static readonly string[] SpatialIndexExtension = {
                                                                    ".sbn",
                                                                    ".sbx"
                                                                };

        public static readonly string[] SpatialIndexReadOnlyExtension = {
                                                                            ".fbn",
                                                                            ".fbx"
                                                                        };

        public static readonly string[] AttributeIndexExtension = {
                                                                      ".ain",
                                                                      ".aih"
                                                                  };
        #endregion Extensions

        private static List<string> files;

        public static string GetProgressString(int charIndex, long fileLength, string name)
        {
            decimal percentage = 100 * (charIndex / fileLength);
            return String.Format("{0} of {1} ({2}%): {3}                \r", charIndex, fileLength, percentage, name);
        }

        public static void ProcessDirectory(string directoryPath)
        {
            DirectoryInfo directoryInfo = new DirectoryInfo(directoryPath);

            if (!directoryInfo.Exists)
                throw new Exception("The specified directory does not exist!");

            // Index Files
            //files = directoryInfo.GetFiles(String.Format("*{0}", ShapeIndexFormatExtension), SearchOption.AllDirectories).Select(s => s.FullName).ToList();
            //Console.WriteLine("Parsing {0} index files!", files.Count);
            //foreach (string file in files)
            //    ImportIndexFile(file);

            // Shape Files
            files = directoryInfo.GetFiles(string.Format("*{0}", ShapeFormatExtension), SearchOption.AllDirectories).Select(s => s.FullName).ToList();
            Console.WriteLine("Parsing {0} shape files!", files.Count);
            foreach (string file in files)
                ImportShapeFile(file);

            //List<FileInfo> projectionFiles = directoryInfo.GetFiles(string.Format("*{0}", ProjectionFormatExtension), SearchOption.AllDirectories).ToList();
            //List<FileInfo> metadataFiles = directoryInfo.GetFiles(string.Format("*{0}", GeospatialMetadataExtension), SearchOption.AllDirectories).ToList();
            //List<FileInfo> attributeFiles = directoryInfo.GetFiles(string.Format("*{0}", AttributeFormatExtension), SearchOption.AllDirectories).ToList();
        }

        public static void ImportIndexFile(string filePath)
        {
            Console.WriteLine("Parsing {0}", filePath);
            FileInfo fileInfo = new FileInfo(filePath);

            if (!fileInfo.Exists ||
                fileInfo.Extension != ShapeIndexFormatExtension)
                throw new ArgumentException("The file you specified either does not exist or is not the appropriate shapefile extenision (*.shx).");

            IndexFile result = new IndexFile
                               {
                                   CreationTime = fileInfo.CreationTime,
                                   CreationTimeUtc = fileInfo.CreationTimeUtc,
                                   DirectoryName = fileInfo.DirectoryName,
                                   Extension = fileInfo.Extension,
                                   FullName = fileInfo.FullName,
                                   IsReadOnly = fileInfo.IsReadOnly,
                                   LastAccessTime = fileInfo.LastAccessTime,
                                   LastAccessTimeUtc = fileInfo.LastAccessTimeUtc,
                                   LastWriteTime = fileInfo.LastWriteTime,
                                   LastWriteTimeUtc = fileInfo.LastWriteTimeUtc,
                                   FileLength = fileInfo.Length,
                                   Name = fileInfo.Name,
                               };

            using (FileStream fs = File.Open(fileInfo.FullName, FileMode.Open, FileAccess.Read, FileShare.None))
            using (BinaryReader br = new BinaryReader(fs))
            {
                result.FileCode = NumericsHelper.ReverseInt(br.ReadInt32());

                for (int i = 0; i < 5; i++)
                    br.ReadInt32(); // Skip 5 empty Integer (4-byte) slots

                result.ContentLength = NumericsHelper.ReverseInt(br.ReadInt32()); // Big Endian, Reverse for actual value
                result.FileVersion = br.ReadInt32();
                result.ShapeTypeId = br.ReadInt32();
                result.XMin = br.ReadDouble();
                result.YMin = br.ReadDouble();
                result.XMax = br.ReadDouble();
                result.YMax = br.ReadDouble();
                result.ZMin = br.ReadDouble();
                result.ZMax = br.ReadDouble();
                result.MMin = br.ReadDouble();
                result.MMax = br.ReadDouble();

                int counter = 0;
                while (br.PeekChar() > -1)
                {
                    counter++;
                    result.ShapeIndexes.Add(new ShapeIndex
                    {
                        //IndexFileId = result.Id,
                        RecordNumber = counter,
                        Offset = NumericsHelper.ReverseInt(br.ReadInt32()),
                        ContentLength = NumericsHelper.ReverseInt(br.ReadInt32())
                    });
                }
            }

            using (ShapefileEntities db = new ShapefileEntities())
            {
                db.Entry(result).State = EntityState.Added;
                result = db.IndexFiles.Add(result);
                Console.WriteLine("--==|| {0} record(s) from Index file (ID: {1}) loaded ||==--", db.SaveChanges(), result.Id);
            }
        }

        private static void ImportShapeFile(string filePath)
        {
            Console.WriteLine("Parsing {0}", filePath);
            FileInfo fileInfo = new FileInfo(filePath);

            if (!fileInfo.Exists ||
                fileInfo.Extension != ShapeFormatExtension)
                throw new ArgumentException("The file you specified either does not exist or is not the appropriate shapefile extenision (*.shp).");

            // TODO: Delete all records that pertain to this file

            using (FileStream fs = File.Open(fileInfo.FullName, FileMode.Open, FileAccess.Read, FileShare.None))
            using (BinaryReader br = new BinaryReader(fs))
            {
                ShapeFile result = new ShapeFile
                {
                    CreationTime = fileInfo.CreationTime,
                    CreationTimeUtc = fileInfo.CreationTimeUtc,
                    DirectoryName = fileInfo.DirectoryName,
                    Extension = fileInfo.Extension,
                    FullName = fileInfo.FullName,
                    IsReadOnly = fileInfo.IsReadOnly,
                    LastAccessTime = fileInfo.LastAccessTime,
                    LastAccessTimeUtc = fileInfo.LastAccessTimeUtc,
                    LastWriteTime = fileInfo.LastWriteTime,
                    LastWriteTimeUtc = fileInfo.LastWriteTimeUtc,
                    FileLength = fileInfo.Length,
                    Name = fileInfo.Name,
                    FileCode = NumericsHelper.ReverseInt(br.ReadInt32())
                };

                for (int i = 0; i < 5; i++)
                    br.ReadInt32(); // Skip 5 empty Integer (4-byte) slots

                result.ContentLength = NumericsHelper.ReverseInt(br.ReadInt32()); // Big Endian, Reverse for actual value
                result.FileVersion = br.ReadInt32();
                result.ShapeTypeId = br.ReadInt32();
                result.XMin = br.ReadDouble();
                result.YMin = br.ReadDouble();
                result.XMax = br.ReadDouble();
                result.YMax = br.ReadDouble();
                result.ZMin = br.ReadDouble();
                result.ZMax = br.ReadDouble();
                result.MMin = br.ReadDouble();
                result.MMax = br.ReadDouble();

                using (ShapefileEntities db = new ShapefileEntities())
                {
                    db.Entry(result).State = EntityState.Added;
                    result = db.ShapeFiles.Add(result);
                    Console.WriteLine("Inserted {0} Shape File Records for Shape File ID: {1})!", db.SaveChanges(), result.Id);
                }

                while (br.PeekChar() > -1)
                    ImportShape(result.Id, (ShapeTypeEnum)result.ShapeTypeId, br);
            }
        }

        private static void ImportShape(long shapeFileId, ShapeTypeEnum shapeType, BinaryReader br)
        {
            Shape newShape = new Shape
            {
                ShapeFileId = shapeFileId,
                RecordNumber = NumericsHelper.ReverseInt(br.ReadInt32()), // Big, Reverse for actual value
                ContentLength = NumericsHelper.ReverseInt(br.ReadInt32()), // Big, Reverse for actual value
                ShapeTypeId = br.ReadInt32()
            };

            if (shapeType == ShapeTypeEnum.Null || (ShapeTypeEnum)newShape.ShapeTypeId == ShapeTypeEnum.Null)
                using (ShapefileEntities db = new ShapefileEntities())
                {
                    db.Configuration.AutoDetectChangesEnabled = false;
                    db.Configuration.ValidateOnSaveEnabled = false;
                    db.Entry(newShape).State = EntityState.Added;
                    newShape = db.Shapes.Add(newShape);
                    Console.WriteLine("Inserted {0} records for the {1} shape! (ID: {2})", db.SaveChanges(), (ShapeTypeEnum)newShape.ShapeTypeId, newShape.Id);
                    return;
                }

            if (shapeType != (ShapeTypeEnum)newShape.ShapeTypeId) // Shape Type doesn't match type specified in file header. According to specs, this is invalid. Throw exception
                throw new Exception(string.Format("Unable to process shape! File shape of {0} does not match record shape of {1} which violates ESRI specifications for shape files!", shapeType, (ShapeTypeEnum)newShape.ShapeTypeId));

            ShapeClass shapeClass = ShapeClass.Coordinate;
            bool hasMultiplePoints = true;
            bool hasParts = true;
            bool hasPartTypes = false;

            switch (shapeType)
            {
                case ShapeTypeEnum.MultiPatch:
                    shapeClass = ShapeClass.Depth;
                    hasPartTypes = true;
                    break;
                case ShapeTypeEnum.MultiPoint:
                    hasParts = false;
                    break;
                case ShapeTypeEnum.MultiPointM:
                    shapeClass = ShapeClass.Measurement;
                    hasParts = false;
                    break;
                case ShapeTypeEnum.MultiPointZ:
                    shapeClass = ShapeClass.Depth;
                    hasParts = false;
                    break;
                case ShapeTypeEnum.Null:
                    throw new Exception("The application should have never gotten to this point.\r\nSomething is wrong with the code!\r\nLYNCH THE DEVELOPER!");
                case ShapeTypeEnum.Point:
                    hasMultiplePoints = false;
                    hasParts = false;
                    break;
                case ShapeTypeEnum.PointM:
                    shapeClass = ShapeClass.Measurement;
                    hasMultiplePoints = false;
                    hasParts = false;
                    break;
                case ShapeTypeEnum.PointZ:
                    shapeClass = ShapeClass.Depth;
                    hasMultiplePoints = false;
                    hasParts = false;
                    break;
                case ShapeTypeEnum.Polygon:
                    break;
                case ShapeTypeEnum.PolygonM:
                    shapeClass = ShapeClass.Measurement;
                    break;
                case ShapeTypeEnum.PolygonZ:
                    shapeClass = ShapeClass.Depth;
                    break;
                case ShapeTypeEnum.PolylineM:
                    shapeClass = ShapeClass.Measurement;
                    break;
                case ShapeTypeEnum.PolylineZ:
                    shapeClass = ShapeClass.Depth;
                    break;
                default:
                    throw new Exception(string.Format("Unable to process shape! Record Shape of {0} is unknown!", (ShapeTypeEnum)newShape.ShapeTypeId));
            }

            if (hasMultiplePoints)
            {
                newShape.XMin = br.ReadDouble();
                newShape.YMin = br.ReadDouble();
                newShape.XMax = br.ReadDouble();
                newShape.YMax = br.ReadDouble();
            }

            newShape.NumberOfParts = hasParts ? br.ReadInt32() : 1;
            newShape.NumberOfPoints = hasMultiplePoints ? br.ReadInt32() : 1;

            for (int i = 0; i < newShape.NumberOfParts; i++) // Grab the parts
            {
                newShape.Parts.Add(new Part
                {
                    SortIndex = i,
                    PartTypeId = -1,
                    StartIndex = hasParts ? br.ReadInt32() : 0 // Get the start index
                });

                if (i > 0) // If this isn't the first element
                    newShape.Parts[i - 1].EndIndex = newShape.Parts[i].StartIndex - 1; // Set the last element to this element's start index minus one

                if (i + 1 == newShape.NumberOfParts) // If this is the last element
                    newShape.Parts[i].EndIndex = newShape.NumberOfPoints - 1; // Set the ending index to the number of points minus one (to account for 0 based index)
            }

            for (int i = 0; i < newShape.NumberOfParts; i++) // Set the number of points. This is done after initial grab to account for first/last elements
            {
                if (hasParts && hasPartTypes)
                    newShape.Parts[i].PartTypeId = br.ReadInt32();

                newShape.Parts[i].NumberOfPoints = (newShape.Parts[i].EndIndex - newShape.Parts[i].StartIndex) + 1;
            }

            for (int i = 0; i < newShape.NumberOfParts; i++) // For each part
                for (int j = 0; j < newShape.Parts[i].NumberOfPoints; j++) // For each point in each part
                {
                    newShape.Parts[i].Points.Add(new Point
                    {
                        SortIndex = j,
                        X = br.ReadDouble(),
                        Y = br.ReadDouble(),
                    }); // Grab the point
                }

            if (shapeClass == ShapeClass.Depth)
            {
                if (hasMultiplePoints)
                {
                    newShape.ZMin = br.ReadDouble();
                    newShape.ZMax = br.ReadDouble();
                }

                for (int i = 0; i < newShape.NumberOfParts; i++)
                    for (int j = 0; j < newShape.Parts[i].NumberOfPoints; j++)
                        newShape.Parts[i].Points[j].Z = br.ReadDouble();
            }

            if (shapeClass == ShapeClass.Depth ||
                shapeClass == ShapeClass.Measurement)
            {
                if (hasMultiplePoints)
                {
                    newShape.MMin = br.ReadDouble();
                    newShape.MMax = br.ReadDouble();
                }

                for (int i = 0; i < newShape.NumberOfParts; i++)
                    for (int j = 0; j < newShape.Parts[i].NumberOfPoints; j++)
                        newShape.Parts[i].Points[j].M = br.ReadDouble();
            }
            
            using (ShapefileEntities db = new ShapefileEntities())
            {
                db.Configuration.AutoDetectChangesEnabled = false;
                db.Configuration.ValidateOnSaveEnabled = false;
                db.Entry(newShape).State = EntityState.Added;
                newShape = db.Shapes.Add(newShape);
                Console.WriteLine("Inserted {0} records for the {1} shape! (ID: {2})", db.SaveChanges(), (ShapeTypeEnum)newShape.ShapeTypeId, newShape.Id);
            }
        }
    }
}