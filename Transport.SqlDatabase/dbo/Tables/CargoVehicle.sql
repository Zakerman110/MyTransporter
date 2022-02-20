CREATE TABLE [dbo].[CargoVehicle] (
    [Id]           INT        IDENTITY (1, 1) NOT NULL,
    [LoadCapacity] FLOAT (53) NULL,
    [Volume]       FLOAT (53) NULL,
    [VehicleId]    INT        NULL,
    CONSTRAINT [PK_CargoVehicle] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_CargoVehicle_Vehicle] FOREIGN KEY ([VehicleId]) REFERENCES [dbo].[Vehicle] ([Id])
);


GO
CREATE UNIQUE NONCLUSTERED INDEX [IX_CargoVehicle]
    ON [dbo].[CargoVehicle]([VehicleId] ASC);

