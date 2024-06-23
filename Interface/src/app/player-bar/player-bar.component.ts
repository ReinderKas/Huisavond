import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { Player } from '../../models/player';
import { FormsModule } from '@angular/forms';
import { CommonModule } from '@angular/common';

@Component({
  selector: 'app-player-bar',
  standalone: true,
  imports: [
    FormsModule,
    CommonModule
  ],
  templateUrl: './player-bar.component.html',
  styleUrl: './player-bar.component.css'
})
export class PlayerBarComponent implements OnInit{
  name: string = '';
  difficulty: number = 0;

  players: Player[] = [];
  
  constructor(private router: Router) { }

  ngOnInit(): void {
    this.refreshPlayers();
  }

  async onCreatePlayer() {
    const response = await fetch(`https://localhost:5104/players?name=${this.name}&difficulty=${this.difficulty}`, {
      method: 'POST',
      body: JSON.stringify({ name: this.name, difficulty: this.difficulty }),
      headers: {
        'Content-Type': 'application/json'
      }
    });
    let json = await response.json()

    this.players.push(new Player(json['name'], json['difficulty'], json['totalDrinks']))
  }

  async refreshPlayers(){
    const response =  await fetch(`https://localhost:5104/players`, {
      method: 'GET',
    });

    let playersRespo = await response.json();
    console.log(playersRespo);
    this.players = playersRespo;
  }
}
