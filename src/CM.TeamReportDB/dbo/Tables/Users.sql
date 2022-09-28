CREATE TABLE [dbo].[Users] (
    [UserId]    INT            IDENTITY (1, 1) NOT NULL,
    [TeamId]    INT            NULL,
    [FirstName] NVARCHAR (50)  NULL,
    [LastName]  NVARCHAR (50)  NOT NULL,
    [Email]     NVARCHAR (255) NOT NULL,
    [Password]  NVARCHAR (255) NOT NULL,
    PRIMARY KEY CLUSTERED ([UserId] ASC),
    CHECK ([Email] like '%@%.%'),
    CHECK (len([LastName])<=(100) AND len([LastName])>(0)),
    FOREIGN KEY ([TeamId]) REFERENCES [dbo].[Teams] ([TeamId])
);

