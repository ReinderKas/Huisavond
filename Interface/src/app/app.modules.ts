import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { RouterModule, RouterOutlet } from '@angular/router';
import { AppComponent } from './app.component';

import { routes } from './app.routes'; // Import the routes from your routing configuration file
import { NavbarComponent } from './navbar/navbar.component';
import { PlayerBarComponent } from './player-bar/player-bar.component';

@NgModule({
  declarations: [
    AppComponent
  ],
  imports: [
    BrowserModule,
    RouterModule.forRoot(routes),
    RouterOutlet, 
    NavbarComponent, 
    PlayerBarComponent
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
