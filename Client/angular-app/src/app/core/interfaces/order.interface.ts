import { orderStatus } from "../models/orderStatus";
import { JourneyDto } from "./journey.interface";
import { RouteDto } from "./route.interface";
import { VehicleOrderDto } from "./vehicle.interface";

export interface OrderDto {
  readonly id: number;
  readonly placeDate: string;
  readonly status: orderStatus;
  readonly userId: string;

  readonly vehicle: VehicleOrderDto;
  readonly route: RouteDto;
  readonly journey: JourneyDto;
}

export interface NewOrder {
  userId: string;
  vehicleId: number;
  startPointId: number;
  endPointId: number;
  startDate: string
}

export interface EditOrder {
  id: number;
  userId: string;
  placeDate: string;
  vehicleId: number;
  status: orderStatus;
  startPointId: number;
  endPointId: number;
  journeyId: number;
  startDate: string
  endDate: string
}