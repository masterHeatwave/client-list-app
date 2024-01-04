import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { ClientService } from '../../services/client.service';
import { Client } from '../../models/client.model';

@Component({
  selector: 'app-client-details',
  templateUrl: './client-details.component.html',
  styleUrls: ['./client-details.component.css']
})
export class ClientDetailsComponent implements OnInit {
  clientId!: number; // Use definite assignment assertion
  client!: Client;   // Use definite assignment assertion

  constructor(private route: ActivatedRoute, private clientService: ClientService) { }

  ngOnInit(): void {
    // Retrieve the client ID from the route parameters
    this.route.params.subscribe(params => {
      this.clientId = +params['id'];
      // Fetch the client details using the client ID
      this.clientService.getClientById(this.clientId).subscribe(client => {
        this.client = client;
      });
    });
  }
}
