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
	public class metadataEainfoDetailed : object, INotifyPropertyChanged
	{
		private metadataEainfoDetailedAttr[] attrField;

		private metadataEainfoDetailedEnttyp[] enttypField;

		/// <remarks />
		[XmlElement("enttyp", Form = XmlSchemaForm.Unqualified, Order = 0)]
		public metadataEainfoDetailedEnttyp[] enttyp
		{
			get
			{
				return enttypField;
			}
			set
			{
				enttypField = value;
				RaisePropertyChanged("enttyp");
			}
		}

		/// <remarks />
		[XmlElement("attr", Form = XmlSchemaForm.Unqualified, Order = 1)]
		public metadataEainfoDetailedAttr[] attr
		{
			get
			{
				return attrField;
			}
			set
			{
				attrField = value;
				RaisePropertyChanged("attr");
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