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
	public class definitionReferenceFC_DefinitionReferenceDefinitionSourceFC_DefinitionSourceSource : object,
		INotifyPropertyChanged
	{
		private CI_Citation cI_CitationField;

		/// <remarks />
		[XmlElement(Namespace = "http://www.isotc211.org/2005/gmd", Order = 0)]
		public CI_Citation CI_Citation
		{
			get
			{
				return cI_CitationField;
			}
			set
			{
				cI_CitationField = value;
				RaisePropertyChanged("CI_Citation");
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