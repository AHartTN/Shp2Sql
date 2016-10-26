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
	public class FC_FeatureCatalogueFeatureTypeFC_FeatureType : object, INotifyPropertyChanged
	{
		private FC_FeatureCatalogueFeatureTypeFC_FeatureTypeCarrierOfCharacteristicsFC_FeatureAttribute[][]
			carrierOfCharacteristicsField;

		private definition[] definitionField;

		private FC_FeatureCatalogueFeatureTypeFC_FeatureTypeFeatureCatalogue[] featureCatalogueField;

		private FC_FeatureCatalogueFeatureTypeFC_FeatureTypeIsAbstract[] isAbstractField;

		private FC_FeatureCatalogueFeatureTypeFC_FeatureTypeTypeName[] typeNameField;

		/// <remarks />
		[XmlElement("typeName", Order = 0)]
		public FC_FeatureCatalogueFeatureTypeFC_FeatureTypeTypeName[] typeName
		{
			get
			{
				return typeNameField;
			}
			set
			{
				typeNameField = value;
				RaisePropertyChanged("typeName");
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
		[XmlElement("isAbstract", Order = 2)]
		public FC_FeatureCatalogueFeatureTypeFC_FeatureTypeIsAbstract[] isAbstract
		{
			get
			{
				return isAbstractField;
			}
			set
			{
				isAbstractField = value;
				RaisePropertyChanged("isAbstract");
			}
		}

		/// <remarks />
		[XmlElement("featureCatalogue", Order = 3)]
		public FC_FeatureCatalogueFeatureTypeFC_FeatureTypeFeatureCatalogue[] featureCatalogue
		{
			get
			{
				return featureCatalogueField;
			}
			set
			{
				featureCatalogueField = value;
				RaisePropertyChanged("featureCatalogue");
			}
		}

		/// <remarks />
		[XmlArray(Order = 4)]
		[XmlArrayItem("FC_FeatureAttribute",
			typeof (FC_FeatureCatalogueFeatureTypeFC_FeatureTypeCarrierOfCharacteristicsFC_FeatureAttribute), IsNullable = false)
		]
		public FC_FeatureCatalogueFeatureTypeFC_FeatureTypeCarrierOfCharacteristicsFC_FeatureAttribute[][]
			carrierOfCharacteristics
		{
			get
			{
				return carrierOfCharacteristicsField;
			}
			set
			{
				carrierOfCharacteristicsField = value;
				RaisePropertyChanged("carrierOfCharacteristics");
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