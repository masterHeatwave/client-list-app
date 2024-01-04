import { Routes } from '@angular/router';
import { HomeComponent } from '../app/components/home/home.component';
import { AddClientComponent } from '../app/components/add-client/add-client.component';

export const routes = [
  { path: 'home', component: HomeComponent },
  { path: 'add-client', component: AddClientComponent },
  // Add more routes as needed
];
