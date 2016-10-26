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
	public class metadataDataqualPosaccHorizpa : object, INotifyPropertyChanged
	{
		private string horizparField;

		private metadataDataqualPosaccHorizpaQhorizpa[] qhorizpaField;

		/// <remarks />
		[XmlElement(Form = XmlSchemaForm.Unqualified, Order = 0)]
		public string horizpar
		{
			get
			{
				return horizparField;
			}
			set
			{
				horizparField = value;
				RaisePropertyChanged("horizpar");
			}
		}

		/// <remarks />
		[XmlElement("qhorizpa", Form = XmlSchemaForm.Unqualified, Order = 1)]
		public metadataDataqualPosaccHorizpaQhorizpa[] qhorizpa
		{
			get
			{
				return qhorizpaField;
			}
			set
			{
				qhorizpaField = value;
				RaisePropertyChanged("qhorizpa");
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