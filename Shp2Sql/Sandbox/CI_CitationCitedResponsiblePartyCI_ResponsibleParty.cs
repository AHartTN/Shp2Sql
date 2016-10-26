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
	public class CI_CitationCitedResponsiblePartyCI_ResponsibleParty : object, INotifyPropertyChanged
	{
		private CI_CitationCitedResponsiblePartyCI_ResponsiblePartyOrganisationName[] organisationNameField;

		private CI_CitationCitedResponsiblePartyCI_ResponsiblePartyRoleCI_RoleCode[][] roleField;

		/// <remarks />
		[XmlElement("organisationName", Order = 0)]
		public CI_CitationCitedResponsiblePartyCI_ResponsiblePartyOrganisationName[] organisationName
		{
			get
			{
				return organisationNameField;
			}
			set
			{
				organisationNameField = value;
				RaisePropertyChanged("organisationName");
			}
		}

		/// <remarks />
		[XmlArray(Order = 1)]
		[XmlArrayItem("CI_RoleCode", typeof (CI_CitationCitedResponsiblePartyCI_ResponsiblePartyRoleCI_RoleCode))]
		public CI_CitationCitedResponsiblePartyCI_ResponsiblePartyRoleCI_RoleCode[][] role
		{
			get
			{
				return roleField;
			}
			set
			{
				roleField = value;
				RaisePropertyChanged("role");
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