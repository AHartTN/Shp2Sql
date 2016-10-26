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
	public class metadataDataqualLineageSrcinfo : object, INotifyPropertyChanged
	{
		private string srcciteaField;

		private citeinfo[][] srcciteField;

		private string srccontrField;

		private metadataDataqualLineageSrcinfoSrctime[] srctimeField;

		private string typesrcField;

		/// <remarks />
		[XmlElement(Form = XmlSchemaForm.Unqualified, Order = 0)]
		public string typesrc
		{
			get
			{
				return typesrcField;
			}
			set
			{
				typesrcField = value;
				RaisePropertyChanged("typesrc");
			}
		}

		/// <remarks />
		[XmlElement(Form = XmlSchemaForm.Unqualified, Order = 1)]
		public string srccitea
		{
			get
			{
				return srcciteaField;
			}
			set
			{
				srcciteaField = value;
				RaisePropertyChanged("srccitea");
			}
		}

		/// <remarks />
		[XmlElement(Form = XmlSchemaForm.Unqualified, Order = 2)]
		public string srccontr
		{
			get
			{
				return srccontrField;
			}
			set
			{
				srccontrField = value;
				RaisePropertyChanged("srccontr");
			}
		}

		/// <remarks />
		[XmlArray(Form = XmlSchemaForm.Unqualified, Order = 3)]
		[XmlArrayItem("citeinfo", typeof (citeinfo), IsNullable = false)]
		public citeinfo[][] srccite
		{
			get
			{
				return srcciteField;
			}
			set
			{
				srcciteField = value;
				RaisePropertyChanged("srccite");
			}
		}

		/// <remarks />
		[XmlElement("srctime", Form = XmlSchemaForm.Unqualified, Order = 4)]
		public metadataDataqualLineageSrcinfoSrctime[] srctime
		{
			get
			{
				return srctimeField;
			}
			set
			{
				srctimeField = value;
				RaisePropertyChanged("srctime");
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