import { Component } from '@angular/core';
import { DrinkingBuddy } from '../../../models/drinkingBuddy';
import { Router } from '@angular/router';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';

@Component({
  selector: 'app-drinking-buddy',
  standalone: true,
  imports: [ 
    FormsModule,
    CommonModule 
  ],
  templateUrl: './drinking-buddy.component.html',
  styleUrl: './drinking-buddy.component.css'
})
export class DrinkingBuddyComponent {
  drinkingBuddies: DrinkingBuddy[] = []
  fromName: string = '';
  toName: string = '';
  
  constructor(private router: Router) { }

  ngOnInit(): void {
    this.initData();
  }

  async addDrinkingBuddies() {
    const response = await fetch(`https://localhost:5104/drinkingBuddy?from=${this.fromName}&to=${this.toName}`, {
      method: 'POST',
      headers: {
        'Content-Type': 'application/json'
      }
    });
    this.initData();
  }

  async initData(){
    const response =  await fetch(`https://localhost:5104/drinkingBuddy`, {
      method: 'GET',
    });
    let buddies = await response.json();
    this.drinkingBuddies = buddies;
  }
}
