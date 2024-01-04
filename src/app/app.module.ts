import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { MatDialogModule } from '@angular/material/dialog';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { AppComponent } from './app.component';
import { ConfirmationDialogComponent } from './components/confirmation-dialog/confirmation-dialog.component';
import { NavigationComponent } from './components/navigation/navigation.component';
import { RouterModule } from '@angular/router';
import { routes } from './app.routes';
import { FormsModule } from '@angular/forms';
import { ReactiveFormsModule } from '@angular/forms';
import { ClientListComponent } from './components/client-list/client-list.component';

@NgModule({
  declarations: [
    ConfirmationDialogComponent,
    NavigationComponent,
    ClientListComponent,
    AppComponent,
  ],
  imports: [
    BrowserModule,
    BrowserAnimationsModule,
    MatDialogModule,
    FormsModule, 
    RouterModule.forRoot(routes),
  ],
  exports: [RouterModule],
  providers: [
    // Services and other providers
  ],
  bootstrap: [AppComponent],
})
export class AppModule { }
