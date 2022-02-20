CREATE TABLE [dbo].[PassengerVehicle] (
    [Id]          INT        IDENTITY (1, 1) NOT NULL,
    [SeatsCount]  INT        NULL,
    [TrunkVolume] FLOAT (53) NULL,
    [VehicleId]   INT        NULL,
    CONSTRAINT [PK_PassengerVehicle] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_PassengerVehicle_PassengerVehicle] FOREIGN KEY ([VehicleId]) REFERENCES [dbo].[Vehicle] ([Id])
);


GO
CREATE UNIQUE NONCLUSTERED INDEX [IX_PassengerVehicle]
    ON [dbo].[PassengerVehicle]([VehicleId] ASC);

