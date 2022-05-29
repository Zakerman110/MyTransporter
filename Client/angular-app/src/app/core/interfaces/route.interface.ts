import { CityDto } from "./city.interface";

export interface RouteDto {
    readonly id: number;
    readonly startPoint: CityDto;
    readonly endPoint: CityDto;
}