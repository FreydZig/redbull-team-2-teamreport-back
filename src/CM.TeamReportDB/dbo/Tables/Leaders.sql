CREATE TABLE [dbo].[Leaders] (
    [UserId]   INT NOT NULL,
    [TeamId]   INT NOT NULL,
    [LeaderId] INT IDENTITY (1, 1) NOT NULL,
    PRIMARY KEY CLUSTERED ([LeaderId] ASC),
    FOREIGN KEY ([TeamId]) REFERENCES [dbo].[Teams] ([TeamId]),
    FOREIGN KEY ([UserId]) REFERENCES [dbo].[Users] ([UserId])
);



