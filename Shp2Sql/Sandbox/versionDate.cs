namespace Shp2Sql.Sandbox
{
	#region Imports

	using System;
	using System.CodeDom.Compiler;
	using System.ComponentModel;
	using System.Diagnostics;
	using System.Xml.Serialization;

	#endregion
	/// <remarks />
	[GeneratedCode("xsd", "4.6.1055.0")]
	[Serializable]
	[DebuggerStepThrough]
	[DesignerCategory("code")]
	[XmlType(AnonymousType = true, Namespace = "http://www.isotc211.org/2005/gmx")]
	[XmlRoot(Namespace = "http://www.isotc211.org/2005/gmx", IsNullable = false)]
	public class versionDate : object, INotifyPropertyChanged
	{
		private string dateField;

		/// <remarks />
		[XmlElement(Namespace = "http://www.isotc211.org/2005/gco", Order = 0)]
		public string Date
		{
			get
			{
				return dateField;
			}
			set
			{
				dateField = value;
				RaisePropertyChanged("Date");
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