import { CommonModule } from '@angular/common';
import { Component, OnInit } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { Player } from '../../../models/player';

@Component({
  selector: 'app-random-drink',
  standalone: true,
  imports: [
    FormsModule,
    CommonModule
  ],
  templateUrl: './random-drink.component.html',
  styleUrl: './random-drink.component.css'
})
export class RandomDrinkComponent implements OnInit {
  players: Player[] = [];

  winner: Player | null = null;
  drink: string | null = null;

  
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
    let response = await fetch(`https://localhost:5104/randomDrink?name=${player.name}`, {method: 'POST',})

    this.drink = await response.text();
    this.winner = player;

    
    let response2 = await fetch(`https://localhost:5104/drinkingBuddy?name=${player.name}&skip=${player.name}`, {method: 'PUT',})
    this.initData();

    let playersRespo = await response2.text();
    alert(playersRespo);
  }
}