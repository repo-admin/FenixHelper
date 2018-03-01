using System;
using System.Diagnostics;
using System.Reflection;

namespace FenixHelper
{
	/// <summary>
	/// Pomocná třída pro logování
	/// </summary>
    public class AppLog
    {
		/// <summary>
		/// Kategorie logu do databáze - informace
		/// </summary>
		public const string LOG_CATEGORY_INFO = "INFO";

		/// <summary>
		/// Kategorie logu do databáze - varování
		/// </summary>
		public const string LOG_CATEGORY_WARNING = "WARNING";

		/// <summary>
		/// Kategorie logu do databáze - chyba
		/// </summary>
		public const string LOG_CATEGORY_ERROR = "ERROR";

		/// <summary>
		/// Kategorie logu do databáze - XML
		/// </summary>
		public const string LOG_CATEGORY_XML = "XML";

		/// <summary>
		/// Vrací jméno metody
		/// <para>ve formátu: AssemblyName.ClassName.MethodName</para>
		/// </summary>
		/// <returns>jméno metody (AssemblyName.ClassName.MethodName)</returns>
		public static string GetMethodName()
		{
			StackTrace stackTrace = new System.Diagnostics.StackTrace();
			StackFrame frame = stackTrace.GetFrames()[1];
			MethodBase methodBase = frame.GetMethod();

			return String.Format("{0}.{1}.{2}", Assembly.GetCallingAssembly().GetName().Name, methodBase.DeclaringType.Name, methodBase.Name);
		}
    }
}
