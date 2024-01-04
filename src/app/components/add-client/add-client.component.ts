import { Component } from '@angular/core';
import { ClientService } from '../../services/client.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-add-client',
  templateUrl: './add-client.component.html',
  styleUrls: ['./add-client.component.css']
})
export class AddClientComponent {
  // Properties for form data
  clientName: string = '';
  clientSurname: string = '';
  clientAddress: string = '';
  clientEmail: string = '';

  // Inject clientService and router
  constructor(private clientService: ClientService, private router: Router) { }

  // Method to handle form submission
  onSubmit() {
    // Create a client object with form data
    const newClient = {
      id: 0,
      name: this.clientName,
      surname: this.clientSurname,
      address: this.clientAddress,
      email: this.clientEmail
    };

    // Call the clientService method to add a new client
    this.clientService.addClient(newClient).subscribe({
      next: () => {
        // Successful addition, navigate to the client list page
        this.router.navigate(['/client-list']);
      },
      error: error => {
        console.error(error);
        // Handle error, e.g., display an error message
      }
    });
  }
}
