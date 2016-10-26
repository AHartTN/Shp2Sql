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
	public class metadataSpref : object, INotifyPropertyChanged
	{
		private metadataSprefHorizsys[] horizsysField;

		/// <remarks />
		[XmlElement("horizsys", Form = XmlSchemaForm.Unqualified, Order = 0)]
		public metadataSprefHorizsys[] horizsys
		{
			get
			{
				return horizsysField;
			}
			set
			{
				horizsysField = value;
				RaisePropertyChanged("horizsys");
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