USE [FootBall]
GO

/****** Object:  Table [dbo].[PersonTitle]    Script Date: 03/02/2018 3:32:09 PM ******/
SET ANSI_NULLS ON
GO


SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[PersonTitle](
	[ID_Person] [int] NOT NULL,
	[ID_Title] [int] NOT NULL,
	[ID_Team] [int] NULL,
 CONSTRAINT [PK_PersonTitle] PRIMARY KEY CLUSTERED 
(
	[ID_Person] ASC,
	[ID_Title] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[PersonTitle]  WITH CHECK ADD  CONSTRAINT [FK_PersonTitle_Person] FOREIGN KEY([ID_Person])
REFERENCES [dbo].[Person] ([ID_Person])
GO

ALTER TABLE [dbo].[PersonTitle] CHECK CONSTRAINT [FK_PersonTitle_Person]
GO

ALTER TABLE [dbo].[PersonTitle]  WITH CHECK ADD  CONSTRAINT [FK_PersonTitle_Team] FOREIGN KEY([ID_Team])
REFERENCES [dbo].[Team] ([ID_Team])
GO

ALTER TABLE [dbo].[PersonTitle] CHECK CONSTRAINT [FK_PersonTitle_Team]
GO

ALTER TABLE [dbo].[PersonTitle]  WITH CHECK ADD  CONSTRAINT [FK_PersonTitle_Title] FOREIGN KEY([ID_Title])
REFERENCES [dbo].[Title] ([ID_Title])
GO

ALTER TABLE [dbo].[PersonTitle] CHECK CONSTRAINT [FK_PersonTitle_Title]
GO


