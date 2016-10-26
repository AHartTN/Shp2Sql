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
	public class FC_FeatureCatalogueFeatureTypeFC_FeatureTypeCarrierOfCharacteristicsFC_FeatureAttribute : object,
		INotifyPropertyChanged
	{
		private FC_FeatureCatalogueFeatureTypeFC_FeatureTypeCarrierOfCharacteristicsFC_FeatureAttributeCardinality[]
			cardinalityField;

		private definition[] definitionField;

		private definitionReference[] definitionReferenceField;

		private
			FC_FeatureCatalogueFeatureTypeFC_FeatureTypeCarrierOfCharacteristicsFC_FeatureAttributeListedValueFC_ListedValue[][]
			listedValueField;

		private FC_FeatureCatalogueFeatureTypeFC_FeatureTypeCarrierOfCharacteristicsFC_FeatureAttributeMemberName[]
			memberNameField;

		/// <remarks />
		[XmlElement("memberName", Order = 0)]
		public FC_FeatureCatalogueFeatureTypeFC_FeatureTypeCarrierOfCharacteristicsFC_FeatureAttributeMemberName[] memberName
		{
			get
			{
				return memberNameField;
			}
			set
			{
				memberNameField = value;
				RaisePropertyChanged("memberName");
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
		[XmlElement("cardinality", Order = 2)]
		public FC_FeatureCatalogueFeatureTypeFC_FeatureTypeCarrierOfCharacteristicsFC_FeatureAttributeCardinality[]
			cardinality
		{
			get
			{
				return cardinalityField;
			}
			set
			{
				cardinalityField = value;
				RaisePropertyChanged("cardinality");
			}
		}

		/// <remarks />
		[XmlElement("definitionReference", Order = 3)]
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

		/// <remarks />
		[XmlArray(Order = 4)]
		[XmlArrayItem("FC_ListedValue",
			typeof (
				FC_FeatureCatalogueFeatureTypeFC_FeatureTypeCarrierOfCharacteristicsFC_FeatureAttributeListedValueFC_ListedValue),
			IsNullable = false)]
		public
			FC_FeatureCatalogueFeatureTypeFC_FeatureTypeCarrierOfCharacteristicsFC_FeatureAttributeListedValueFC_ListedValue[][]
			listedValue
		{
			get
			{
				return listedValueField;
			}
			set
			{
				listedValueField = value;
				RaisePropertyChanged("listedValue");
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