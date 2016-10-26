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
	public class timeinfo : object, INotifyPropertyChanged
	{
		private timeinfoRngdates[] rngdatesField;

		/// <remarks />
		[XmlElement("rngdates", Form = XmlSchemaForm.Unqualified, Order = 0)]
		public timeinfoRngdates[] rngdates
		{
			get
			{
				return rngdatesField;
			}
			set
			{
				rngdatesField = value;
				RaisePropertyChanged("rngdates");
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