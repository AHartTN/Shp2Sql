using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Xml;
using System.Xml.Schema;
using Newtonsoft.Json;

namespace Shp2Sql.Models.Binding
{
	#region Imports

	

	#endregion
	public class MetadataFile : ImportFile
	{
		public MetadataFile()
		{
		}

		public MetadataFile(FileInfo file)
			: base(file)
		{
			// TODO: Get generated class to use for processing the file to have an object to return
			//if (XMLHelper.ProcessFile(file))
			ImportFromFile(file);
		}

		public void ImportFromFile(FileInfo file)
		{
			try
			{
				//XmlSerializer serializer = new XmlSerializer(typeof(metadata));
				//metadata data = (metadata)serializer.Deserialize(file.OpenRead());

				//foreach (object item in data.Items)
				//{
				//	Type itemType = item.GetType();
				//	Console.WriteLine($"{itemType} | {item}");
				//}


				XmlDocument document = new XmlDocument();
				document.Load(file.FullName);

				string jsonTest = JsonConvert.SerializeXmlNode(document);
				object jsonObject = JsonConvert.DeserializeObject(jsonTest);

				//Console.WriteLine(jsonTest);

				XmlReader reader = XmlReader.Create(file.FullName);

				while (reader.Read())
				{
					string name = reader.Name;
					string baseUri = reader.BaseURI;
					string localName = reader.LocalName;
					string namespaceUri = reader.NamespaceURI;
					XmlNodeType nodeType = reader.NodeType;
					string prefix = reader.Prefix;
					IXmlSchemaInfo schemaInfo = reader.SchemaInfo;
					string value = reader.Value;
					bool hasAttributes = reader.HasAttributes;
					int attributeCount = reader.AttributeCount;
					bool canReadBinaryContent = reader.CanReadBinaryContent;
					bool canReadValueChunk = reader.CanReadValueChunk;
					bool canResolveEntity = reader.CanResolveEntity;
					int depth = reader.Depth;
					bool isEoF = reader.EOF;
					bool hasValue = reader.HasValue;
					bool isDefault = reader.IsDefault;
					bool isEmptyElement = reader.IsEmptyElement;
					XmlNameTable nameTable = reader.NameTable;
					char quoteChar = reader.QuoteChar;
					ReadState readState = reader.ReadState;
					XmlReaderSettings settings = reader.Settings;
					Type valueType = reader.ValueType;
					string xmlLang = reader.XmlLang;
					XmlSpace xmlSpace = reader.XmlSpace;

					switch (reader.NodeType)
					{
						case XmlNodeType.XmlDeclaration:
						case XmlNodeType.Whitespace:
						case XmlNodeType.EndElement:
						case XmlNodeType.Comment:
							continue;
						//case XmlNodeType.Element:
						//case XmlNodeType.Text:
						//case XmlNodeType.Attribute:
						//case XmlNodeType.CDATA:
						//case XmlNodeType.EntityReference:
						//case XmlNodeType.Entity:
						//case XmlNodeType.ProcessingInstruction:
						//case XmlNodeType.Document:
						//case XmlNodeType.DocumentType:
						//case XmlNodeType.DocumentFragment:
						//case XmlNodeType.Notation:
						//case XmlNodeType.SignificantWhitespace:
						//case XmlNodeType.EndEntity:
						//	break;
						case XmlNodeType.None:
							Console.WriteLine("Why does this node have a type of 'None'?");
							break;
						default:
							Console.WriteLine($"\r{nodeType} | {name} | {value}");
							break;
					}

					if (reader.HasAttributes)
					{
						Dictionary<string, string> results = new Dictionary<string, string>();

						while (reader.MoveToNextAttribute())
						{
							results.Add(reader.Name, reader.Value);
						}

						foreach (KeyValuePair<string, string> result in results)
						{
							Console.WriteLine($"{result.Key} | {result.Value}");
						}
					}
				}

				Debugger.Break();
			}
			catch (Exception e)
			{
				LH.Error($"\r\n{e.Message}\r\n{e}");
				throw;
			}
		}
	}
}