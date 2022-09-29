CREATE TABLE [dbo].[Leaders] (
    [LiderId] INT IDENTITY (1, 1) NOT NULL,
    [UserId]  INT NOT NULL,
    [TeamId]  INT NOT NULL,
    FOREIGN KEY ([TeamId]) REFERENCES [dbo].[Teams] ([TeamId]),
    FOREIGN KEY ([UserId]) REFERENCES [dbo].[Users] ([UserId])
);

