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
	public class metadataDistinfoStdorderDigform : object, INotifyPropertyChanged
	{
		private metadataDistinfoStdorderDigformDigtinfo[] digtinfoField;

		private metadataDistinfoStdorderDigformDigtoptOnlinoptComputerNetworka[][][][] digtoptField;

		/// <remarks />
		[XmlElement("digtinfo", Form = XmlSchemaForm.Unqualified, Order = 0)]
		public metadataDistinfoStdorderDigformDigtinfo[] digtinfo
		{
			get
			{
				return digtinfoField;
			}
			set
			{
				digtinfoField = value;
				RaisePropertyChanged("digtinfo");
			}
		}

		/// <remarks />
		[XmlArray(Form = XmlSchemaForm.Unqualified, Order = 1)]
		[XmlArrayItem("onlinopt", typeof (metadataDistinfoStdorderDigformDigtoptOnlinoptComputerNetworka[][]),
			Form = XmlSchemaForm.Unqualified, IsNullable = false)]
		[XmlArrayItem("computer", typeof (metadataDistinfoStdorderDigformDigtoptOnlinoptComputerNetworka[]),
			Form = XmlSchemaForm.Unqualified, IsNullable = false, NestingLevel = 1)]
		[XmlArrayItem("networka", typeof (metadataDistinfoStdorderDigformDigtoptOnlinoptComputerNetworka),
			Form = XmlSchemaForm.Unqualified, IsNullable = false, NestingLevel = 2)]
		public metadataDistinfoStdorderDigformDigtoptOnlinoptComputerNetworka[][][][] digtopt
		{
			get
			{
				return digtoptField;
			}
			set
			{
				digtoptField = value;
				RaisePropertyChanged("digtopt");
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