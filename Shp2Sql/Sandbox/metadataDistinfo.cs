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
	public class metadataDistinfo : object, INotifyPropertyChanged
	{
		private string distliabField;

		private cntinfo[][] distribField;

		private metadataDistinfoStdorder[] stdorderField;

		private string techpreqField;

		/// <remarks />
		[XmlElement(Form = XmlSchemaForm.Unqualified, Order = 0)]
		public string distliab
		{
			get
			{
				return distliabField;
			}
			set
			{
				distliabField = value;
				RaisePropertyChanged("distliab");
			}
		}

		/// <remarks />
		[XmlElement(Form = XmlSchemaForm.Unqualified, Order = 1)]
		public string techpreq
		{
			get
			{
				return techpreqField;
			}
			set
			{
				techpreqField = value;
				RaisePropertyChanged("techpreq");
			}
		}

		/// <remarks />
		[XmlArray(Form = XmlSchemaForm.Unqualified, Order = 2)]
		[XmlArrayItem("cntinfo", typeof (cntinfo), IsNullable = false)]
		public cntinfo[][] distrib
		{
			get
			{
				return distribField;
			}
			set
			{
				distribField = value;
				RaisePropertyChanged("distrib");
			}
		}

		/// <remarks />
		[XmlElement("stdorder", Form = XmlSchemaForm.Unqualified, Order = 3)]
		public metadataDistinfoStdorder[] stdorder
		{
			get
			{
				return stdorderField;
			}
			set
			{
				stdorderField = value;
				RaisePropertyChanged("stdorder");
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