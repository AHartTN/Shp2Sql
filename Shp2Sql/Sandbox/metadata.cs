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
	[XmlRoot(Namespace = "", IsNullable = false)]
	public class metadata : object, INotifyPropertyChanged
	{
		private object[] itemsField;

		/// <remarks />
		[XmlElement("citeinfo", typeof (citeinfo), Order = 0)]
		[XmlElement("cntinfo", typeof (cntinfo), Order = 0)]
		[XmlElement("dataqual", typeof (metadataDataqual), Form = XmlSchemaForm.Unqualified, Order = 0)]
		[XmlElement("distinfo", typeof (metadataDistinfo), Form = XmlSchemaForm.Unqualified, Order = 0)]
		[XmlElement("eainfo", typeof (metadataEainfo), Form = XmlSchemaForm.Unqualified, Order = 0)]
		[XmlElement("idinfo", typeof (metadataIdinfo), Form = XmlSchemaForm.Unqualified, Order = 0)]
		[XmlElement("metainfo", typeof (metadataMetainfo), Form = XmlSchemaForm.Unqualified, Order = 0)]
		[XmlElement("spdoinfo", typeof (metadataSpdoinfo), Form = XmlSchemaForm.Unqualified, Order = 0)]
		[XmlElement("spref", typeof (metadataSpref), Form = XmlSchemaForm.Unqualified, Order = 0)]
		[XmlElement("timeinfo", typeof (timeinfo), Order = 0)]
		public object[] Items
		{
			get
			{
				return itemsField;
			}
			set
			{
				itemsField = value;
				RaisePropertyChanged("Items");
			}
		}

		public event PropertyChangedEventHandler PropertyChanged;

		protected void RaisePropertyChanged(string propertyName)
		{
			PropertyChangedEventHandler propertyChanged = PropertyChanged;
			propertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
		}
	}
}