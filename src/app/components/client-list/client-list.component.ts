import { Component, OnInit } from '@angular/core';
import { ClientService } from '../../services/client.service';
import { Client } from '../../models/client.model';
import { Observable, Subject } from 'rxjs';
import { debounceTime, distinctUntilChanged, switchMap } from 'rxjs/operators';

@Component({
  selector: 'app-client-list',
  templateUrl: './client-list.component.html',
  styleUrls: ['./client-list.component.css'],
})
export class ClientListComponent implements OnInit {
  clients: Client[] = [];
  searchTerm: string = '';

  constructor(private clientService: ClientService) { }

  ngOnInit(): void {
    // Fetch clients on component initialization
    this.fetchClients();
  }

  fetchClients(): void {
    this.clientService.getAllClients().subscribe((clients) => {
      this.clients = clients;
    });
  }

  clearSearchPlaceholder(): void {
    // Clear search placeholder text
    this.searchTerm = '';
  }

  editClient(client: Client): void {
    // Implement edit functionality
    console.log('Edit client:', client);
  }

  deleteClient(client: Client): void {
    // Implement delete functionality
    console.log('Delete client:', client);
  }
}

