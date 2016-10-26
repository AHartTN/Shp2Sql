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
	public class metadataIdinfo : object, INotifyPropertyChanged
	{
		private string accconstField;

		private citeinfo[][] citationField;

		private metadataIdinfoDescript[] descriptField;

		private metadataIdinfoKeywords[] keywordsField;

		private cntinfo[][] ptcontacField;

		private metadataIdinfoSpdomBounding[][] spdomField;

		private metadataIdinfoStatus[] statusField;

		private metadataIdinfoTimeperd[] timeperdField;

		private string useconstField;

		/// <remarks />
		[XmlElement(Form = XmlSchemaForm.Unqualified, Order = 0)]
		public string accconst
		{
			get
			{
				return accconstField;
			}
			set
			{
				accconstField = value;
				RaisePropertyChanged("accconst");
			}
		}

		/// <remarks />
		[XmlElement(Form = XmlSchemaForm.Unqualified, Order = 1)]
		public string useconst
		{
			get
			{
				return useconstField;
			}
			set
			{
				useconstField = value;
				RaisePropertyChanged("useconst");
			}
		}

		/// <remarks />
		[XmlArray(Form = XmlSchemaForm.Unqualified, Order = 2)]
		[XmlArrayItem("citeinfo", typeof (citeinfo), IsNullable = false)]
		public citeinfo[][] citation
		{
			get
			{
				return citationField;
			}
			set
			{
				citationField = value;
				RaisePropertyChanged("citation");
			}
		}

		/// <remarks />
		[XmlElement("descript", Form = XmlSchemaForm.Unqualified, Order = 3)]
		public metadataIdinfoDescript[] descript
		{
			get
			{
				return descriptField;
			}
			set
			{
				descriptField = value;
				RaisePropertyChanged("descript");
			}
		}

		/// <remarks />
		[XmlElement("timeperd", Form = XmlSchemaForm.Unqualified, Order = 4)]
		public metadataIdinfoTimeperd[] timeperd
		{
			get
			{
				return timeperdField;
			}
			set
			{
				timeperdField = value;
				RaisePropertyChanged("timeperd");
			}
		}

		/// <remarks />
		[XmlElement("status", Form = XmlSchemaForm.Unqualified, Order = 5)]
		public metadataIdinfoStatus[] status
		{
			get
			{
				return statusField;
			}
			set
			{
				statusField = value;
				RaisePropertyChanged("status");
			}
		}

		/// <remarks />
		[XmlArray(Form = XmlSchemaForm.Unqualified, Order = 6)]
		[XmlArrayItem("bounding", typeof (metadataIdinfoSpdomBounding), Form = XmlSchemaForm.Unqualified, IsNullable = false)]
		public metadataIdinfoSpdomBounding[][] spdom
		{
			get
			{
				return spdomField;
			}
			set
			{
				spdomField = value;
				RaisePropertyChanged("spdom");
			}
		}

		/// <remarks />
		[XmlElement("keywords", Form = XmlSchemaForm.Unqualified, Order = 7)]
		public metadataIdinfoKeywords[] keywords
		{
			get
			{
				return keywordsField;
			}
			set
			{
				keywordsField = value;
				RaisePropertyChanged("keywords");
			}
		}

		/// <remarks />
		[XmlArray(Form = XmlSchemaForm.Unqualified, Order = 8)]
		[XmlArrayItem("cntinfo", typeof (cntinfo), IsNullable = false)]
		public cntinfo[][] ptcontac
		{
			get
			{
				return ptcontacField;
			}
			set
			{
				ptcontacField = value;
				RaisePropertyChanged("ptcontac");
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