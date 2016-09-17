/* Melhoria para contemplar JCR */
CREATE TABLE [dbo].[JCR](
	[JCRId] [int] IDENTITY(1,1) NOT NULL,
	[Rank] [int] NOT NULL,
	[NomePeriodicoJCR] [varchar](300) NOT NULL,
	[NomeAbreviadoPeriodioJCR] [varchar](100) NOT NULL,
	[ISSNJCR] [char](8) NOT NULL,
	[NumeroCitacoesJCR] [int] NULL,
	[FatorImpactoJCR] [numeric](15, 4) NULL,
	[FatorImpactoSemCitacoesPropriasJCR] [numeric](15, 4) NULL,
	[FatorImpactoCincoAnosJCR] [numeric](15, 4) NULL,
	[IndiceInfluenciaJCR] [numeric](15, 4) NULL,
	[ItensCitaveisJCR] [int] NULL,
	[PontuacaoEigenfactorJCR] [numeric](15, 6) NULL,
	[PontuacaoInfluenciaArtigoJCR] [numeric](15, 4) NULL,
	[PercentualMedioJCR] [numeric](15, 4) NULL,
	[EigenfactorNormalizadoJCR] [numeric](15, 6) NULL,
 CONSTRAINT [PK_JCR] PRIMARY KEY CLUSTERED 
(
	[JCRId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE dbo.JCR SET (LOCK_ESCALATION = TABLE)
GO
COMMIT
BEGIN TRANSACTION
GO
ALTER TABLE dbo.ProducaoBibliografica ADD
	JCRId int NULL,
	NomePeriodicoProducaoBibliografica varchar(300) NULL
GO
ALTER TABLE dbo.ProducaoBibliografica ADD CONSTRAINT
	FK_ProducaoBibliografica_JCR FOREIGN KEY
	(
	JCRId
	) REFERENCES dbo.JCR
	(
	JCRId
	) ON UPDATE  NO ACTION 
	 ON DELETE  NO ACTION 
	
GO
ALTER TABLE dbo.ProducaoBibliografica SET (LOCK_ESCALATION = TABLE)
GO
