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
	public class metadataIdinfoKeywordsPlace : object, INotifyPropertyChanged
	{
		private metadataIdinfoKeywordsPlacePlacekey[] placekeyField;

		private string placektField;

		/// <remarks />
		[XmlElement(Form = XmlSchemaForm.Unqualified, Order = 0)]
		public string placekt
		{
			get
			{
				return placektField;
			}
			set
			{
				placektField = value;
				RaisePropertyChanged("placekt");
			}
		}

		/// <remarks />
		[XmlElement("placekey", Form = XmlSchemaForm.Unqualified, IsNullable = true, Order = 1)]
		public metadataIdinfoKeywordsPlacePlacekey[] placekey
		{
			get
			{
				return placekeyField;
			}
			set
			{
				placekeyField = value;
				RaisePropertyChanged("placekey");
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