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
	public class metadataIdinfoKeywordsTheme : object, INotifyPropertyChanged
	{
		private metadataIdinfoKeywordsThemeThemekey[] themekeyField;

		private string themektField;

		/// <remarks />
		[XmlElement(Form = XmlSchemaForm.Unqualified, Order = 0)]
		public string themekt
		{
			get
			{
				return themektField;
			}
			set
			{
				themektField = value;
				RaisePropertyChanged("themekt");
			}
		}

		/// <remarks />
		[XmlElement("themekey", Form = XmlSchemaForm.Unqualified, IsNullable = true, Order = 1)]
		public metadataIdinfoKeywordsThemeThemekey[] themekey
		{
			get
			{
				return themekeyField;
			}
			set
			{
				themekeyField = value;
				RaisePropertyChanged("themekey");
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