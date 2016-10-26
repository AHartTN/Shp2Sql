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
	public class metadataEainfoDetailedAttr : object, INotifyPropertyChanged
	{
		private string attrdefField;

		private string attrdefsField;

		private metadataEainfoDetailedAttrAttrdomv[] attrdomvField;

		private string attrlablField;

		/// <remarks />
		[XmlElement(Form = XmlSchemaForm.Unqualified, Order = 0)]
		public string attrlabl
		{
			get
			{
				return attrlablField;
			}
			set
			{
				attrlablField = value;
				RaisePropertyChanged("attrlabl");
			}
		}

		/// <remarks />
		[XmlElement(Form = XmlSchemaForm.Unqualified, Order = 1)]
		public string attrdef
		{
			get
			{
				return attrdefField;
			}
			set
			{
				attrdefField = value;
				RaisePropertyChanged("attrdef");
			}
		}

		/// <remarks />
		[XmlElement(Form = XmlSchemaForm.Unqualified, Order = 2)]
		public string attrdefs
		{
			get
			{
				return attrdefsField;
			}
			set
			{
				attrdefsField = value;
				RaisePropertyChanged("attrdefs");
			}
		}

		/// <remarks />
		[XmlElement("attrdomv", Form = XmlSchemaForm.Unqualified, Order = 3)]
		public metadataEainfoDetailedAttrAttrdomv[] attrdomv
		{
			get
			{
				return attrdomvField;
			}
			set
			{
				attrdomvField = value;
				RaisePropertyChanged("attrdomv");
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