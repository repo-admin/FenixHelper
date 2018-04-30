using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;
using Fenix.Xml;

#region SQL tabulka

/*
  
CREATE TABLE [dbo].[cdlMeasures](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Code] [varchar](50) NOT NULL,
	[DescriptionCz] [nvarchar](250) NOT NULL,
	[DescriptionEng] [nvarchar](250) NOT NULL,
	[IsSent] [bit] NULL,
	[SentDate] [datetime] NULL,
	[IsActive] [bit] NOT NULL CONSTRAINT [DF_cdlMeasures_IsActive]  DEFAULT ((1)),
	[ModifyDate] [datetime] NOT NULL CONSTRAINT [DF_cdlMeasures_ModifyDate]  DEFAULT (getdate()),
	[ModifyUserId] [int] NOT NULL CONSTRAINT [DF_cdlMeasures_ModifyUserId]  DEFAULT ((0)),
 CONSTRAINT [PK_Measures] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, FILLFACTOR = 85) ON [PRIMARY]
) ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'kód stejný pro všechny jazyky' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'cdlMeasures', @level2type=N'COLUMN',@level2name=N'Code'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Popis česky' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'cdlMeasures', @level2type=N'COLUMN',@level2name=N'DescriptionCz'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Popis anglicky' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'cdlMeasures', @level2type=N'COLUMN',@level2name=N'DescriptionEng'
GO
 
 */

#endregion

namespace Fenix.XmlMessages
{
    /// <summary>
    /// Třída představující xml message pro : číselník cdlMeasures
    /// </summary>
    /// <remarks>
    /// <code>
    /// CREATE TABLE [dbo].[cdlMeasures] (
    /// 	[ID] [int] IDENTITY(1, 1) NOT NULL
    /// 	,[Code] [varchar](50) NOT NULL
    /// 	,[DescriptionCz] [nvarchar](250) NOT NULL
    /// 	,[DescriptionEng] [nvarchar](250) NOT NULL
    /// 	,[IsSent] [bit] NULL
    /// 	,[SentDate] [datetime] NULL
    /// 	,[IsActive] [bit] NOT NULL CONSTRAINT [DF_cdlMeasures_IsActive] DEFAULT((1))
    /// 	,[ModifyDate] [datetime] NOT NULL CONSTRAINT [DF_cdlMeasures_ModifyDate] DEFAULT(getdate())
    /// 	,[ModifyUserId] [int] NOT NULL CONSTRAINT [DF_cdlMeasures_ModifyUserId] DEFAULT((0))
    /// 	,CONSTRAINT [PK_Measures] PRIMARY KEY CLUSTERED ([ID] ASC) WITH (
    /// 		PAD_INDEX = OFF
    /// 		,STATISTICS_NORECOMPUTE = OFF
    /// 		,IGNORE_DUP_KEY = OFF
    /// 		,ALLOW_ROW_LOCKS = ON
    /// 		,ALLOW_PAGE_LOCKS = ON
    /// 		,FILLFACTOR = 85
    /// 		) ON [PRIMARY]
    /// 	) ON [PRIMARY]
    /// GO
    /// 
    /// SET ANSI_PADDING OFF
    /// GO
    /// 
    /// EXEC sys.sp_addextendedproperty @name = N'MS_Description'
    /// 	,@value = N'kód stejný pro všechny jazyky'
    /// 	,@level0type = N'SCHEMA'
    /// 	,@level0name = N'dbo'
    /// 	,@level1type = N'TABLE'
    /// 	,@level1name = N'cdlMeasures'
    /// 	,@level2type = N'COLUMN'
    /// 	,@level2name = N'Code'
    /// GO
    /// 
    /// EXEC sys.sp_addextendedproperty @name = N'MS_Description'
    /// 	,@value = N'Popis česky'
    /// 	,@level0type = N'SCHEMA'
    /// 	,@level0name = N'dbo'
    /// 	,@level1type = N'TABLE'
    /// 	,@level1name = N'cdlMeasures'
    /// 	,@level2type = N'COLUMN'
    /// 	,@level2name = N'DescriptionCz'
    /// GO
    /// 
    /// EXEC sys.sp_addextendedproperty @name = N'MS_Description'
    /// 	,@value = N'Popis anglicky'
    /// 	,@level0type = N'SCHEMA'
    /// 	,@level0name = N'dbo'
    /// 	,@level1type = N'TABLE'
    /// 	,@level1name = N'cdlMeasures'
    /// 	,@level2type = N'COLUMN'
    /// 	,@level2name = N'DescriptionEng'
    /// GO
    /// </code>
    /// </remarks>
    [XmlRoot("NewDataSet")]
	public class CDLMeasures : IXMLMessage
	{
		#region Properties

		/// <summary>
		/// 
		/// </summary>
		[XmlElement(ElementName = "MeasureIntegration")]
		public CDLMeasuresMeasureIntegration MeasureIntegration { get; set; }

		#endregion

		#region Contructors

		/// <summary>
		/// 
		/// </summary>
		public CDLMeasures()
		{
			this.MeasureIntegration = new CDLMeasuresMeasureIntegration();
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
}
