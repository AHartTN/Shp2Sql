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
	public class metadataEainfoDetailedAttrAttrdomv : object, INotifyPropertyChanged
	{
		private metadataEainfoDetailedAttrAttrdomvCodesetd[] codesetdField;

		private metadataEainfoDetailedAttrAttrdomvEdom[] edomField;

		private metadataEainfoDetailedAttrAttrdomvRdom[] rdomField;

		private string udomField;

		/// <remarks />
		[XmlElement(Form = XmlSchemaForm.Unqualified, Order = 0)]
		public string udom
		{
			get
			{
				return udomField;
			}
			set
			{
				udomField = value;
				RaisePropertyChanged("udom");
			}
		}

		/// <remarks />
		[XmlElement("edom", Form = XmlSchemaForm.Unqualified, Order = 1)]
		public metadataEainfoDetailedAttrAttrdomvEdom[] edom
		{
			get
			{
				return edomField;
			}
			set
			{
				edomField = value;
				RaisePropertyChanged("edom");
			}
		}

		/// <remarks />
		[XmlElement("rdom", Form = XmlSchemaForm.Unqualified, Order = 2)]
		public metadataEainfoDetailedAttrAttrdomvRdom[] rdom
		{
			get
			{
				return rdomField;
			}
			set
			{
				rdomField = value;
				RaisePropertyChanged("rdom");
			}
		}

		/// <remarks />
		[XmlElement("codesetd", Form = XmlSchemaForm.Unqualified, Order = 3)]
		public metadataEainfoDetailedAttrAttrdomvCodesetd[] codesetd
		{
			get
			{
				return codesetdField;
			}
			set
			{
				codesetdField = value;
				RaisePropertyChanged("codesetd");
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