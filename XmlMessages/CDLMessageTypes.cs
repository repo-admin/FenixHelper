using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;
using Fenix.Xml;

#region SQL tabulka

/*

CREATE TABLE [dbo].[cdlMessageTypes](
	[ID] [int] NOT NULL,
	[DescriptionCz] [nvarchar](50) NOT NULL,
	[DescriptionEng] [nvarchar](50) NOT NULL,
	[IsSent] [bit] NULL,
	[SentDate] [datetime] NULL,
	[IsActive] [bit] NOT NULL CONSTRAINT [DF_cdlMessageTypes_IsActive]  DEFAULT ((1)),
	[ModifyDate] [datetime] NOT NULL CONSTRAINT [DF_cdlMessageTypes_ModifyDate]  DEFAULT (getdate()),
	[ModifyUserId] [int] NOT NULL CONSTRAINT [DF_cdlMessageTypes_ModifyUserId]  DEFAULT ((0)),
 CONSTRAINT [PK_MessageTypes] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Popis česky' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'cdlMessageTypes', @level2type=N'COLUMN',@level2name=N'DescriptionCz'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Popis anglicky' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'cdlMessageTypes', @level2type=N'COLUMN',@level2name=N'DescriptionEng'
GO
 
 */

#endregion

namespace Fenix.XmlMessages
{
    /// <summary>
    /// Třída představující xml message pro : číselník cdlMessageTypes
    /// </summary>
    /// <remarks>
    /// <code>
    /// CREATE TABLE [dbo].[cdlMessageTypes] (
    /// 	[ID] [int] NOT NULL
    /// 	,[DescriptionCz] [nvarchar](50) NOT NULL
    /// 	,[DescriptionEng] [nvarchar](50) NOT NULL
    /// 	,[IsSent] [bit] NULL
    /// 	,[SentDate] [datetime] NULL
    /// 	,[IsActive] [bit] NOT NULL CONSTRAINT [DF_cdlMessageTypes_IsActive] DEFAULT((1))
    /// 	,[ModifyDate] [datetime] NOT NULL CONSTRAINT [DF_cdlMessageTypes_ModifyDate] DEFAULT(getdate())
    /// 	,[ModifyUserId] [int] NOT NULL CONSTRAINT [DF_cdlMessageTypes_ModifyUserId] DEFAULT((0))
    /// 	,CONSTRAINT [PK_MessageTypes] PRIMARY KEY CLUSTERED ([ID] ASC) WITH (
    /// 		PAD_INDEX = OFF
    /// 		,STATISTICS_NORECOMPUTE = OFF
    /// 		,IGNORE_DUP_KEY = OFF
    /// 		,ALLOW_ROW_LOCKS = ON
    /// 		,ALLOW_PAGE_LOCKS = ON
    /// 		) ON [PRIMARY]
    /// 	) ON [PRIMARY]
    /// GO
    /// 
    /// EXEC sys.sp_addextendedproperty @name = N'MS_Description'
    /// 	,@value = N'Popis česky'
    /// 	,@level0type = N'SCHEMA'
    /// 	,@level0name = N'dbo'
    /// 	,@level1type = N'TABLE'
    /// 	,@level1name = N'cdlMessageTypes'
    /// 	,@level2type = N'COLUMN'
    /// 	,@level2name = N'DescriptionCz'
    /// GO
    /// 
    /// EXEC sys.sp_addextendedproperty @name = N'MS_Description'
    /// 	,@value = N'Popis anglicky'
    /// 	,@level0type = N'SCHEMA'
    /// 	,@level0name = N'dbo'
    /// 	,@level1type = N'TABLE'
    /// 	,@level1name = N'cdlMessageTypes'
    /// 	,@level2type = N'COLUMN'
    /// 	,@level2name = N'DescriptionEng'
    /// GO
    /// </code>
    /// </remarks>
    [XmlRoot("NewDataSet")]
	public class CDLMessageTypes : IXMLMessage
	{
		#region Properties

		/// <summary>
		/// 
		/// </summary>
		[XmlElement(ElementName = "MessageTypeIntegration")]
		public CDLMessageTypesMessageTypeIntegration MessageTypeIntegration { get; set; }

		#endregion

		#region Contructors

		/// <summary>
		/// 
		/// </summary>
		public CDLMessageTypes()
		{
			this.MessageTypeIntegration = new CDLMessageTypesMessageTypeIntegration();
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
	public class CDLMessageTypesMessageTypeIntegration
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
