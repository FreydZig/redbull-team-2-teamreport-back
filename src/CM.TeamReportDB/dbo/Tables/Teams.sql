CREATE TABLE [dbo].[Teams] (
    [TeamId]   INT           IDENTITY (1, 1) NOT NULL,
    [TeamName] NVARCHAR (50) NOT NULL,
    PRIMARY KEY CLUSTERED ([TeamId] ASC),
    CHECK (len([TeamName])<=(100))
);

