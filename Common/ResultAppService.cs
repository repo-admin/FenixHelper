using System;

namespace Fenix.Common
{
	/// <summary>
	/// Výsledek
	/// </summary>
	public class ResultAppService
	{
		/// <summary>
		/// Číslo výsledku
		/// </summary>
		public int ResultNumber { get; set; }

		/// <summary>
		/// Zpráva výsledku
		/// </summary>
		public string ResultMessage { get; set; }

        /// <summary>
        /// Inicializuje novou instanci třídy ResultAppService
        /// </summary>
        public ResultAppService()
		{
			this.ResultNumber = 0;
			this.ResultMessage = String.Empty;
		}

		/// <summary>
		/// ctor
		/// </summary>
		/// <param name="resultNumber"></param>
		/// <param name="resultMessage"></param>
		public ResultAppService(int resultNumber, string resultMessage)
		{
			this.ResultNumber = resultNumber;
			this.ResultMessage = resultMessage;
		}

		/// <summary>
		/// Přidá zprávu do result message
		/// </summary>
		/// <param name="resultMessage"></param>
		public void AddResultMessage(string resultMessage)
		{ 			
			if (!String.IsNullOrEmpty(resultMessage))
			{
				this.ResultMessage += !String.IsNullOrEmpty(this.ResultMessage) ? Environment.NewLine : String.Empty;
				this.ResultMessage += String.Format("{0}{1}{2}", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff"), Environment.NewLine, resultMessage);
			}		
		}

		/// <summary>
		/// Nastaví result number a přidá zprávu do result message
		/// </summary>
		/// <param name="resultNumber"></param>
		/// <param name="resultMessage"></param>
		public void AddResultMessage(int resultNumber, string resultMessage)
		{
			this.ResultNumber = resultNumber;
			AddResultMessage(resultMessage);
		}
	}	
}
