using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FenixHelper.Common
{
	/// <summary>
	/// 
	/// </summary>
	public class ResultAppService
	{
		/// <summary>
		/// 
		/// </summary>
		public int ResultNumber { get; set; }

		/// <summary>
		/// 
		/// </summary>
		public string ResultMessage { get; set; }

		/// <summary>
		/// ctor
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
		/// přidá zprávu do result message
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
		/// nastaví result number a přidá zprávu do result message
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
