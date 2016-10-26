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
	[XmlType(AnonymousType = true, Namespace = "http://www.isotc211.org/2005/gmd")]
	[XmlRoot(Namespace = "http://www.isotc211.org/2005/gmd", IsNullable = false)]
	public class CI_Citation : object, INotifyPropertyChanged
	{
		private CI_CitationCitedResponsiblePartyCI_ResponsibleParty[][] citedResponsiblePartyField;

		private CI_CitationDate[] dateField;

		private CI_CitationTitle[] titleField;

		/// <remarks />
		[XmlElement("title", Order = 0)]
		public CI_CitationTitle[] title
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
		[XmlElement("date", Order = 1)]
		public CI_CitationDate[] date
		{
			get
			{
				return dateField;
			}
			set
			{
				dateField = value;
				RaisePropertyChanged("date");
			}
		}

		/// <remarks />
		[XmlArray(Order = 2)]
		[XmlArrayItem("CI_ResponsibleParty", typeof (CI_CitationCitedResponsiblePartyCI_ResponsibleParty), IsNullable = false)
		]
		public CI_CitationCitedResponsiblePartyCI_ResponsibleParty[][] citedResponsibleParty
		{
			get
			{
				return citedResponsiblePartyField;
			}
			set
			{
				citedResponsiblePartyField = value;
				RaisePropertyChanged("citedResponsibleParty");
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