using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnAndDecrypt
{
    public class Base64
    {
		public string Encrypt(string value)
		{
			string result = "";

			try
			{
				if (!string.IsNullOrEmpty(value))
				{
					byte[] bytes = System.Text.UnicodeEncoding.UTF8.GetBytes(value);
					result = Convert.ToBase64String(bytes);
				}
			}
			catch { }

			return result;
		}

		public string Decrypt(string value)
		{
			string result = "";

			try
			{
				byte[] bytes = Convert.FromBase64String(value);

				result = System.Text.Encoding.UTF8.GetString(bytes);
			}
			catch { }

			return result;
		}
	}
}
