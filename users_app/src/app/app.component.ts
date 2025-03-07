import { Component } from '@angular/core';
import { RouterOutlet } from '@angular/router';
import { UploadFileComponent } from '../componenets/upload-file/upload-file.component';

@Component({
  selector: 'app-root',
  standalone: true,
  imports: [RouterOutlet, UploadFileComponent],
  templateUrl: './app.component.html',
  styleUrl: './app.component.css'
})
export class AppComponent {
  title = 'manager_app';
}
