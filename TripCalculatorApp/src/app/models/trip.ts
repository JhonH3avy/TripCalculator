/**
 * This is a TypeGen auto-generated file.
 * Any changes made to this file can be lost when this file is regenerated.
 */

import { TripBag } from "./trip-bag";

export class Trip {
    id: number;
    bags: TripBag[] = [];
    elementsAmount: number;
    createdAt: Date = new Date("11/12/2020 12:22:25 p. m.");
}
