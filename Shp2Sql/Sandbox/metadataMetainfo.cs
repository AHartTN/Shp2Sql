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
	public class metadataMetainfo : object, INotifyPropertyChanged
	{
		private cntinfo[][] metcField;

		private string metdField;

		private string metstdnField;

		private string metstdvField;

		/// <remarks />
		[XmlElement(Form = XmlSchemaForm.Unqualified, Order = 0)]
		public string metd
		{
			get
			{
				return metdField;
			}
			set
			{
				metdField = value;
				RaisePropertyChanged("metd");
			}
		}

		/// <remarks />
		[XmlElement(Form = XmlSchemaForm.Unqualified, Order = 1)]
		public string metstdn
		{
			get
			{
				return metstdnField;
			}
			set
			{
				metstdnField = value;
				RaisePropertyChanged("metstdn");
			}
		}

		/// <remarks />
		[XmlElement(Form = XmlSchemaForm.Unqualified, Order = 2)]
		public string metstdv
		{
			get
			{
				return metstdvField;
			}
			set
			{
				metstdvField = value;
				RaisePropertyChanged("metstdv");
			}
		}

		/// <remarks />
		[XmlArray(Form = XmlSchemaForm.Unqualified, Order = 3)]
		[XmlArrayItem("cntinfo", typeof (cntinfo), IsNullable = false)]
		public cntinfo[][] metc
		{
			get
			{
				return metcField;
			}
			set
			{
				metcField = value;
				RaisePropertyChanged("metc");
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