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
	public class metadataDataqualLineageProcstep : object, INotifyPropertyChanged
	{
		private string procdateField;

		private string procdescField;

		private string srcusedField;

		/// <remarks />
		[XmlElement(Form = XmlSchemaForm.Unqualified, Order = 0)]
		public string procdesc
		{
			get
			{
				return procdescField;
			}
			set
			{
				procdescField = value;
				RaisePropertyChanged("procdesc");
			}
		}

		/// <remarks />
		[XmlElement(Form = XmlSchemaForm.Unqualified, Order = 1)]
		public string srcused
		{
			get
			{
				return srcusedField;
			}
			set
			{
				srcusedField = value;
				RaisePropertyChanged("srcused");
			}
		}

		/// <remarks />
		[XmlElement(Form = XmlSchemaForm.Unqualified, Order = 2)]
		public string procdate
		{
			get
			{
				return procdateField;
			}
			set
			{
				procdateField = value;
				RaisePropertyChanged("procdate");
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