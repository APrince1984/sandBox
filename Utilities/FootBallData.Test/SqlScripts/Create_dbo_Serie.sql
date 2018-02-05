USE [FootBall]
GO

/****** Object:  Table [dbo].[Serie]    Script Date: 03/02/2018 3:33:16 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Serie](
	[ID_Serie] [int] IDENTITY(1,1) NOT NULL,
	[Description] [varchar](50) NOT NULL,
	[TeamsPromote] [int] NULL,
	[TeamsDegradate] [int] NULL,
	[ID_Competition] [int] NULL,
 CONSTRAINT [PK_Serie] PRIMARY KEY CLUSTERED 
(
	[ID_Serie] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[Serie]  WITH CHECK ADD  CONSTRAINT [FK_Serie_Competition] FOREIGN KEY([ID_Competition])
REFERENCES [dbo].[Competition] ([ID_Competition])
GO

ALTER TABLE [dbo].[Serie] CHECK CONSTRAINT [FK_Serie_Competition]
GO


