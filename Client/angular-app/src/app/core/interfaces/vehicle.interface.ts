export interface VehicleOrderDto {
    readonly id: number;
    readonly externalId: number;
    readonly plate: string;
    readonly color: string;
    readonly model: string;
    readonly make: string;
}