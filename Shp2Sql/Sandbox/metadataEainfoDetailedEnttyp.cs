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
	[XmlType(AnonymousType = true)]
	public class metadataEainfoDetailedEnttyp : object, INotifyPropertyChanged
	{
		private string enttypdField;

		private string enttypdsField;

		private string enttyplField;

		/// <remarks />
		[XmlElement(Form = XmlSchemaForm.Unqualified, Order = 0)]
		public string enttypl
		{
			get
			{
				return enttyplField;
			}
			set
			{
				enttyplField = value;
				RaisePropertyChanged("enttypl");
			}
		}

		/// <remarks />
		[XmlElement(Form = XmlSchemaForm.Unqualified, Order = 1)]
		public string enttypd
		{
			get
			{
				return enttypdField;
			}
			set
			{
				enttypdField = value;
				RaisePropertyChanged("enttypd");
			}
		}

		/// <remarks />
		[XmlElement(Form = XmlSchemaForm.Unqualified, Order = 2)]
		public string enttypds
		{
			get
			{
				return enttypdsField;
			}
			set
			{
				enttypdsField = value;
				RaisePropertyChanged("enttypds");
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