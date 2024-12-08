import { Component } from '@angular/core';
import { Subscription } from 'rxjs';
import { LightboxServiceService } from '../services/lightbox-service.service';
import { CommonModule } from '@angular/common';

@Component({
  selector: 'app-security-lightbox',
  standalone: true,
  imports: [CommonModule],
  templateUrl: './security-lightbox.component.html',
  styleUrl: './security-lightbox.component.css'
})
export class SecurityLightboxComponent {
  showLightbox: boolean = false;
  detectionMessage: string = '';
  private lightboxSubscription: Subscription | undefined;
  private messageSubscription: Subscription | undefined;

  constructor(private lightboxService: LightboxServiceService) {}

  ngOnInit(): void {
    // Subscribe to lightbox visibility and detection message
    this.lightboxSubscription = this.lightboxService.showLightbox$.subscribe(show => {
      this.showLightbox = show;
    });

    this.messageSubscription = this.lightboxService.detectionMessage$.subscribe(message => {
      this.detectionMessage = message;
    });
  }

  ngOnDestroy(): void {
    // Unsubscribe to prevent memory leaks
    this.lightboxSubscription?.unsubscribe();
    this.messageSubscription?.unsubscribe();
  }

  closeLightbox(): void {
    this.lightboxService.closeLightbox();
  }
}
