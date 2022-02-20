CREATE TABLE [dbo].[VehicleServiceCategory] (
    [Id]   INT           IDENTITY (1, 1) NOT NULL,
    [Name] NVARCHAR (50) NULL,
    CONSTRAINT [PK_VehicleServiceCategory] PRIMARY KEY CLUSTERED ([Id] ASC)
);

