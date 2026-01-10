import { Component, signal } from '@angular/core';
import { RouterModule, RouterOutlet } from '@angular/router';
import { ComponentsAngularModule } from "@dvs-design-system/components-angular"; 

@Component({
  selector: 'app-root',
  imports: [
    RouterModule,
    RouterOutlet,
    ComponentsAngularModule],
  templateUrl: './app.html',
  styleUrl: './app.scss'
})
export class App {
  protected readonly title = signal('WebKeyGenUi');
}
