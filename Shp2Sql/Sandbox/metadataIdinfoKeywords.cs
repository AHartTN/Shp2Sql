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
	public class metadataIdinfoKeywords : object, INotifyPropertyChanged
	{
		private metadataIdinfoKeywordsPlace[] placeField;

		private metadataIdinfoKeywordsTheme[] themeField;

		/// <remarks />
		[XmlElement("theme", Form = XmlSchemaForm.Unqualified, Order = 0)]
		public metadataIdinfoKeywordsTheme[] theme
		{
			get
			{
				return themeField;
			}
			set
			{
				themeField = value;
				RaisePropertyChanged("theme");
			}
		}

		/// <remarks />
		[XmlElement("place", Form = XmlSchemaForm.Unqualified, Order = 1)]
		public metadataIdinfoKeywordsPlace[] place
		{
			get
			{
				return placeField;
			}
			set
			{
				placeField = value;
				RaisePropertyChanged("place");
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