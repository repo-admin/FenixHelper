using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;
using Fenix.Validation;
using Fenix.Xml;

#region SQL tabulka

/*

CREATE TABLE [dbo].[cdlSuppliers](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[OrganisationNumber] [int] NOT NULL,
	[CompanyName] [nvarchar](100) NOT NULL,
	[City] [nvarchar](100) NOT NULL,
	[StreetName] [nvarchar](100) NOT NULL,
	[StreetOrientationNumber] [nvarchar](15) NULL,
	[StreetHouseNumber] [nvarchar](15) NULL,
	[ZipCode] [nvarchar](10) NULL,
	[IdCountry] [nvarchar](3) NULL,
	[ICO] [nvarchar](20) NULL,
	[DIC] [nvarchar](15) NULL,
	[IsSent] [bit] NULL,
	[SentDate] [datetime] NULL,
	[IsActive] [bit] NOT NULL CONSTRAINT [DF_cdlSuppliers_IsActive]  DEFAULT ((1)),
	[ModifyDate] [datetime] NOT NULL CONSTRAINT [DF_cdlSuppliers_ModifyDate]  DEFAULT (getdate()),
	[ModifyUserId] [int] NOT NULL CONSTRAINT [DF_cdlSuppliers_ModifyUserId]  DEFAULT ((0)),
 CONSTRAINT [PK_Suppliers] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'číslo organizace' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'cdlSuppliers', @level2type=N'COLUMN',@level2name=N'OrganisationNumber'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'číslo orientační' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'cdlSuppliers', @level2type=N'COLUMN',@level2name=N'StreetOrientationNumber'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'číslo popisné' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'cdlSuppliers', @level2type=N'COLUMN',@level2name=N'StreetHouseNumber'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'ID země' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'cdlSuppliers', @level2type=N'COLUMN',@level2name=N'IdCountry'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'indikátor, zda bylo odesláno na ND' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'cdlSuppliers', @level2type=N'COLUMN',@level2name=N'IsSent'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Kdy bylo posláno na ND' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'cdlSuppliers', @level2type=N'COLUMN',@level2name=N'SentDate'
GO

 
 */

#endregion

namespace Fenix.XmlMessages
{
    /// <summary>
    /// Třída představující XML message pro : číselník cdlSuppliers
    /// </summary>
    /// <remarks>
    /// <code>
    /// CREATE TABLE [dbo].[cdlSuppliers] (
    /// 	[ID] [int] IDENTITY(1, 1) NOT NULL
    /// 	,[OrganisationNumber] [int] NOT NULL
    /// 	,[CompanyName] [nvarchar](100) NOT NULL
    /// 	,[City] [nvarchar](100) NOT NULL
    /// 	,[StreetName] [nvarchar](100) NOT NULL
    /// 	,[StreetOrientationNumber] [nvarchar](15) NULL
    /// 	,[StreetHouseNumber] [nvarchar](15) NULL
    /// 	,[ZipCode] [nvarchar](10) NULL
    /// 	,[IdCountry] [nvarchar](3) NULL
    /// 	,[ICO] [nvarchar](20) NULL
    /// 	,[DIC] [nvarchar](15) NULL
    /// 	,[IsSent] [bit] NULL
    /// 	,[SentDate] [datetime] NULL
    /// 	,[IsActive] [bit] NOT NULL CONSTRAINT [DF_cdlSuppliers_IsActive] DEFAULT((1))
    /// 	,[ModifyDate] [datetime] NOT NULL CONSTRAINT [DF_cdlSuppliers_ModifyDate] DEFAULT(getdate())
    /// 	,[ModifyUserId] [int] NOT NULL CONSTRAINT [DF_cdlSuppliers_ModifyUserId] DEFAULT((0))
    /// 	,CONSTRAINT [PK_Suppliers] PRIMARY KEY CLUSTERED ([ID] ASC) WITH (
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
    /// 	,@value = N'číslo organizace'
    /// 	,@level0type = N'SCHEMA'
    /// 	,@level0name = N'dbo'
    /// 	,@level1type = N'TABLE'
    /// 	,@level1name = N'cdlSuppliers'
    /// 	,@level2type = N'COLUMN'
    /// 	,@level2name = N'OrganisationNumber'
    /// GO
    /// 
    /// EXEC sys.sp_addextendedproperty @name = N'MS_Description'
    /// 	,@value = N'číslo orientační'
    /// 	,@level0type = N'SCHEMA'
    /// 	,@level0name = N'dbo'
    /// 	,@level1type = N'TABLE'
    /// 	,@level1name = N'cdlSuppliers'
    /// 	,@level2type = N'COLUMN'
    /// 	,@level2name = N'StreetOrientationNumber'
    /// GO
    /// 
    /// EXEC sys.sp_addextendedproperty @name = N'MS_Description'
    /// 	,@value = N'číslo popisné'
    /// 	,@level0type = N'SCHEMA'
    /// 	,@level0name = N'dbo'
    /// 	,@level1type = N'TABLE'
    /// 	,@level1name = N'cdlSuppliers'
    /// 	,@level2type = N'COLUMN'
    /// 	,@level2name = N'StreetHouseNumber'
    /// GO
    /// 
    /// EXEC sys.sp_addextendedproperty @name = N'MS_Description'
    /// 	,@value = N'ID země'
    /// 	,@level0type = N'SCHEMA'
    /// 	,@level0name = N'dbo'
    /// 	,@level1type = N'TABLE'
    /// 	,@level1name = N'cdlSuppliers'
    /// 	,@level2type = N'COLUMN'
    /// 	,@level2name = N'IdCountry'
    /// GO
    /// 
    /// EXEC sys.sp_addextendedproperty @name = N'MS_Description'
    /// 	,@value = N'indikátor, zda bylo odesláno na ND'
    /// 	,@level0type = N'SCHEMA'
    /// 	,@level0name = N'dbo'
    /// 	,@level1type = N'TABLE'
    /// 	,@level1name = N'cdlSuppliers'
    /// 	,@level2type = N'COLUMN'
    /// 	,@level2name = N'IsSent'
    /// GO
    /// 
    /// EXEC sys.sp_addextendedproperty @name = N'MS_Description'
    /// 	,@value = N'Kdy bylo posláno na ND'
    /// 	,@level0type = N'SCHEMA'
    /// 	,@level0name = N'dbo'
    /// 	,@level1type = N'TABLE'
    /// 	,@level1name = N'cdlSuppliers'
    /// 	,@level2type = N'COLUMN'
    /// 	,@level2name = N'SentDate'
    /// GO
    /// </code>
    /// </remarks>
    [XmlRoot("NewDataSet")]
	public class CDLSuppliers : IXMLMessage
	{
		#region Properties

		/// <summary>
		/// 
		/// </summary>
		[XmlElement(ElementName = "SupplierIntegration")]
		public CDLSuppliersIntegration SupplierIntegration { get; set; }

		#endregion

		#region Contructors

		/// <summary>
		/// 
		/// </summary>
		public CDLSuppliers()
		{
			this.SupplierIntegration = new CDLSuppliersIntegration();
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
			return this.SupplierIntegration.Validate(this.SupplierIntegration);
		}
	}

	/// <summary>
	/// 
	/// </summary>
	public class CDLSuppliersIntegration
	{
		/// <summary>
		/// 
		/// </summary>
		[IntMinMax(Min = 1)]
		public int ID { get; set; }

		/// <summary>
		/// 
		/// </summary>
		[IntMinMax(Min = 1)]
		public int MessageID { get; set; }

		/// <summary>
		/// 
		/// </summary>
		[IntMinMax(Min = 1)]
		public int MessageTypeID { get; set; }

		/// <summary>
		/// 
		/// </summary>
		[NotNullOrEmpty]
		public string MessageDescription { get; set; }

		/// <summary>
		/// 
		/// </summary>
		[NotNullOrEmpty]
		public string OrganisationNumber { get; set; }

		/// <summary>
		/// 
		/// </summary>
		[NotNullOrEmpty]
		public string CompanyName { get; set; }

		/// <summary>
		/// 
		/// </summary>
		[NotNullOrEmpty]
		public string City { get; set; }

		/// <summary>
		/// 
		/// </summary>
		[NotNullOrEmpty]
		public string StreetName { get; set; }

		/// <summary>
		/// 
		/// </summary>
		public string StreetOrientationNumber { get; set; }

		/// <summary>
		/// 
		/// </summary>
		public string StreetHouseNumber { get; set; }
		
		/// <summary>
		/// 
		/// </summary>
		public string  ZipCode { get; set; }

		/// <summary>
		/// 
		/// </summary>
		public string IdCountry { get; set; }

		/// <summary>
		/// 
		/// </summary>
		public string ICO { get; set; }

		/// <summary>
		/// 
		/// </summary>
		public string DIC { get; set; }
		
		/// <summary>
		/// 
		/// </summary>
		/// <returns></returns>
		public List<string> Validate(CDLSuppliersIntegration data)
		{
			List<string> errors;
			Validation.Validation.ValidateAllProperties<CDLSuppliersIntegration>(data, out errors);

			return errors;
		}
	}
}
