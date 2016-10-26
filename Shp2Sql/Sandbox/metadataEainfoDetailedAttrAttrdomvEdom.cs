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
	public class metadataEainfoDetailedAttrAttrdomvEdom : object, INotifyPropertyChanged
	{
		private string edomvdField;

		private string edomvdsField;

		private string edomvField;

		/// <remarks />
		[XmlElement(Form = XmlSchemaForm.Unqualified, Order = 0)]
		public string edomv
		{
			get
			{
				return edomvField;
			}
			set
			{
				edomvField = value;
				RaisePropertyChanged("edomv");
			}
		}

		/// <remarks />
		[XmlElement(Form = XmlSchemaForm.Unqualified, Order = 1)]
		public string edomvd
		{
			get
			{
				return edomvdField;
			}
			set
			{
				edomvdField = value;
				RaisePropertyChanged("edomvd");
			}
		}

		/// <remarks />
		[XmlElement(Form = XmlSchemaForm.Unqualified, Order = 2)]
		public string edomvds
		{
			get
			{
				return edomvdsField;
			}
			set
			{
				edomvdsField = value;
				RaisePropertyChanged("edomvds");
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