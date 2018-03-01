using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using FenixHelper;
using FenixHelper.Validation;

#region SQL tabulka

/*

CREATE TABLE [dbo].[cdlQualities](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Code] [nvarchar](50) NOT NULL,
	[DescriptionCz] [nvarchar](50) NOT NULL,
	[DescriptionEng] [nvarchar](50) NOT NULL,
 
	[IsSent] [bit] NULL,
	[SentDate] [datetime] NULL,
	[IsActive] [bit] NOT NULL CONSTRAINT [DF_cdlQualities_IsActive]  DEFAULT ((1)),
	[ModifyDate] [datetime] NOT NULL CONSTRAINT [DF_cdlQualities_ModifyDate]  DEFAULT (getdate()),
	[ModifyUserId] [int] NOT NULL CONSTRAINT [DF_cdlQualities_ModifyUserId]  DEFAULT ((0)),
 CONSTRAINT [PK_Qualities] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, FILLFACTOR = 85) ON [PRIMARY]
) ON [PRIMARY]

GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'kód stejný pro všechny jazyky' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'cdlQualities', @level2type=N'COLUMN',@level2name=N'Code'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Popis česky' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'cdlQualities', @level2type=N'COLUMN',@level2name=N'DescriptionCz'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Popis anglicky' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'cdlQualities', @level2type=N'COLUMN',@level2name=N'DescriptionEng'
GO
 
 */

#endregion

namespace FenixHelper.XMLMessage
{
	/// <summary>
	/// Třída představující XML message pro : číselník cdlQualities
	/// </summary>
	[XmlRoot("NewDataSet")]
	public class CDLQualities : IXMLMessage
	{
		#region Properties

		/// <summary>
		/// 
		/// </summary>
		[XmlElement(ElementName = "QualityIntegration")]
		public CDLQualitiesQualityIntegration QualityIntegration { get; set; }

		#endregion

		#region Contructors

		/// <summary>
		/// 
		/// </summary>
		public CDLQualities()
		{
			this.QualityIntegration = new CDLQualitiesQualityIntegration();
		}

		#endregion

		/// <summary>
		/// 
		/// </summary>
		/// <returns></returns>
		public string ToXMLString()
		{
			return XmlCreator.CreateXmlString(this, BC.URL_W3_ORG_SCHEMA, Encoding.UTF8);
		}

		/// <summary>
		/// 
		/// </summary>
		/// <returns></returns>
		public List<string> Validate()
		{			
			return this.QualityIntegration.Validate(this.QualityIntegration);
		}
	}

	/// <summary>
	/// 
	/// </summary>
	public class CDLQualitiesQualityIntegration
	{
		/// <summary>
		/// 
		/// </summary>
		[IntMinMaxAttribute(Min = 1)]
		public int ID { get; set; }

		/// <summary>
		/// 
		/// </summary>
		[IntMinMaxAttribute(Min = 1)]
		public int MessageID { get; set; }

		/// <summary>
		/// 
		/// </summary>
		[IntMinMaxAttribute(Min = 1)]
		public int MessageTypeID { get; set; }

		/// <summary>
		/// 
		/// </summary>
		[NotNullOrEmptyAttribute]
		public string MessageDescription { get; set; }

		/// <summary>
		/// 
		/// </summary>
		[NotNullOrEmptyAttribute]
		public string Code { get; set; }

		/// <summary>
		/// 
		/// </summary>
		[NotNullOrEmptyAttribute]
		public string DescriptionCz { get; set; }

		/// <summary>
		/// 
		/// </summary>
		[NotNullOrEmptyAttribute]
		public string DescriptionEng { get; set; }

		/// <summary>
		/// 
		/// </summary>
		/// <returns></returns>
		public List<string> Validate(CDLQualitiesQualityIntegration data)
		{
			List<string> errors;
			Validation.Validation.ValidateAllProperties<CDLQualitiesQualityIntegration>(data, out errors);

			return errors;
		}
	}
}
