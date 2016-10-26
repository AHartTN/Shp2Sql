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
	public class metadataSprefHorizsys : object, INotifyPropertyChanged
	{
		private metadataSprefHorizsysGeodetic[] geodeticField;

		private metadataSprefHorizsysGeograph[] geographField;

		/// <remarks />
		[XmlElement("geograph", Form = XmlSchemaForm.Unqualified, Order = 0)]
		public metadataSprefHorizsysGeograph[] geograph
		{
			get
			{
				return geographField;
			}
			set
			{
				geographField = value;
				RaisePropertyChanged("geograph");
			}
		}

		/// <remarks />
		[XmlElement("geodetic", Form = XmlSchemaForm.Unqualified, Order = 1)]
		public metadataSprefHorizsysGeodetic[] geodetic
		{
			get
			{
				return geodeticField;
			}
			set
			{
				geodeticField = value;
				RaisePropertyChanged("geodetic");
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