CREATE TABLE [dbo].[Model] (
    [Id]     INT           IDENTITY (1, 1) NOT NULL,
    [Name]   NVARCHAR (50) NULL,
    [MakeId] INT           NULL,
    CONSTRAINT [PK_Model] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_Model_Make] FOREIGN KEY ([MakeId]) REFERENCES [dbo].[Make] ([Id])
);

