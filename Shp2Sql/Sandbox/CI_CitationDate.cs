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
	[XmlType(AnonymousType = true, Namespace = "http://www.isotc211.org/2005/gmd")]
	public class CI_CitationDate : object, INotifyPropertyChanged
	{
		private string nilReasonField;

		/// <remarks />
		[XmlAttribute(Form = XmlSchemaForm.Qualified, Namespace = "http://www.isotc211.org/2005/gco")]
		public string nilReason
		{
			get
			{
				return nilReasonField;
			}
			set
			{
				nilReasonField = value;
				RaisePropertyChanged("nilReason");
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