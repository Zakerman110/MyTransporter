CREATE TABLE [dbo].[VehicleService] (
    [Id]                       INT      IDENTITY (1, 1) NOT NULL,
    [StarDate]                 DATETIME NULL,
    [EndDate]                  DATETIME NULL,
    [VehicleId]                INT      NULL,
    [VehicleServiceCategoryId] INT      NULL,
    CONSTRAINT [PK_VehicleService] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_VehicleService_Vehicle] FOREIGN KEY ([VehicleId]) REFERENCES [dbo].[Vehicle] ([Id]),
    CONSTRAINT [FK_VehicleService_VehicleServiceCategory] FOREIGN KEY ([VehicleServiceCategoryId]) REFERENCES [dbo].[VehicleServiceCategory] ([Id])
);

