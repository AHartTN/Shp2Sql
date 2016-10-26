namespace Shp2Sql.Sandbox
{
	#region Imports

	using System;
	using System.CodeDom.Compiler;
	using System.ComponentModel;
	using System.Diagnostics;
	using System.Xml.Schema;
	using System.Xml.Serialization;

	#endregion
	/// <remarks />
	[GeneratedCode("xsd", "4.6.1055.0")]
	[Serializable]
	[DebuggerStepThrough]
	[DesignerCategory("code")]
	[XmlType(AnonymousType = true, Namespace = "http://www.isotc211.org/2005/gfc")]
	[XmlRoot(Namespace = "http://www.isotc211.org/2005/gfc", IsNullable = false)]
	public class definitionReference : object, INotifyPropertyChanged
	{
		private definitionReferenceFC_DefinitionReferenceDefinitionSourceFC_DefinitionSourceSource[][][][]
			fC_DefinitionReferenceField;

		private string hrefField;

		private string titleField;

		/// <remarks />
		[XmlArray(Order = 0)]
		[XmlArrayItem("definitionSource",
			typeof (definitionReferenceFC_DefinitionReferenceDefinitionSourceFC_DefinitionSourceSource[][]), IsNullable = false)]
		[XmlArrayItem("FC_DefinitionSource",
			typeof (definitionReferenceFC_DefinitionReferenceDefinitionSourceFC_DefinitionSourceSource[]), IsNullable = false,
			NestingLevel = 1)]
		[XmlArrayItem("source", typeof (definitionReferenceFC_DefinitionReferenceDefinitionSourceFC_DefinitionSourceSource),
			IsNullable = false, NestingLevel = 2)]
		public definitionReferenceFC_DefinitionReferenceDefinitionSourceFC_DefinitionSourceSource[][][][]
			FC_DefinitionReference
		{
			get
			{
				return fC_DefinitionReferenceField;
			}
			set
			{
				fC_DefinitionReferenceField = value;
				RaisePropertyChanged("FC_DefinitionReference");
			}
		}

		/// <remarks />
		[XmlAttribute(Form = XmlSchemaForm.Qualified, Namespace = "http://www.w3.org/1999/xlink")]
		public string title
		{
			get
			{
				return titleField;
			}
			set
			{
				titleField = value;
				RaisePropertyChanged("title");
			}
		}

		/// <remarks />
		[XmlAttribute(Form = XmlSchemaForm.Qualified, Namespace = "http://www.w3.org/1999/xlink")]
		public string href
		{
			get
			{
				return hrefField;
			}
			set
			{
				hrefField = value;
				RaisePropertyChanged("href");
			}
		}

		public event PropertyChangedEventHandler PropertyChanged;

		protected void RaisePropertyChanged(string propertyName)
		{
			PropertyChangedEventHandler propertyChanged = PropertyChanged;
			if (propertyChanged != null)
			{
				propertyChanged(this, new PropertyChangedEventArgs(propertyName));
			}
		}
	}
}