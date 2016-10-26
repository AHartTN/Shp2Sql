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
	public class metadataDataqualLineageSrcinfoSrctime : object, INotifyPropertyChanged
	{
		private string srccurrField;

		private timeinfoRngdates[][] timeinfoField;

		/// <remarks />
		[XmlElement(Form = XmlSchemaForm.Unqualified, Order = 0)]
		public string srccurr
		{
			get
			{
				return srccurrField;
			}
			set
			{
				srccurrField = value;
				RaisePropertyChanged("srccurr");
			}
		}

		/// <remarks />
		[XmlArray(Order = 1)]
		[XmlArrayItem("rngdates", typeof (timeinfoRngdates), Form = XmlSchemaForm.Unqualified, IsNullable = false)]
		public timeinfoRngdates[][] timeinfo
		{
			get
			{
				return timeinfoField;
			}
			set
			{
				timeinfoField = value;
				RaisePropertyChanged("timeinfo");
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