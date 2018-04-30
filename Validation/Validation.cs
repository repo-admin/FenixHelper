using System;
using System.Collections.Generic;
using System.Reflection;

namespace Fenix.Validation
{
	/// <summary>
	/// Statická třída se sadou validačních generických metod
	/// </summary>
	public static class Validation
	{
		/// <summary>
		/// Metoda, která validuje vlastnost třídy
		/// </summary>
		/// <typeparam name="T"></typeparam>
		/// <param name="classToValidate">trida obsahujici kontrolovanou property</param>
		/// <param name="propertyName">jmeno kontrolovane property</param>
		/// <param name="error">null/popis chyby validace</param>
		/// <returns></returns>
		public static bool ValidateProperty<T>(T classToValidate, string propertyName, out List<string> error)
		{
			error = new List<string>();

			return PropertyIsValid(classToValidate, classToValidate.GetType().GetProperty(propertyName, BindingFlags.DeclaredOnly | BindingFlags.Public | BindingFlags.FlattenHierarchy | BindingFlags.Instance), out error);
		}

		/// <summary>
		/// Validace vsech properties dane tridy
		/// </summary>
		/// <typeparam name="T"></typeparam>
		/// <param name="classToValidate">kontrolovana trida</param>
		/// <param name="error">null/popis chyby validace</param>
		/// <returns></returns>
		public static bool ValidateAllProperties<T>(T classToValidate, out List<string> error)
		{
			error = new List<string>();
			
			foreach (PropertyInfo pi in (classToValidate.GetType().GetProperties()))
			{
				List<string> propertyError;
				if (!PropertyIsValid(classToValidate, pi, out propertyError))
				{
					error.AddRange(propertyError);					
				}
			}

			return (error.Count == 0);
		}

		/// <summary>
		/// Vlastni validace property dle jejiho atributu
		/// </summary>
		/// <typeparam name="T"></typeparam>
		/// <param name="classToValidate">trida obsahujici kontrolovanou property</param>
		/// <param name="pi">property info kontrolovane property</param>
		/// <param name="error">null/popis chyby validace</param>
		/// <returns></returns>
		private static bool PropertyIsValid<T>(T classToValidate, PropertyInfo pi, out List<string> error)
		{
			error = new List<string>();

			CheckNotNullOrEmptyAttribute<T>(classToValidate, pi, error);
			CheckIntMinMaxAttribute<T>(classToValidate, pi, error);
			CheckDoubleMinMaxAttribute<T>(classToValidate, pi, error);

			return (error.Count == 0);
		}

        /// <summary>
        /// Validace vlastnosti s návratovou hodnotou typu <see cref="Int32"/>
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="classToValidate">trida obsahujici kontrolovanou property</param>
        /// <param name="pi">property info kontrolovane property</param>
        /// <param name="error">null/popis chyby validace</param>
		private static void CheckIntMinMaxAttribute<T>(T classToValidate, PropertyInfo pi, List<string> error)
		{
			IntMinMaxAttribute intMinMaxAttribute = (IntMinMaxAttribute)Attribute.GetCustomAttribute(pi, typeof(IntMinMaxAttribute));

			if (intMinMaxAttribute != null)
			{
				Object propertyValue = pi.GetValue(classToValidate, null);
				Type propertyType = pi.PropertyType;

				if ((int)propertyValue < intMinMaxAttribute.Min)
				{
					error.Add(String.Format("Property [{0}] is less than [{1}]", pi.Name, intMinMaxAttribute.Min));
				}

				if ((int)propertyValue > intMinMaxAttribute.Max)
				{
					error.Add(String.Format("Property [{0}] is greater than [{1}]", pi.Name, intMinMaxAttribute.Max));
				}
			}
		}

	    /// <summary>
	    /// Validace vlastnosti s návratovou hodnotou typu <see cref="Double"/>
	    /// </summary>
	    /// <typeparam name="T"></typeparam>
	    /// <param name="classToValidate">trida obsahujici kontrolovanou property</param>
	    /// <param name="pi">property info kontrolovane property</param>
	    /// <param name="error">null/popis chyby validace</param>
        private static void CheckDoubleMinMaxAttribute<T>(T classToValidate, PropertyInfo pi, List<string> error)
		{
			DoubleMinMaxAttribute doubleMinMaxAttribute = (DoubleMinMaxAttribute)Attribute.GetCustomAttribute(pi, typeof(DoubleMinMaxAttribute));

			if (doubleMinMaxAttribute != null)
			{
				Object propertyValue = pi.GetValue(classToValidate, null);
				Type propertyType = pi.PropertyType;

				if (propertyType.Name.ToUpper() == "DECIMAL")
				{
					decimal decimalMin = doubleMinMaxAttribute.Min < (double)decimal.MinValue ? decimal.MinValue : (decimal)doubleMinMaxAttribute.Min;
					decimal decimalMax = doubleMinMaxAttribute.Max > (double)decimal.MaxValue ? decimal.MaxValue : (decimal)doubleMinMaxAttribute.Max;
					if ((decimal)propertyValue < decimalMin)
					{
						error.Add(String.Format("Property [{0}] is less than [{1}]", pi.Name, doubleMinMaxAttribute.Min));
					}
					if ((decimal)propertyValue > decimalMax)
					{
						error.Add(String.Format("Property [{0}] is greater than [{1}]", pi.Name, doubleMinMaxAttribute.Max));
					}
				}
				else
				{
					if ((double)propertyValue < doubleMinMaxAttribute.Min)
					{
						error.Add(String.Format("Property [{0}] is less than [{1}]", pi.Name, doubleMinMaxAttribute.Min));
					}
					if ((double)propertyValue > doubleMinMaxAttribute.Max)
					{
						error.Add(String.Format("Property [{0}] is greater than [{1}]", pi.Name, doubleMinMaxAttribute.Max));
					}
				}
			}
		}

	    /// <summary>
	    /// Validace vlastnosti s návratovou hodnotou typu <see cref="String"/>, která nesmí být null ani prázdný řetězec
	    /// </summary>
	    /// <typeparam name="T"></typeparam>
	    /// <param name="classToValidate">trida obsahujici kontrolovanou property</param>
	    /// <param name="pi">property info kontrolovane property</param>
	    /// <param name="error">null/popis chyby validace</param>
        private static void CheckNotNullOrEmptyAttribute<T>(T classToValidate, PropertyInfo pi, List<string> error)
		{
			NotNullOrEmptyAttribute notNullAttribute = (NotNullOrEmptyAttribute)Attribute.GetCustomAttribute(pi, typeof(NotNullOrEmptyAttribute));

			if (notNullAttribute != null)
			{
				Object propertyValue = pi.GetValue(classToValidate, null);
				Type propertyType = pi.PropertyType;

				if (propertyType.Name.ToUpper() == "STRING")
				{
					if (propertyValue == null || (string)propertyValue == String.Empty)
					{
						error.Add(String.Format("Property [{0}] is null/empty", pi.Name));
					}
				}
				else
				{
					if (propertyValue == null)
					{
						error.Add(String.Format("Property [{0}] is null", pi.Name));
					}
				}
			}
		}
	}
}
