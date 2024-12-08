import { Injectable } from '@angular/core';
import { Subject } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class LightboxServiceService {

  constructor() { }
  private detectionSubject = new Subject<string>();
  private showSubject = new Subject<boolean>();

  // Observable for detection message
  detectionMessage$ = this.detectionSubject.asObservable();
  // Observable for show/hide lightbox
  showLightbox$ = this.showSubject.asObservable();

  // Method to trigger the lightbox with a detection message
  triggerDetection(detectionMessage: string): void {
    this.detectionSubject.next(detectionMessage);
    this.showSubject.next(true); // Show lightbox
  }

  // Method to close the lightbox
  closeLightbox(): void {
    this.showSubject.next(false);
  }
}
