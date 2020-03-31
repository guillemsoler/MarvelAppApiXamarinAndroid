using System;
using System.Collections.Generic;
using System.Text;

namespace AppXamAndroid.Models
{
	public class MarvelModel
	{
		private int _id;

		public int Id
		{
			get { return _id; }
			set
			{
				_id = value;
			}
		}

		private string _pjName;

		public string PjName
		{
			get { return _pjName; }
			set
			{
				_pjName = value;
			}
		}

		private string _description;

		public string Description
		{
			get { return _description; }
			set
			{
				_description = value;
			}
		}

		private string _url;

		public string Url
		{
			get { return _url; }
			set
			{
				_url = value;
			}
		}

	}
}
