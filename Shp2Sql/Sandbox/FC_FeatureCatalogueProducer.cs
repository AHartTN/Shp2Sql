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
	[XmlType(AnonymousType = true, Namespace = "http://www.isotc211.org/2005/gfc")]
	public class FC_FeatureCatalogueProducer : object, INotifyPropertyChanged
	{
		private string hrefField;

		private string titleField;

		/// <remarks />
		[XmlAttribute(Form = XmlSchemaForm.Qualified, Namespace = "http://www.w3.org/1999/xlink")]
		public string href
		{
			get
			{
				return hrefField;
			}
			set
			{
				hrefField = value;
				RaisePropertyChanged("href");
			}
		}

		/// <remarks />
		[XmlAttribute(Form = XmlSchemaForm.Qualified, Namespace = "http://www.w3.org/1999/xlink")]
		public string title
		{
			get
			{
				return titleField;
			}
			set
			{
				titleField = value;
				RaisePropertyChanged("title");
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