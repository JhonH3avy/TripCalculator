/**
 * This is a TypeGen auto-generated file.
 * Any changes made to this file can be lost when this file is regenerated.
 */

import { TripElement } from "./trip-element";
import { AppUser } from "./app-user";

export interface DayOfWork {
    id?: number;
    elements: TripElement[];
    user?: AppUser;
    createdAt: Date;
}
