import { CommonModule } from '@angular/common';
import { Component, OnInit } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { Player } from '../../../models/player';

@Component({
  selector: 'app-doubledown',
  standalone: true,
  imports: [
    FormsModule,
    CommonModule
  ],
  templateUrl: './doubledown.component.html',
  styleUrl: './doubledown.component.css'
})
export class DoubledownComponent implements OnInit {
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
    console.log(this.players)
  }

  async selectPlayer(player: Player, doubleDown: boolean){
    await fetch(`https://localhost:5104/doubleDown?name=${player.name}&success=${doubleDown}`, {method: 'POST',})
    this.initData();

    if (doubleDown){
      let response2 = await fetch(`https://localhost:5104/drinkingBuddy?name=${player.name}&skip=${player.name}`, {method: 'PUT',})
      this.initData();
  
      let playersRespo = await response2.text();
      alert(playersRespo);
    }
  }
}
