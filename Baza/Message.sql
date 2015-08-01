CREATE TABLE [dbo].[Message]
(
	[Id] INT NOT NULL PRIMARY KEY, 
    [User] INT NOT NULL, 
    [Created_at] DATETIME NOT NULL, 
    [Content] TEXT NOT NULL, 
    [Room] INT NOT NULL, 
    CONSTRAINT [FK_Message_User] FOREIGN KEY ([User]) REFERENCES [User]([Id]), 
    CONSTRAINT [FK_Message_Room] FOREIGN KEY ([Room]) REFERENCES [Room]([Id])
)
