import { DialogAlertComponent } from './components/shared/dialog-alert/dialog-alert.component';
import { TripElement } from './models/trip-element';
import { DayOfWork } from './models/day-of-work';
import { TripCalculationService } from './services/trip-calculation.service';
import { Component } from '@angular/core';
import { Trip } from './models/trip';
import { MatDialog } from '@angular/material/dialog';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.sass']
})
export class AppComponent {

  identityNumber = '';
  filePath = '';
  file: File | null = null;
  trips: Trip[] = [];

  displayedColumns: string[] = ['case', 'result'];

  constructor(
    private tripCalculation: TripCalculationService,
    private dialog: MatDialog
  ) {}

  onFileSelected(event: Event): void {
    const targetInput = event.target as HTMLInputElement;
    const files = targetInput?.files;
    if (files && files.length > 0) {
      this.file = files[0];
    }
  }

  private openDialog(): void {
    const dialogRef = this.dialog.open(DialogAlertComponent, {
      width: '250px',
      data: {
        message: 'The file does not has a correct format'
      }
    });

    dialogRef.afterClosed().subscribe(result => {
      console.log('The dialog was closed');
    });
  }

  private async createDowFromFile(): Promise<DayOfWork[]> {
    if (!this.file) {
      return [];
    }
    const fileText = await this.file.text();
    const numbers = fileText.split('\n').map(c => Number.parseInt(c, 10));
    const dows = this.parseNumbersToDayOfWork(numbers);
    return dows;
  }

  private parseNumbersToDayOfWork(numbers: number[]): DayOfWork[] {
    const dows: DayOfWork[] = [];
    const days = numbers[0];
    const remainingNumbers = numbers.splice(1);
    while (remainingNumbers.length > 0) {
      try {
        const dow = this.getDow(remainingNumbers);
        dows.push(dow);
      } catch (e) {
        this.openDialog();
      }
    }
    return dows;
  }

  private getDow(remainingNumbers: number[]): DayOfWork {
    const elementsAmount = remainingNumbers.splice(0, 1)[0];
    const elementsWeight = remainingNumbers.splice(0, elementsAmount);
    const elements: TripElement[] = [];
    elementsWeight.forEach(e => elements.push({ weight: e}));
    return {
      elements,
      createdAt: new Date(),
      user: {
        identityNumber: this.identityNumber
      }
    };
  }

  async sendInfo(): Promise<void> {
    const dows = await this.createDowFromFile();
    if (dows.length === 0) {
      return;
    }
    const resultTrips: Trip[] = [];
    const dowsPromises = dows.map(async dow => {
      const trip = await this.tripCalculation.calculateTrip(dow).toPromise();
      resultTrips.push(trip);
    });
    await Promise.all(dowsPromises);
    this.trips = resultTrips;
  }
}
interface HTMLInputEvent extends Event {
  target: HTMLInputElement & EventTarget;
}
