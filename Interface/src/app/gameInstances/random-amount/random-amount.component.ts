import { CommonModule } from '@angular/common';
import { Component, OnInit } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { Player } from '../../../models/player';

@Component({
  selector: 'app-random-amount',
  standalone: true,
  imports: [
    FormsModule,
    CommonModule
  ],
  templateUrl: './random-amount.component.html',
  styleUrl: './random-amount.component.css'
})
export class RandomAmountComponent implements OnInit {
  players: Player[] = [];
  
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
    let response = await fetch(`https://localhost:5104/drinkingBuddy?name=${player.name}`, {method: 'PUT',})
    this.initData();

    let playersRespo = await response.text();
    if (playersRespo.length > 0){
      alert(playersRespo);
    }
  }
}