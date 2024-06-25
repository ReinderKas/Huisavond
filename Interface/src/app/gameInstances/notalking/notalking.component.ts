import { CommonModule } from '@angular/common';
import { Component, OnInit } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { Player } from '../../../models/player';

@Component({
  selector: 'app-notalking',
  standalone: true,
  imports: [
    FormsModule,
    CommonModule
  ],
  templateUrl: './notalking.component.html',
  styleUrl: './notalking.component.css'
})
export class NotalkingComponent implements OnInit {
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
    await fetch(`https://localhost:5104/snakeEyes?name=${player.name}`, {method: 'POST',})
    this.initData();
  }
}
