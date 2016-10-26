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
	public class metadataIdinfoSpdomBounding : object, INotifyPropertyChanged
	{
		private string eastbcField;

		private string northbcField;

		private string southbcField;

		private string westbcField;

		/// <remarks />
		[XmlElement(Form = XmlSchemaForm.Unqualified, Order = 0)]
		public string westbc
		{
			get
			{
				return westbcField;
			}
			set
			{
				westbcField = value;
				RaisePropertyChanged("westbc");
			}
		}

		/// <remarks />
		[XmlElement(Form = XmlSchemaForm.Unqualified, Order = 1)]
		public string eastbc
		{
			get
			{
				return eastbcField;
			}
			set
			{
				eastbcField = value;
				RaisePropertyChanged("eastbc");
			}
		}

		/// <remarks />
		[XmlElement(Form = XmlSchemaForm.Unqualified, Order = 2)]
		public string northbc
		{
			get
			{
				return northbcField;
			}
			set
			{
				northbcField = value;
				RaisePropertyChanged("northbc");
			}
		}

		/// <remarks />
		[XmlElement(Form = XmlSchemaForm.Unqualified, Order = 3)]
		public string southbc
		{
			get
			{
				return southbcField;
			}
			set
			{
				southbcField = value;
				RaisePropertyChanged("southbc");
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