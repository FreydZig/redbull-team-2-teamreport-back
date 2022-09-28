CREATE TABLE [dbo].[Report] (
    [ReportId]            INT            IDENTITY (1, 1) NOT NULL,
    [UserId]              INT            NOT NULL,
    [Morale]              INT            NOT NULL,
    [MoraleDescription]   NVARCHAR (255) NULL,
    [Stress]              INT            NOT NULL,
    [StressDescription]   NVARCHAR (255) NULL,
    [Workload]            INT            NOT NULL,
    [WorkloadDescription] NVARCHAR (255) NULL,
    [High]                NVARCHAR (255) NOT NULL,
    [Low]                 NVARCHAR (255) NOT NULL,
    [AnythingElse]        NVARCHAR (255) NULL,
    [DateRange]           NVARCHAR (100) NOT NULL,
    PRIMARY KEY CLUSTERED ([ReportId] ASC),
    CHECK ([DateRange]<>NULL),
    CHECK ([Morale]<=(5) AND [Morale]>=(1)),
    CHECK ([Stress]<=(5) AND [Stress]>=(1)),
    CHECK ([Workload]<=(5) AND [Workload]>=(1)),
    CHECK (len([High])<=(255) AND len([High])>=(1)),
    CHECK (len([Low])<=(255) AND len([Low])>=(1)),
    FOREIGN KEY ([UserId]) REFERENCES [dbo].[Users] ([UserId])
);

