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
	public class FC_FeatureCatalogueFeatureType : object, INotifyPropertyChanged
	{
		private FC_FeatureCatalogueFeatureTypeFC_FeatureType[] fC_FeatureTypeField;

		/// <remarks />
		[XmlElement("FC_FeatureType", Order = 0)]
		public FC_FeatureCatalogueFeatureTypeFC_FeatureType[] FC_FeatureType
		{
			get
			{
				return fC_FeatureTypeField;
			}
			set
			{
				fC_FeatureTypeField = value;
				RaisePropertyChanged("FC_FeatureType");
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