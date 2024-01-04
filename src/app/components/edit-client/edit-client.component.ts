import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { ClientService } from '../../services/client.service';
import { Client } from '../../models/client.model';

@Component({
  selector: 'app-edit-client',
  templateUrl: './edit-client.component.html',
  styleUrls: ['./edit-client.component.css']
})
export class EditClientComponent implements OnInit {
  clientId!: number;  // Use the '!' non-null assertion to tell TypeScript that it will be initialized
  client!: Client;     // Use the '!' non-null assertion to tell TypeScript that it will be initialized

  constructor(
    private route: ActivatedRoute,
    private router: Router,
    private clientService: ClientService
  ) { }

  ngOnInit(): void {
    this.route.params.subscribe(params => {
      this.clientId = +params['id'];
      this.loadClientDetails();
    });
  }

  loadClientDetails() {
    this.clientService.getClientById(this.clientId).subscribe(
      (result: Client) => {
        this.client = result;
      },
      error => {
        console.error(error);
        // Handle error, e.g., redirect to error page or display a message
      }
    );
  }

  updateClient() {
    this.clientService.updateClient(this.clientId, this.client).subscribe({
      next: () => {
        // Successful update, navigate to the client list page
        this.router.navigate(['/client-list']);
      },
      error: error => {
        console.error(error);
        // Handle error, e.g., display an error message
      }
    });
  }
}
