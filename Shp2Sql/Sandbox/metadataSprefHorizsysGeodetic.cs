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
	public class metadataSprefHorizsysGeodetic : object, INotifyPropertyChanged
	{
		private string denflatField;

		private string ellipsField;

		private string horizdnField;

		private string semiaxisField;

		/// <remarks />
		[XmlElement(Form = XmlSchemaForm.Unqualified, Order = 0)]
		public string horizdn
		{
			get
			{
				return horizdnField;
			}
			set
			{
				horizdnField = value;
				RaisePropertyChanged("horizdn");
			}
		}

		/// <remarks />
		[XmlElement(Form = XmlSchemaForm.Unqualified, Order = 1)]
		public string ellips
		{
			get
			{
				return ellipsField;
			}
			set
			{
				ellipsField = value;
				RaisePropertyChanged("ellips");
			}
		}

		/// <remarks />
		[XmlElement(Form = XmlSchemaForm.Unqualified, Order = 2)]
		public string semiaxis
		{
			get
			{
				return semiaxisField;
			}
			set
			{
				semiaxisField = value;
				RaisePropertyChanged("semiaxis");
			}
		}

		/// <remarks />
		[XmlElement(Form = XmlSchemaForm.Unqualified, Order = 3)]
		public string denflat
		{
			get
			{
				return denflatField;
			}
			set
			{
				denflatField = value;
				RaisePropertyChanged("denflat");
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