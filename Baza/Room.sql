CREATE TABLE [dbo].[Room]
(
	[Id] INT NOT NULL PRIMARY KEY, 
    [Name] VARCHAR(MAX) NOT NULL, 
    [Visibility] INT NOT NULL, 
    [Admin] INT NOT NULL, 
    [Description] TEXT NOT NULL, 
    [Passcode] VARCHAR(MAX) NOT NULL, 
    CONSTRAINT [FK_Room_Administrator] FOREIGN KEY ([Admin]) REFERENCES [User]([Id]), 
    CONSTRAINT [FK_Room_Visibility] FOREIGN KEY ([Visibility]) REFERENCES [Visibility]([Id])
)
