using System;
using System.Text;

namespace Fenix.Extensions
{
	/// <summary>
	/// Rozšíření implementace <see cref="String"/> a pole <see cref="Byte"/>
	/// </summary>
	public static class Extensions
	{
		/// <summary>
		/// Test 'neprázdnosti' řetězce
		/// </summary>
		/// <param name="s">Testovaný řetězec</param>
		/// <returns>true .. není prázdný, resp. není null;  false .. je prázdný, resp. je null</returns>
		public static bool IsNotNullOrEmpty(this string s)
		{
			return !String.IsNullOrEmpty(s);
		}

		/// <summary>
		/// Test 'prázdnosti' řetězce
		/// </summary>
		/// <param name="s">Testovaný řetězec</param>
		/// <returns>true .. je prázdný, resp. je null;  false .. není prázdný, resp. není null</returns>
		public static bool IsNullOrEmpty(this string s)
		{
			return String.IsNullOrEmpty(s);
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="byteArray"></param>
		/// <param name="encoding"></param>
		/// <returns></returns>
		public static string ToString(this byte[] byteArray, Encoding encoding)
		{
			return encoding.GetString(byteArray, 0, byteArray.Length);
		}

		/// <summary>
		/// Convert byte array to string (to target encoding from source encoding)
		/// </summary>
		/// <param name="byteArray"></param>
		/// <param name="sourceEncoding"></param>
		/// <param name="targetEncoding"></param>
		/// <returns></returns>
		public static string ToString(this byte[] byteArray, Encoding sourceEncoding, Encoding targetEncoding)
		{	
			byte[] convertedBytes = Encoding.Convert(sourceEncoding, targetEncoding, byteArray);
			return targetEncoding.GetString(convertedBytes);
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="s"></param>
		/// <param name="encoding"></param>
		/// <returns></returns>
		public static byte[] ToArray(this string s, Encoding encoding)
		{
			return encoding.GetBytes(s);
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="s"></param>
		/// <returns></returns>
		public static string ConvertToSafeForSQL(this string s)
		{
			if (String.IsNullOrEmpty(s))
			{
				return s;
			}

			return s.Replace("'", "''");
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="s"></param>
		/// <returns></returns>
		public static string ConvertUnicodeToUtf8(this string s)
		{
			if (String.IsNullOrEmpty(s))
			{
				return s;
			}

			return Encoding.UTF8.GetString(Encoding.Convert(Encoding.Unicode, Encoding.UTF8, Encoding.Unicode.GetBytes(s)));
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="s"></param>
		/// <returns></returns>
		public static string ConvertUtf8ToUnicode(this string s)
		{
			if (String.IsNullOrEmpty(s))
			{
				return s;
			}

			return Encoding.Unicode.GetString(Encoding.Convert(Encoding.UTF8, Encoding.Unicode, Encoding.UTF8.GetBytes(s)));
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="s"></param>
		/// <param name="sourceEncoding"></param>
		/// <param name="destinationEncoding"></param>
		/// <returns></returns>
		public static string ConvertSrcEncodingToDstEncoding(this string s, Encoding sourceEncoding, Encoding destinationEncoding)
		{
			return destinationEncoding.GetString(Encoding.Convert(sourceEncoding, destinationEncoding, destinationEncoding.GetBytes(s)));
		}
	}
}
