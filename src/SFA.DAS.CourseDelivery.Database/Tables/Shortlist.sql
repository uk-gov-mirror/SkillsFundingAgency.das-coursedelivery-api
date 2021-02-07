﻿CREATE TABLE [dbo].[Shortlist]
(
	[Id] UniqueIdentifier NOT NULL PRIMARY KEY, 
    [ShortlistUserId] UNIQUEIDENTIFIER NOT NULL, 
    [ProviderUkprn] INT NOT NULL, 
    [CourseId] INT NOT NULL, 
    [LocationDescription] VARCHAR(1000) NULL, 
    [Lat] FLOAT NULL, 
    [Long] FLOAT NULL, 
    [CreatedDate] DATETIME NOT NULL DEFAULT GETDATE()
)
