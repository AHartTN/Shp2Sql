namespace Shp2Sql.Sandbox
{
	#region Imports

	using System;
	using System.CodeDom.Compiler;
	using System.ComponentModel;
	using System.Diagnostics;
	using System.Xml.Serialization;

	#endregion
	/// <remarks />
	[GeneratedCode("xsd", "4.6.1055.0")]
	[Serializable]
	[DebuggerStepThrough]
	[DesignerCategory("code")]
	[XmlType(AnonymousType = true, Namespace = "http://www.isotc211.org/2005/gmx")]
	[XmlRoot(Namespace = "http://www.isotc211.org/2005/gmx", IsNullable = false)]
	public class characterSet : object, INotifyPropertyChanged
	{
		private MD_CharacterSetCode mD_CharacterSetCodeField;

		/// <remarks />
		[XmlElement(Namespace = "http://www.isotc211.org/2005/gmd", IsNullable = true, Order = 0)]
		public MD_CharacterSetCode MD_CharacterSetCode
		{
			get
			{
				return mD_CharacterSetCodeField;
			}
			set
			{
				mD_CharacterSetCodeField = value;
				RaisePropertyChanged("MD_CharacterSetCode");
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