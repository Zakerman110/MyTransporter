import { journey } from "./journey";
import { orderStatus } from "./orderStatus";
import { route } from "./route";
import { vehicleShort } from "./vehicleShort";

export class order {
    id: number = 0;
    placeDate: string = "";
    status: orderStatus = 0;
    userId: string = "";
    vehicle: vehicleShort = new vehicleShort();
    route: route = new route();
    journey: journey = new journey();
}