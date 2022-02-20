CREATE TABLE [dbo].[Vehicle] (
    [Id]          INT           IDENTITY (1, 1) NOT NULL,
    [Plate]       NVARCHAR (10) NULL,
    [Type]        NVARCHAR (50) NULL,
    [IsAvailable] BIT           NULL,
    [AutobaseId]  INT           NULL,
    [ModelId]     INT           NULL,
    CONSTRAINT [PK_Vehicle] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_Vehicle_Autobase] FOREIGN KEY ([AutobaseId]) REFERENCES [dbo].[Autobase] ([Id]),
    CONSTRAINT [FK_Vehicle_Model] FOREIGN KEY ([ModelId]) REFERENCES [dbo].[Model] ([Id])
);

