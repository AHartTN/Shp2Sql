namespace Shp2Sql.Sandbox
{
	#region Imports

	using System;
	using System.CodeDom.Compiler;
	using System.ComponentModel;
	using System.Diagnostics;
	using System.Xml.Serialization;

	#endregion
	/// <remarks />
	[GeneratedCode("xsd", "4.6.1055.0")]
	[Serializable]
	[DebuggerStepThrough]
	[DesignerCategory("code")]
	[XmlType(AnonymousType = true, Namespace = "http://www.isotc211.org/2005/gfc")]
	[XmlRoot(Namespace = "http://www.isotc211.org/2005/gfc", IsNullable = false)]
	public class FC_FeatureCatalogue : object, INotifyPropertyChanged
	{
		private object[] itemsField;

		/// <remarks />
		[XmlElement("definition", typeof (definition), Order = 0)]
		[XmlElement("definitionReference", typeof (definitionReference), Order = 0)]
		[XmlElement("featureType", typeof (FC_FeatureCatalogueFeatureType), Order = 0)]
		[XmlElement("producer", typeof (FC_FeatureCatalogueProducer), Order = 0)]
		[XmlElement("characterSet", typeof (characterSet), Namespace = "http://www.isotc211.org/2005/gmx", Order = 0)]
		[XmlElement("language", typeof (language), Namespace = "http://www.isotc211.org/2005/gmx", Order = 0)]
		[XmlElement("name", typeof (name), Namespace = "http://www.isotc211.org/2005/gmx", Order = 0)]
		[XmlElement("scope", typeof (scope), Namespace = "http://www.isotc211.org/2005/gmx", Order = 0)]
		[XmlElement("versionDate", typeof (versionDate), Namespace = "http://www.isotc211.org/2005/gmx", Order = 0)]
		[XmlElement("versionNumber", typeof (versionNumber), Namespace = "http://www.isotc211.org/2005/gmx", Order = 0)]
		public object[] Items
		{
			get
			{
				return itemsField;
			}
			set
			{
				itemsField = value;
				RaisePropertyChanged("Items");
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