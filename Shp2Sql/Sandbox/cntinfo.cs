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
	[XmlRoot(Namespace = "", IsNullable = false)]
	public class cntinfo : object, INotifyPropertyChanged
	{
		private cntinfoCntaddr[] cntaddrField;

		private string cntemailField;

		private string cntfaxField;

		private cntinfoCntorgp[] cntorgpField;

		private string cntvoiceField;

		/// <remarks />
		[XmlElement(Form = XmlSchemaForm.Unqualified, Order = 0)]
		public string cntvoice
		{
			get
			{
				return cntvoiceField;
			}
			set
			{
				cntvoiceField = value;
				RaisePropertyChanged("cntvoice");
			}
		}

		/// <remarks />
		[XmlElement(Form = XmlSchemaForm.Unqualified, Order = 1)]
		public string cntfax
		{
			get
			{
				return cntfaxField;
			}
			set
			{
				cntfaxField = value;
				RaisePropertyChanged("cntfax");
			}
		}

		/// <remarks />
		[XmlElement(Form = XmlSchemaForm.Unqualified, Order = 2)]
		public string cntemail
		{
			get
			{
				return cntemailField;
			}
			set
			{
				cntemailField = value;
				RaisePropertyChanged("cntemail");
			}
		}

		/// <remarks />
		[XmlElement("cntorgp", Form = XmlSchemaForm.Unqualified, Order = 3)]
		public cntinfoCntorgp[] cntorgp
		{
			get
			{
				return cntorgpField;
			}
			set
			{
				cntorgpField = value;
				RaisePropertyChanged("cntorgp");
			}
		}

		/// <remarks />
		[XmlElement("cntaddr", Form = XmlSchemaForm.Unqualified, Order = 4)]
		public cntinfoCntaddr[] cntaddr
		{
			get
			{
				return cntaddrField;
			}
			set
			{
				cntaddrField = value;
				RaisePropertyChanged("cntaddr");
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