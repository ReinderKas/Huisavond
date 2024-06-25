import { Component, OnInit } from '@angular/core';
import { Player } from '../../../models/player';
import { Router } from '@angular/router';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';

@Component({
  selector: 'app-jackpot',
  standalone: true,
  imports: [ 
    FormsModule,
    CommonModule 
  ],
  templateUrl: './jackpot.component.html',
  styleUrl: './jackpot.component.css'
})
export class JackpotComponent implements OnInit{
  players: Player[] = [];
  playerName: string = '';
  
  winner: Player | null = null;
  
  constructor(private router: Router) { }

  ngOnInit(): void {
    this.initData();
  }

  async addToRaffle() {
    const response = await fetch(`https://localhost:5104/jackpot?name=${this.playerName}`, {
      method: 'POST'
    });
    this.initData();
  }

  async initData(){
    const response =  await fetch(`https://localhost:5104/jackpot`, {
      method: 'GET',
    });
    let playersRespo = await response.json();
    this.players = playersRespo;
  }

  drawWinner(){
    this.winner = this.players[Math.floor(Math.random() * this.players.length)];
  }
}
