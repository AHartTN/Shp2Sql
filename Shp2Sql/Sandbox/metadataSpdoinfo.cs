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
	public class metadataSpdoinfo : object, INotifyPropertyChanged
	{
		private string directField;

		private string indsprefField;

		private metadataSpdoinfoPtvctinfSdtsterm[][] ptvctinfField;

		/// <remarks />
		[XmlElement(Form = XmlSchemaForm.Unqualified, Order = 0)]
		public string indspref
		{
			get
			{
				return indsprefField;
			}
			set
			{
				indsprefField = value;
				RaisePropertyChanged("indspref");
			}
		}

		/// <remarks />
		[XmlElement(Form = XmlSchemaForm.Unqualified, Order = 1)]
		public string direct
		{
			get
			{
				return directField;
			}
			set
			{
				directField = value;
				RaisePropertyChanged("direct");
			}
		}

		/// <remarks />
		[XmlArray(Form = XmlSchemaForm.Unqualified, Order = 2)]
		[XmlArrayItem("sdtsterm", typeof (metadataSpdoinfoPtvctinfSdtsterm), Form = XmlSchemaForm.Unqualified,
			IsNullable = false)]
		public metadataSpdoinfoPtvctinfSdtsterm[][] ptvctinf
		{
			get
			{
				return ptvctinfField;
			}
			set
			{
				ptvctinfField = value;
				RaisePropertyChanged("ptvctinf");
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