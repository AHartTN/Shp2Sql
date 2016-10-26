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
	public class cntinfoCntaddr : object, INotifyPropertyChanged
	{
		private string addressField;

		private string addrtypeField;

		private string cityField;

		private string countryField;

		private string postalField;

		private string stateField;

		/// <remarks />
		[XmlElement(Form = XmlSchemaForm.Unqualified, Order = 0)]
		public string addrtype
		{
			get
			{
				return addrtypeField;
			}
			set
			{
				addrtypeField = value;
				RaisePropertyChanged("addrtype");
			}
		}

		/// <remarks />
		[XmlElement(Form = XmlSchemaForm.Unqualified, Order = 1)]
		public string address
		{
			get
			{
				return addressField;
			}
			set
			{
				addressField = value;
				RaisePropertyChanged("address");
			}
		}

		/// <remarks />
		[XmlElement(Form = XmlSchemaForm.Unqualified, Order = 2)]
		public string city
		{
			get
			{
				return cityField;
			}
			set
			{
				cityField = value;
				RaisePropertyChanged("city");
			}
		}

		/// <remarks />
		[XmlElement(Form = XmlSchemaForm.Unqualified, Order = 3)]
		public string state
		{
			get
			{
				return stateField;
			}
			set
			{
				stateField = value;
				RaisePropertyChanged("state");
			}
		}

		/// <remarks />
		[XmlElement(Form = XmlSchemaForm.Unqualified, Order = 4)]
		public string postal
		{
			get
			{
				return postalField;
			}
			set
			{
				postalField = value;
				RaisePropertyChanged("postal");
			}
		}

		/// <remarks />
		[XmlElement(Form = XmlSchemaForm.Unqualified, Order = 5)]
		public string country
		{
			get
			{
				return countryField;
			}
			set
			{
				countryField = value;
				RaisePropertyChanged("country");
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