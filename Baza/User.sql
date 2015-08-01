CREATE TABLE [dbo].[User]
(
	[Id] INT NOT NULL PRIMARY KEY, 
    [Name] VARCHAR(MAX) NOT NULL, 
    [Account_type] INT NOT NULL, 
    [Active] BIT NOT NULL, 
    [Created_at] DATETIME NOT NULL, 
    [Last_accessed] DATETIME NOT NULL, 
    CONSTRAINT [FK_User_Account_type] FOREIGN KEY ([Account_type]) REFERENCES [Account_type]([Id]) 
)
