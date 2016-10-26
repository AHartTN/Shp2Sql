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
	public class metadataDistinfoStdorder : object, INotifyPropertyChanged
	{
		private metadataDistinfoStdorderDigform[] digformField;

		private string feesField;

		private string orderingField;

		/// <remarks />
		[XmlElement(Form = XmlSchemaForm.Unqualified, Order = 0)]
		public string fees
		{
			get
			{
				return feesField;
			}
			set
			{
				feesField = value;
				RaisePropertyChanged("fees");
			}
		}

		/// <remarks />
		[XmlElement(Form = XmlSchemaForm.Unqualified, Order = 1)]
		public string ordering
		{
			get
			{
				return orderingField;
			}
			set
			{
				orderingField = value;
				RaisePropertyChanged("ordering");
			}
		}

		/// <remarks />
		[XmlElement("digform", Form = XmlSchemaForm.Unqualified, Order = 2)]
		public metadataDistinfoStdorderDigform[] digform
		{
			get
			{
				return digformField;
			}
			set
			{
				digformField = value;
				RaisePropertyChanged("digform");
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