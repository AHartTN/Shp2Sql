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
	[XmlType(AnonymousType = true, Namespace = "http://www.isotc211.org/2005/gfc")]
	[XmlRoot(Namespace = "http://www.isotc211.org/2005/gfc", IsNullable = false)]
	public class definition : object, INotifyPropertyChanged
	{
		private string characterStringField;

		/// <remarks />
		[XmlElement(Namespace = "http://www.isotc211.org/2005/gco", Order = 0)]
		public string CharacterString
		{
			get
			{
				return characterStringField;
			}
			set
			{
				characterStringField = value;
				RaisePropertyChanged("CharacterString");
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