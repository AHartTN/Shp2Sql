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
	public class metadataDataqual : object, INotifyPropertyChanged
	{
		private metadataDataqualAttracc[] attraccField;

		private string completeField;

		private metadataDataqualLineage[] lineageField;

		private string logicField;

		private metadataDataqualPosaccHorizpa[][] posaccField;

		/// <remarks />
		[XmlElement(Form = XmlSchemaForm.Unqualified, Order = 0)]
		public string logic
		{
			get
			{
				return logicField;
			}
			set
			{
				logicField = value;
				RaisePropertyChanged("logic");
			}
		}

		/// <remarks />
		[XmlElement(Form = XmlSchemaForm.Unqualified, Order = 1)]
		public string complete
		{
			get
			{
				return completeField;
			}
			set
			{
				completeField = value;
				RaisePropertyChanged("complete");
			}
		}

		/// <remarks />
		[XmlElement("attracc", Form = XmlSchemaForm.Unqualified, Order = 2)]
		public metadataDataqualAttracc[] attracc
		{
			get
			{
				return attraccField;
			}
			set
			{
				attraccField = value;
				RaisePropertyChanged("attracc");
			}
		}

		/// <remarks />
		[XmlArray(Form = XmlSchemaForm.Unqualified, Order = 3)]
		[XmlArrayItem("horizpa", typeof (metadataDataqualPosaccHorizpa), Form = XmlSchemaForm.Unqualified, IsNullable = false)
		]
		public metadataDataqualPosaccHorizpa[][] posacc
		{
			get
			{
				return posaccField;
			}
			set
			{
				posaccField = value;
				RaisePropertyChanged("posacc");
			}
		}

		/// <remarks />
		[XmlElement("lineage", Form = XmlSchemaForm.Unqualified, Order = 4)]
		public metadataDataqualLineage[] lineage
		{
			get
			{
				return lineageField;
			}
			set
			{
				lineageField = value;
				RaisePropertyChanged("lineage");
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