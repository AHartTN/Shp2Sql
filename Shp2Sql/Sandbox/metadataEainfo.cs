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
	public class metadataEainfo : object, INotifyPropertyChanged
	{
		private metadataEainfoDetailed[] detailedField;

		/// <remarks />
		[XmlElement("detailed", Form = XmlSchemaForm.Unqualified, Order = 0)]
		public metadataEainfoDetailed[] detailed
		{
			get
			{
				return detailedField;
			}
			set
			{
				detailedField = value;
				RaisePropertyChanged("detailed");
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