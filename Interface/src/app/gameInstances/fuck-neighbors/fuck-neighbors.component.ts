import { CommonModule } from '@angular/common';
import { Component, OnInit } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { Player } from '../../../models/player';

@Component({
  selector: 'app-fuck-neighbors',
  standalone: true,
  imports: [
    FormsModule,
    CommonModule
  ],
  templateUrl: './fuck-neighbors.component.html',
  styleUrl: './fuck-neighbors.component.css'
})
export class FuckNeighborsComponent implements OnInit{
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

  async selectPlayer(player: Player, increase: boolean){
    await fetch(`https://localhost:5104/fuckNeighbors?name=${player.name}&increase=${increase}`, {method: 'POST',})
    this.initData();
  }
}
