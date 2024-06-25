import { Component, OnInit } from '@angular/core';
import { Player } from '../../../models/player';
import { FormsModule } from '@angular/forms';
import { CommonModule } from '@angular/common';

@Component({
  selector: 'app-categories',
  standalone: true,
  imports: [
    FormsModule,
    CommonModule
  ],
  templateUrl: './categories.component.html',
  styleUrl: './categories.component.css'
})
export class CategoriesComponent implements OnInit {
  players: Player[] = [];

  winner: Player | null = null;
  drinks: number | null = null;

  
  ngOnInit(): void {
    this.initData();
  }

  async initData(){
    const response =  await fetch(`https://localhost:5104/players`, {
      method: 'GET',
    });

    let playersRespo = await response.json();
    this.players = playersRespo;
  }

  async selectPlayer(player: Player){
    this.winner = player;
    let response = await fetch(`https://localhost:5104/categories?name=${player.name}`, {method: 'POST',})

    this.drinks = await response.json();
    
    
    let response2 = await fetch(`https://localhost:5104/drinkingBuddy?name=${player.name}&skip=${player.name}`, {method: 'PUT',})
    this.initData();

    let playersRespo = await response2.text();
    if (playersRespo.length > 0){
      alert(playersRespo);
    }
  }
}
