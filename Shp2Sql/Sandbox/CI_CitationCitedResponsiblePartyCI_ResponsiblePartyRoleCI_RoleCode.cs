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
	public class CI_CitationCitedResponsiblePartyCI_ResponsiblePartyRoleCI_RoleCode : object, INotifyPropertyChanged
	{
		private string codeListField;

		private string codeListValueField;

		private string codeSpaceField;

		private string valueField;

		/// <remarks />
		[XmlAttribute]
		public string codeList
		{
			get
			{
				return codeListField;
			}
			set
			{
				codeListField = value;
				RaisePropertyChanged("codeList");
			}
		}

		/// <remarks />
		[XmlAttribute]
		public string codeListValue
		{
			get
			{
				return codeListValueField;
			}
			set
			{
				codeListValueField = value;
				RaisePropertyChanged("codeListValue");
			}
		}

		/// <remarks />
		[XmlAttribute]
		public string codeSpace
		{
			get
			{
				return codeSpaceField;
			}
			set
			{
				codeSpaceField = value;
				RaisePropertyChanged("codeSpace");
			}
		}

		/// <remarks />
		[XmlText]
		public string Value
		{
			get
			{
				return valueField;
			}
			set
			{
				valueField = value;
				RaisePropertyChanged("Value");
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