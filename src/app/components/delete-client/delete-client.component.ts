import { Component, OnInit } from '@angular/core';
import { ClientService } from '../../services/client.service';
import { Router, ActivatedRoute } from '@angular/router';

@Component({
  selector: 'app-delete-client',
  templateUrl: './delete-client.component.html',
  styleUrls: ['./delete-client.component.css']
})
export class DeleteClientComponent implements OnInit {
  clientId: number | null = null;

  constructor(
    private clientService: ClientService,
    private router: Router,
    private route: ActivatedRoute
  ) { }

  ngOnInit(): void {
    this.route.paramMap.subscribe(params => {
      // Use non-null assertion operator to tell TypeScript that params is not null
      this.clientId = +params.get('id')!;
    });
  }

  openConfirmationDialog(): void {
    // Confirmation dialog logic 
    const isConfirmed = confirm('This client will be deleted permanently. Do you want to proceed?');

    if (isConfirmed && this.clientId !== null) {
      this.deleteClient();
    } else {

    }
  }

  deleteClient(): void {
    if (this.clientId !== null) {
      this.clientService.deleteClient(this.clientId).subscribe({
        next: () => {
          // Successful deletion, navigate to the client list page
          this.router.navigate(['/client-list']);
        },
        error: error => {
          console.error(error);
          // Handle error, e.g., display an error message
        }
      });
    }
  }
}
