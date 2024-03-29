﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;
using Fenix.Xml;

#region SQL tabulka

/*

CREATE TABLE [dbo].[cdlReturnValues](
	[ID] [int] NOT NULL,
	[DescriptionCz] [nvarchar](150) NOT NULL,
	[DescriptionEng] [nvarchar](150) NOT NULL,
	[IsSent] [bit] NULL,
	[SentDate] [datetime] NULL,
	[IsActive] [bit] NOT NULL,
	[ModifyDate] [datetime] NOT NULL,
	[ModifyUserId] [int] NOT NULL,
 CONSTRAINT [PK_cdlReturnValues] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, FILLFACTOR = 85) ON [PRIMARY]
) ON [PRIMARY]

GO
 
 */

#endregion

namespace Fenix.XmlMessages
{
    /// <summary>
    /// Třída představující XML message pro : číselník cdlReturnValues
    /// </summary>
    /// <remarks>
    /// <code>
    /// CREATE TABLE [dbo].[cdlReturnValues] (
    /// 	[ID] [int] NOT NULL
    /// 	,[DescriptionCz] [nvarchar](150) NOT NULL
    /// 	,[DescriptionEng] [nvarchar](150) NOT NULL
    /// 	,[IsSent] [bit] NULL
    /// 	,[SentDate] [datetime] NULL
    /// 	,[IsActive] [bit] NOT NULL
    /// 	,[ModifyDate] [datetime] NOT NULL
    /// 	,[ModifyUserId] [int] NOT NULL
    /// 	,CONSTRAINT [PK_cdlReturnValues] PRIMARY KEY CLUSTERED ([ID] ASC) WITH (
    /// 		PAD_INDEX = OFF
    /// 		,STATISTICS_NORECOMPUTE = OFF
    /// 		,IGNORE_DUP_KEY = OFF
    /// 		,ALLOW_ROW_LOCKS = ON
    /// 		,ALLOW_PAGE_LOCKS = ON
    /// 		,FILLFACTOR = 85
    /// 		) ON [PRIMARY]
    /// 	) ON [PRIMARY]
    /// GO
    /// </code>
    /// </remarks>
    [XmlRoot("NewDataSet")]
	public class CDLReturnValues : IXMLMessage
	{
		#region Properties

		/// <summary>
		/// 
		/// </summary>
		[XmlElement(ElementName = "ReturnValueIntegration")]
		public CDLReturnValuesReturnValueIntegration ReturnValueIntegration { get; set; }

		#endregion

		#region Contructors

		/// <summary>
		/// 
		/// </summary>
		public CDLReturnValues()
		{
			this.ReturnValueIntegration = new CDLReturnValuesReturnValueIntegration();
		}

		#endregion

		/// <summary>
		/// 
		/// </summary>
		/// <returns></returns>
		public string ToXMLString()
		{
			return XmlCreator.CreateXmlString(this, BC.UrlW3OrgSchema, Encoding.UTF8);
		}

		/// <summary>
		/// 
		/// </summary>
		/// <returns></returns>
		public List<string> Validate()
		{
			throw new NotImplementedException();
		}
	}

	/// <summary>
	/// 
	/// </summary>
	public class CDLReturnValuesReturnValueIntegration
	{
		/// <summary>
		/// 
		/// </summary>
		public int ID { get; set; }

		/// <summary>
		/// 
		/// </summary>
		public int MessageID { get; set; }

		/// <summary>
		/// 
		/// </summary>
		public int MessageTypeID { get; set; }

		/// <summary>
		/// 
		/// </summary>
		public string MessageDescription { get; set; }

		/// <summary>
		/// 
		/// </summary>
		public string DescriptionCz { get; set; }

		/// <summary>
		/// 
		/// </summary>
		public string DescriptionEng { get; set; }
	}
}
