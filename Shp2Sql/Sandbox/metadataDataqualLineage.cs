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
	public class metadataDataqualLineage : object, INotifyPropertyChanged
	{
		private metadataDataqualLineageProcstep[] procstepField;

		private metadataDataqualLineageSrcinfo[] srcinfoField;

		/// <remarks />
		[XmlElement("srcinfo", Form = XmlSchemaForm.Unqualified, Order = 0)]
		public metadataDataqualLineageSrcinfo[] srcinfo
		{
			get
			{
				return srcinfoField;
			}
			set
			{
				srcinfoField = value;
				RaisePropertyChanged("srcinfo");
			}
		}

		/// <remarks />
		[XmlElement("procstep", Form = XmlSchemaForm.Unqualified, Order = 1)]
		public metadataDataqualLineageProcstep[] procstep
		{
			get
			{
				return procstepField;
			}
			set
			{
				procstepField = value;
				RaisePropertyChanged("procstep");
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