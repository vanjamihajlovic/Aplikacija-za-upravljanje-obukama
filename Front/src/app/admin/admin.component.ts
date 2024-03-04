import { Component } from '@angular/core';

@Component({
  selector: 'app-admin',
  templateUrl: './admin.component.html',
  styleUrl: './admin.component.css'
})
export class AdminComponent {
  kartice = [
    { name: 'Kartica 1', description: 'Ovo je opis prve kartice.', imageUrl: 'assets/slika.webp' },
    { name: 'Kartica 2', description: 'Ovo je opis druge kartice.', imageUrl: 'assets/slika.webp' },
    { name: 'Kartica 3', description: 'Ovo je opis treće kartice.', imageUrl: 'assets/slika.webp' }
  ];
}
