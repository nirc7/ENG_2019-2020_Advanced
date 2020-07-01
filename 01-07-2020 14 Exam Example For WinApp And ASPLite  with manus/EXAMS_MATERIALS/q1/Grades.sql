CREATE DATABASE Grades 


USE Grades 
GO


CREATE TABLE [dbo].[GradesTable](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NULL,
	[Course] [nvarchar](50) NULL,
	[Grade] [float] NULL
) ON [PRIMARY]
GO

