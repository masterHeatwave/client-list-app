// client-list.component.ts
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
  searchTerm: string = ''; // new property to store the search term

  private searchTerms = new Subject<string>();

  constructor(private clientService: ClientService) { }

  ngOnInit(): void {
    this.searchTerms
      .pipe(
        debounceTime(300),
        distinctUntilChanged(),
        switchMap((term: string) => this.clientService.searchClients(term))
      )
      .subscribe((clients) => {
        this.clients = clients;
      });

    // Initial load (you can remove this if not needed)
    this.search('');
  }

  search(term: string): void {
    this.searchTerms.next(term);
  }
}
