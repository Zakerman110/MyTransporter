CREATE TABLE [dbo].[Autobase] (
    [Id]      INT            IDENTITY (1, 1) NOT NULL,
    [Address] NVARCHAR (100) NULL,
    CONSTRAINT [PK_Autobase] PRIMARY KEY CLUSTERED ([Id] ASC)
);

