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
	public class
		FC_FeatureCatalogueFeatureTypeFC_FeatureTypeCarrierOfCharacteristicsFC_FeatureAttributeListedValueFC_ListedValue :
			object,
			INotifyPropertyChanged
	{
		private definition[] definitionField;

		private definitionReference[] definitionReferenceField;

		private
			FC_FeatureCatalogueFeatureTypeFC_FeatureTypeCarrierOfCharacteristicsFC_FeatureAttributeListedValueFC_ListedValueLabel
				[] labelField;

		/// <remarks />
		[XmlElement("label", Order = 0)]
		public
			FC_FeatureCatalogueFeatureTypeFC_FeatureTypeCarrierOfCharacteristicsFC_FeatureAttributeListedValueFC_ListedValueLabel
				[] label
		{
			get
			{
				return labelField;
			}
			set
			{
				labelField = value;
				RaisePropertyChanged("label");
			}
		}

		/// <remarks />
		[XmlElement("definition", Order = 1)]
		public definition[] definition
		{
			get
			{
				return definitionField;
			}
			set
			{
				definitionField = value;
				RaisePropertyChanged("definition");
			}
		}

		/// <remarks />
		[XmlElement("definitionReference", Order = 2)]
		public definitionReference[] definitionReference
		{
			get
			{
				return definitionReferenceField;
			}
			set
			{
				definitionReferenceField = value;
				RaisePropertyChanged("definitionReference");
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